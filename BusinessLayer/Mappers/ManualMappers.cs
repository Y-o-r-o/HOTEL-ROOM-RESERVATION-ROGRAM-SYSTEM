using System.Security.Claims;
using BusinessLayer.DTOs;
using BusinessLayer.DTOs.BookingDTOs;
using BusinessLayer.Enums;
using Microsoft.IdentityModel.Tokens;
using RepositoryLayer.Databases.Entities;
using RepositoryLayer.Databases.Entities.BookingEntities;

namespace BusinessLayer.Mappers;

internal static class ManualMappers
{
    public static IEnumerable<ReservationDataDTO> MapToReservationsDataDTO(this IEnumerable<Reservation> reservations)
    {
        return reservations.Select(reservation => new ReservationDataDTO
        {
            ResidentId = reservation.Resident.Id,
            RoomsTypes = reservation.Rooms.Select(r => (RoomType)r.Type),
            Date = reservation.EndDate.ToShortDateString(),
            Duration = (reservation.EndDate - reservation.StartDate).Duration()
        });
    }

    public static SecurityTokenDescriptor Map(IEnumerable<Claim>? claims, double expires, SigningCredentials credentials)
    {
        return new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(expires),
            SigningCredentials = credentials
        };
    }

    public static IEnumerable<ReservationDTO> MapToReservationsDTO(this IEnumerable<Reservation> reservations)
    {
        return reservations.Select(reservation => reservation.MapToReservationDTO());
    }

    public static ReservationDTO MapToReservationDTO(this Reservation reservation)
    {
        return new ReservationDTO()
        {
            Id = reservation.Id,
            RoomsNumbers = reservation.Rooms.Select(r => r.Number),
            RoomTypes = reservation.Rooms.Select(r => (RoomType)r.Type),
            AdditionalFeatures = reservation.AdditionalFeatures.Select(f => (AdditionalFeature)f),
            Resident = new ResidentDTO()
            {
                Id = reservation.Resident.Id,
                Name = reservation.Resident.Name,
                Surname = reservation.Resident.Surname,
                Email = reservation.Resident.Email,
                PhoneNumber = reservation.Resident.PhoneNumber
            },
            StartDate = reservation.StartDate,
            EndDate = reservation.EndDate
        };
    }

    public static IEnumerable<RoomDTO> MapToRoomsDTO(this IEnumerable<Room> rooms)
    {
        return rooms.Select(room => room.MapToRoomDTO());
    }

    public static RoomDTO MapToRoomDTO(this Room room)
    {
        return new RoomDTO()
        {
            Id = room.Id,
            Type = (RoomType)room.Type,
            Number = room.Number,
            ReservationsIds = room.Reservations.Select(r => r.Id)
        };
    }

    public static UserDTO Map(AppUser from)
    {
        return new UserDTO()
        {
            DisplayName = from.DisplayName,
            IsAdmin = from.IsAdmin
        };
    }
}