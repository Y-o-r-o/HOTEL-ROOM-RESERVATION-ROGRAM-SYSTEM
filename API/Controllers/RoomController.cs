using API.Controllers.Base;
using BusinessLayer.DTOs;
using BusinessLayer.DTOs.BookingDTOs;
using BusinessLayer.Interfaces.BookingServices;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.BookingControllers;

[ApiController]
[ApiExplorerSettings(GroupName = "HotelRoomsV1")]
[Route("[controller]")]
public sealed class RoomController : BaseApiController
{
    private readonly IRoomServices _roomServices;

    public RoomController(IRoomServices roomServices)
    {
        _roomServices = roomServices;
    }

    /// <summary>Creates room.</summary>
    /// <param name="room">Room create DTO model.</param>
    /// <response code="200">Returns new room ID.</response>
    /// <response code="500">Returns error details.</response>
    /// <response code="400">Returns property error details.</response>
    [ProducesResponseType(typeof(GenericHttpExceptionDTO), 500)]
    [ProducesResponseType(typeof(ValidationHttpExceptionDTO), 400)]
    [ProducesResponseType(typeof(string), 200)]
    [HttpPost]
    public async Task<IActionResult> CreateRoomAsync(CreateRoomDTO room)
    {
        return HandleResult(await _roomServices.CreateRoomAsync(room));
    }

    /// <summary>Deletes room.</summary>
    /// <param name="Id" example="1">Room to delete ID.</param>
    /// <response code="200"></response>
    /// <response code="500">Returns error details.</response>
    [HttpDelete("{Id}")]
    [ProducesResponseType(typeof(GenericHttpExceptionDTO), 500)]
    public async Task<IActionResult> DeleteRoomAsync(int Id)
    {
        await _roomServices.DeleteRoomAsync(Id);

        return Ok();
    }

    /// <summary>Edits room.</summary>
    /// <param name="Id" example="1">Room to edit ID.</param>
    /// <param name="roomDTO">Room to edit DTO.</param>
    /// <response code="200"></response>
    /// <response code="500">Returns error details.</response>
    /// <response code="400">Returns property error details.</response>
    [ProducesResponseType(typeof(GenericHttpExceptionDTO), 500)]
    [ProducesResponseType(typeof(ValidationHttpExceptionDTO), 400)]
    [HttpPut("{Id}")]
    public async Task<IActionResult> EditRoomAsync(int Id, EditRoomDTO roomDTO)
    {
        await _roomServices.EditRoomAsync(Id, roomDTO);

        return Ok();
    }

    /// <summary>Get room by ID.</summary>
    /// <param name="Id" example="1">Room ID.</param>
    /// <response code="200">Returns room DTO model.</response>
    /// <response code="500">Returns error details.</response>
    [ProducesResponseType(typeof(GenericHttpExceptionDTO), 500)]
    [ProducesResponseType(typeof(RoomDTO), 200)]
    [HttpGet("{Id}")]
    public async Task<IActionResult> GetRoomByIdAsync(int Id)
    {
        return HandleResult(await _roomServices.GetRoomByIdAsync(Id));
    }

    /// <summary>Get all rooms.</summary>
    /// <response code="200">Returns list of room DTO models.</response>
    /// <response code="500">Returns error details.</response>
    [ProducesResponseType(typeof(GenericHttpExceptionDTO), 500)]
    [ProducesResponseType(typeof(IEnumerable<RoomDTO>), 200)]
    [HttpGet]
    public async Task<IActionResult> GetAllRoomsAsync()
    {
        return HandleResult(await _roomServices.GetAllRoomsAsync());
    }
}