using API.Controllers.Base;
using BusinessLayer.DTOs;
using BusinessLayer.DTOs.BookingDTOs;
using BusinessLayer.Interfaces.BookingServices;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.BookingControllers;

[ApiController]
[ApiExplorerSettings(GroupName = "HotelRoomsV1")]
[Route("[controller]")]
public sealed class ReservationController : BaseApiController
{
    private IReservationServices _reservationServices;

    public ReservationController(IReservationServices reservationServices)
    {
        _reservationServices = reservationServices;
    }

    /// <summary>Create reservation.</summary>
    /// <param name="reservation">Reservation to create DTO.</param>
    /// <response code="200">Returns new reservation ID.</response>
    /// <response code="500">Returns error details.</response>
    /// <response code="400">Returns property error details.</response>
    [ProducesResponseType(typeof(GenericHttpExceptionDTO), 500)]
    [ProducesResponseType(typeof(ValidationHttpExceptionDTO), 400)]
    [ProducesResponseType(typeof(string), 200)]
    [HttpPost]
    public async Task<IActionResult> CreateReservationAsync(CreateReservationDTO reservation)
    {
        return HandleResult(await _reservationServices.CreateReservationAsync(reservation));
    }

    /// <summary>Edit reservation.</summary>
    /// <param name="Id" example="1">Reservation to edit ID.</param>
    /// <param name="reservation">Reservation to edit DTO.</param>
    /// <response code="200"></response>
    /// <response code="500">Returns error details.</response>
    /// <response code="400">Returns property error details.</response>
    [ProducesResponseType(typeof(GenericHttpExceptionDTO), 500)]
    [ProducesResponseType(typeof(ValidationHttpExceptionDTO), 400)]
    [HttpPut("{Id}")]
    public async Task<IActionResult> EditReservationAsync(int Id, EditReservationDTO reservation)
    {
        await _reservationServices.EditReservationAsync(Id, reservation);

        return Ok();
    }

    /// <summary>Deletes reservation.</summary>
    /// <param name="Id" example="1">Reservation to delete ID.</param>
    /// <response code="200"></response>
    /// <response code="500">Returns error details.</response>
    [ProducesResponseType(typeof(GenericHttpExceptionDTO), 500)]
    [HttpDelete("{Id}")]
    public async Task<IActionResult> DeleteReservationAsync(int Id)
    {
        await _reservationServices.DeleteReservationAsync(Id);

        return Ok();
    }

    /// <summary>Get all reservations by giving reservation start date and end date.</summary>
    /// <param name="startDate" example="2022-10-07T15:00:00">Start date.</param>
    /// <param name="endDate" example="2022-10-07T16:00:00">End date.</param>
    /// <response code="200">Returns list of reservation DTO models.</response>
    /// <response code="500">Returns error details.</response>
    [ProducesResponseType(typeof(GenericHttpExceptionDTO), 500)]
    [ProducesResponseType(typeof(IEnumerable<ReservationDTO>), 200)]
    [HttpGet("Date/{startDate}/{endDate}")]
    public async Task<IActionResult> GetAllReservationsForDateAsync(string startDate, string endDate)
    {
        return HandleResult(await _reservationServices.GetAllReservationsForDateAsync(DateOnly.Parse(startDate), DateOnly.Parse(endDate)));
    }

    /// <summary>Get all reservations for room by giving room ID.</summary>
    /// <param name="roomId" example="1">Room ID.</param>
    /// <response code="200">Returns list of reservation DTO models.</response>
    /// <response code="500">Returns error details.</response>
    [ProducesResponseType(typeof(GenericHttpExceptionDTO), 500)]
    [ProducesResponseType(typeof(IEnumerable<ReservationDTO>), 200)]
    [HttpGet("Room/{roomId}")]
    public async Task<IActionResult> GetAllReservationsForRoomAsync(int roomId)
    {
        return HandleResult(await _reservationServices.GetAllReservationsForRoomAsync(roomId));
    }

    /// <summary>Get reservation by giving reservation ID.</summary>
    /// <param name="Id" example="1">Reservation ID.</param>
    /// <response code="200">Returns reservation DTO model.</response>
    /// <response code="500">Returns error details.</response>
    [ProducesResponseType(typeof(GenericHttpExceptionDTO), 500)]
    [ProducesResponseType(typeof(ReservationDTO), 200)]
    [HttpGet("{Id}")]
    public async Task<IActionResult> GetReservartionByIdAsync(int Id)
    {
        return HandleResult(await _reservationServices.GetReservationByIdAsync(Id));
    }

    /// <summary>Get all reservations.</summary>
    /// <response code="200">Returns list of reservation DTO models.</response>
    /// <response code="500">Returns error details.</response>
    [ProducesResponseType(typeof(GenericHttpExceptionDTO), 500)]
    [ProducesResponseType(typeof(IEnumerable<ReservationDTO>), 200)]
    [HttpGet]
    public async Task<IActionResult> GetAllReservationsAsync()
    {
        return HandleResult(await _reservationServices.GetAllReservationsAsync());
    }

    /// <summary>Get all reservations for month by giving date.</summary>
    /// <param name="date" example="2022-10">Month date.</param>
    /// <response code="200">Returns dictionary with user reservations DTO models at that date.</response>
    /// <response code="500">Returns error details.</response>
    [ProducesResponseType(typeof(GenericHttpExceptionDTO), 500)]
    [ProducesResponseType(typeof(Dictionary<Guid, List<ReservationDataDTO>>), 200)]
    [HttpGet("Month/{date}")]
    public async Task<IActionResult> GetMonthReservationsSortedByUserAsync(string date)
    {
        return HandleResult(await _reservationServices.GetMonthReservationsSortedByUserAsync(DateTime.Parse(date)));
    }
}