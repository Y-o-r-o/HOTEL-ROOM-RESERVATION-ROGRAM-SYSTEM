using API.Controllers.Base;
using BusinessLayer.DTOs;
using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthenticationController : BaseApiController
{
    private IAuthenticateService _authenticateService;

    public AuthenticationController(IAuthenticateService authenticateService)
    {
        _authenticateService = authenticateService;
    }

    /// <summary>Logs in user, givers user access token and refresh token.</summary>
    /// <param name="loginDTO">User email and password.</param>
    /// <returns>Logged in.</returns>
    [HttpPost("Login")]
    [ProducesResponseType(typeof(AuthenticateResponseDTO), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(GenericHttpExceptionDTO), 500)]
    public async Task<IActionResult> LoginAsync([FromBody] LoginDTO loginDTO)
    {
        return HandleResult(await _authenticateService.LoginAsync(loginDTO.Email, loginDTO.Password));
    }

    /// <summary>Gives user new access token and refresh token.</summary>
    /// <param name="refreshToken" example="asdfsdfgjss1651sdd.sa4896g2d987a4g2946fd4g6e4g8da.acfga52g6r5262654264hgdas">Curret refresh token.</param>
    /// <returns>Tokens refreshed.</returns>
    [HttpPost("Refresh")]
    [ProducesResponseType(typeof(AuthenticateResponseDTO), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(GenericHttpExceptionDTO), 500)]
    public async Task<IActionResult> RefreshTokenAsync([FromHeader(Name = "RefreshToken")] string refreshToken)
    {
        return HandleResult(await _authenticateService.RefreshTokenAsync(refreshToken));
    }
}