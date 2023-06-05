using API.Controllers.Base;
using BusinessLayer.DTOs;
using BusinessLayer.DTOs.BookingDTOs;
using BusinessLayer.Interfaces.BookingServices;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.BookingControllers;

[ApiController]
[ApiExplorerSettings(GroupName = "HotelRoomsV1")]
[Route("[controller]")]
public sealed class ResidentController : BaseApiController
{
    private readonly IResidentServices _residentServices;

    public ResidentController(IResidentServices residentServices)
    {
        _residentServices = residentServices;
    }

    /// <summary>Creates resident.</summary>
    /// <param name="resident">Resident create DTO model.</param>
    /// <response code="200">Returns new resident ID.</response>
    /// <response code="500">Returns error details.</response>
    /// <response code="400">Returns property error details.</response>
    [ProducesResponseType(typeof(GenericHttpExceptionDTO), 500)]
    [ProducesResponseType(typeof(ValidationHttpExceptionDTO), 400)]
    [ProducesResponseType(typeof(string), 200)]
    [HttpPost]
    public async Task<IActionResult> CreateResidentAsync(CreateResidentDTO resident)
    {
        return HandleResult(await _residentServices.CreateResident(resident));
    }

    /// <summary>Deletes resident.</summary>
    /// <param name="Id" example="1">Resident to delete ID.</param>
    /// <response code="200">Returns nothing.</response>
    /// <response code="500">Returns error details.</response>
    [ProducesResponseType(typeof(GenericHttpExceptionDTO), 500)]
    [HttpDelete("{Id}")]
    public async Task<IActionResult> DeleteResidentById(int Id)
    {
        await _residentServices.DeleteResidentById(Id);

        return Ok();
    }

    /// <summary>Edit resident.</summary>
    /// <param name="Id">Resident to edit ID.</param>
    /// <param name="resident">Resident edit DTO model.</param>
    /// <response code="200"></response>
    /// <response code="500">Returns error details.</response>
    /// <response code="400">Returns property error details.</response>
    [ProducesResponseType(typeof(GenericHttpExceptionDTO), 500)]
    [ProducesResponseType(typeof(ValidationHttpExceptionDTO), 400)]
    [HttpPut("{Id}")]
    public async Task<IActionResult> EditResident(int Id, EditResidentDTO resident)
    {
        await _residentServices.EditResident(Id, resident);

        return Ok();
    }

    /// <summary>Get resident by giving resident ID.</summary>
    /// <param name="Id" example="1">Resident ID.</param>
    /// <response code="200">Returns resident DTO model.</response>
    /// <response code="500">Returns error details.</response>
    [ProducesResponseType(typeof(GenericHttpExceptionDTO), 500)]
    [ProducesResponseType(typeof(ResidentDTO), 200)]
    [HttpGet("{Id}")]
    public async Task<IActionResult> GetResidentById(int Id)
    {
        return HandleResult(await _residentServices.GetResidentById(Id));
    }
}