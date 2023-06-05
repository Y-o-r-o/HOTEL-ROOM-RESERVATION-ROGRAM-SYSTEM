using API.Controllers.Base;
using BusinessLayer.BusinessServices;
using BusinessLayer.DTOs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class UsersController : BaseApiController
{
    private IUserServices _userServices;

    public UsersController(IUserServices userServices)
    {
        _userServices = userServices;
    }

    /// <summary>Gets a user by id.</summary>
    /// <param name="id" example="2ecb003d-5f09-4f81-82f7-ee7388165432">The id of user.</param>
    /// <returns>UserDTO</returns>
    /// <response code="200">Returns list of client side product DTO models.</response>
    /// <response code="500">Returns error details.</response>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(UserDTO), 200)]
    [ProducesResponseType(typeof(GenericHttpExceptionDTO), 500)]
    public async Task<IActionResult> GetByIdAsync(string id)
    {
        return HandleResult(await _userServices.GetUserAsync(id));
    }

    /// <summary>Get all users</summary>
    /// <returns>got user.</returns>
    /// <response code="200">Returns list of users.</response>
    /// <response code="500">Returns error details.</response>
    [HttpGet]
    [ProducesResponseType(typeof(UserDTO), 200)]
    [ProducesResponseType(typeof(GenericHttpExceptionDTO), 500)]
    public async Task<IActionResult> GetAllAsync()
    {
        return HandleResult(await _userServices.GetUsersAsync());
    }
}