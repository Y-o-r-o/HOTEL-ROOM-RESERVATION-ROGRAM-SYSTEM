using AutoMapper;
using BusinessLayer.DTOs.BookingDTOs;
using BusinessLayer.Helpers;
using BusinessLayer.Interfaces.BookingServices;
using BusinessLayer.Mappers;
using Core;
using RepositoryLayer.Databases.Entities.BookingEntities;
using RepositoryLayer.Interfaces;
using System.Net;

namespace BusinessLayer.BusinessServices.BookingServices;

internal sealed class ReservationServices : IReservationServices
{
    private readonly TimeSpan MINIMUM_RESERVATION_TIME = TimeSpan.FromHours(12);
    private readonly IReservationRepository _reservationRepository;
    private readonly IProductRepository _productRepository;
    private readonly IRoomRepository _roomRepository;
    private readonly IResidentRepository _residentRepository;
    private readonly IDateTimeProviderServices _dateTimeProviderServices;
    private readonly IMapper _mapper;

    public ReservationServices(IReservationRepository reservationRepository, IProductRepository productRepository,
        IRoomRepository roomRepository, IResidentRepository residentRepository, IDateTimeProviderServices dateTimeProviderServices, IMapper mapper)
    {
        _reservationRepository = reservationRepository;
        _productRepository = productRepository;
        _roomRepository = roomRepository;
        _residentRepository = residentRepository;
        _dateTimeProviderServices = dateTimeProviderServices;
        _mapper = mapper;
    }

    public async Task<int> CreateReservationAsync(CreateReservationDTO reservationDTO)
    {
        var reservation = _mapper.Map<Reservation>(reservationDTO);

        var productEntity = await _productRepository.GetProductByIdAsync(reservationDTO.ProductId);
        if (productEntity == null)
        {
            throw new HttpResponseException(HttpStatusCode.NotFound, $"Product with id: {reservationDTO.ProductId} not found.");
        }

        reservation.Rooms = await GetAvailableRoomsForRequiredTypes(productEntity.RoomsTypes, reservationDTO.StartDate, reservationDTO.EndDate);
        if (reservation.Rooms.Count() != productEntity.RoomsTypes.Count())
        {
            throw new HttpResponseException(HttpStatusCode.NotFound, $"Rooms not found.");
        }

        reservation.Resident = await _residentRepository.GetResidentByIdAsync(reservationDTO.ResidentId) ??
            throw new HttpResponseException(HttpStatusCode.NotFound, $"Resident not found with this id {reservationDTO.ResidentId}.");

        await ValidateReservation(reservation);

        var result = await _reservationRepository.CreateReservationAsync(reservation);

        return result;
    }

    public async Task EditReservationAsync(int id, EditReservationDTO reservationDTO)
    {
        var reservationEntity = await _reservationRepository.GetReservationByIdAsync(id) ??
            throw new HttpResponseException(HttpStatusCode.NotFound, $"Reservation not found with this id {id}.");

        _mapper.Map(reservationDTO, reservationEntity);

        await ValidateReservation(reservationEntity);

        await _reservationRepository.EditReservationAsync(reservationEntity);
    }

    public async Task DeleteReservationAsync(int reservationId)
    {
        var reservation = await _reservationRepository.GetReservationByIdAsync(reservationId) ??
            throw new HttpResponseException(HttpStatusCode.NotFound, $"Reservation not found with this id:{reservationId}.");

        await _reservationRepository.DeleteReservationAsync(reservation);
    }

    public async Task<IEnumerable<ReservationDTO>> GetAllReservationsForDateAsync(DateOnly startDateOnly, DateOnly endDateOnly)
    {
        if (startDateOnly > endDateOnly)
        {
            throw new ValidationException("Date", "Reservation start date cannot be later than end date.");
        }

        var startDate = DateHelpers.ParseDateOnlyToDateTime(startDateOnly);
        var endDate = DateHelpers.ParseDateOnlyToDateTime(endDateOnly).AddDays(Constants.ONE_DAY);

        var reservationsEntities = await _reservationRepository.GetAllReservationsForDateAsync(startDate, endDate);

        if (!reservationsEntities.Any())
        {
            throw new HttpResponseException(HttpStatusCode.NotFound, $"No reservations found for these dates {startDateOnly}, {endDateOnly}.");
        }

        return reservationsEntities.MapToReservationsDTO();
    }

    public async Task<IEnumerable<ReservationDTO>> GetAllReservationsForRoomAsync(int roomId)
    {
        var reservationsEntities = await _reservationRepository.GetAllReservationsForRoomAsync(roomId);

        if (!reservationsEntities.Any())
        {
            throw new HttpResponseException(HttpStatusCode.NotFound, $"No reservations found for this room {roomId}.");
        }

        return reservationsEntities.MapToReservationsDTO();
    }

    public async Task<ReservationDTO> GetReservationByIdAsync(int reservationId)
    {
        var reservationEntity = await _reservationRepository.GetReservationByIdAsync(reservationId) ??
            throw new HttpResponseException(HttpStatusCode.NotFound, $"No reservation found with Id: {reservationId}.");

        return reservationEntity.MapToReservationDTO();
    }

    public async Task<IEnumerable<ReservationDTO>> GetAllReservationsAsync()
    {
        var reservationsEntities = await _reservationRepository.GetAllReservationsAsync();

        if (reservationsEntities.Any())
        {
            return reservationsEntities.MapToReservationsDTO();
        }

        throw new HttpResponseException(HttpStatusCode.NotFound, "Reservations not found.");
    }

    public async Task<Dictionary<int, IEnumerable<ReservationDataDTO>>> GetMonthReservationsSortedByUserAsync(DateTime date)
    {
        var reservationsEntities = await _reservationRepository.GetReservationsAsync(r => r.EndDate.Year == date.Year && r.EndDate.Month == date.Month);

        if (!reservationsEntities.Any())
        {
            throw new HttpResponseException(HttpStatusCode.NotFound, $"Reservations not found.");
        }

        var mappedToReservationDataDTO = reservationsEntities.MapToReservationsDataDTO();

        var reservationsDataGrouped = mappedToReservationDataDTO.GroupBy(u => u.ResidentId).Select(grp => grp.ToList()).ToList();
        var reservationsDataDictionary = new Dictionary<int, IEnumerable<ReservationDataDTO>>();

        foreach (var data in reservationsDataGrouped)
        {
            reservationsDataDictionary.Add(data.First().ResidentId, data);
        }

        return reservationsDataDictionary;
    }

    private async Task ValidateReservation(Reservation reservation)
    {
        var errors = new List<string>();

        if (reservation.StartDate > reservation.EndDate)
        {
            errors.Add("Reservation start date could not be later then end date.");
        }

        if (reservation.StartDate < _dateTimeProviderServices.DateTimeNow())
        {
            errors.Add("Reservation could not be made in past time.");
        }

        if (reservation.EndDate - reservation.StartDate < MINIMUM_RESERVATION_TIME)
        {
            errors.Add($"Reservation could not be shorter than {MINIMUM_RESERVATION_TIME.Hours} hours.");
        }

        if (await IsReservationCollideWithExistingOnes(reservation))
        {
            errors.Add("Reservation could not be created due to availability.");
        }

        ValidationException.ThrowIfPropertyInvalid("Reservation", errors);
    }

    private async Task<bool> IsReservationCollideWithExistingOnes(Reservation reservation)
    {
        DateTime startDate = reservation.StartDate.Date;
        DateTime endDate = reservation.EndDate.Date.AddDays(Constants.ONE_DAY);

        var reservations = await _reservationRepository.GetAllReservationsForDateAsync(startDate, endDate);

        if (!reservations.Any())
        {
            return false;
        }

        var existingReservationsForDate = reservations.Where(r => r.Id != reservation.Id).ToList();
        foreach (var room in reservation.Rooms)
        {
            var existingRoomReservationsForDate = existingReservationsForDate.Where(r => r.Rooms.Any(r => r.Id == room.Id)).ToList();

            if (ReservationAlreadyExistInThisTimeSpan(existingRoomReservationsForDate, startDate, endDate))
            {
                return true;
            }
        }

        return false;
    }

    private async Task<IEnumerable<Room>> GetAvailableRoomsForRequiredTypes(IEnumerable<int> roomTypes, DateTime startDate, DateTime endDate)
    {
        var availableRooms = new List<Room>();
        
        foreach (var roomType in roomTypes)
        {
            var requiredTypeRooms = await _roomRepository.GetRoomsAsync(r => r.Type == roomType);
            foreach (var room in requiredTypeRooms)
            {
                var existingRoomReservationsForDate = await _reservationRepository.GetReservationsAsync(r => r.Rooms.Any(r => r.Id == room.Id));
                if (!ReservationAlreadyExistInThisTimeSpan(existingRoomReservationsForDate, startDate, endDate))
                {
                    availableRooms.Add(room);
                    break;
                }
            }
        };

        return availableRooms;
    }

    private bool ReservationAlreadyExistInThisTimeSpan(IEnumerable<Reservation> reservations, DateTime startDate, DateTime endDate)
    {
        return (reservations.Any() && reservations.Any(existing => (existing.StartDate <= startDate && existing.EndDate >= startDate) || (existing.StartDate <= endDate && existing.EndDate >= endDate)));
    }
}