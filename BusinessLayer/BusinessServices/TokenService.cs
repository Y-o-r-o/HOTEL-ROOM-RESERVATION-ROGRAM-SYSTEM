using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using BusinessLayer.Interfaces;
using BusinessLayer.Mappers;
using BusinessLayer.Settings;
using Core;
using Microsoft.IdentityModel.Tokens;
using RepositoryLayer.Databases.Entities;
using RepositoryLayer.Repositories;

namespace BusinessLayer.BusinessServices;

internal abstract class TokenService : ITokenService
{
    protected readonly JwtSecurityTokenHandler _jwtSecurityTokenHandler;

    public TokenService(JwtSecurityTokenHandler jwtSecurityTokenHandler)
    {
        _jwtSecurityTokenHandler = jwtSecurityTokenHandler;
    }

    public void Validate(string refreshToken, TokenValidationParameters validationParameters)
    {
        if (refreshToken is null) throw new ArgumentNullException($"{refreshToken} cant be null.");
        try
        {
            _jwtSecurityTokenHandler.ValidateToken(refreshToken, validationParameters, out SecurityToken validatedToken);
        }
        catch (ArgumentNullException ex)
        {
            throw new HttpResponseException(HttpStatusCode.BadRequest, ex.Message);
        }
        catch (Exception ex)
        {
            throw new HttpResponseException(HttpStatusCode.Unauthorized, ex.Message);
        }
    }

    public string Generate(string secretKey, double expires, IEnumerable<Claim>? claims = null)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        SecurityTokenDescriptor tokenDescriptor = ManualMappers.Map(claims, expires, credentials);

        var token = _jwtSecurityTokenHandler.CreateToken(tokenDescriptor);

        return _jwtSecurityTokenHandler.WriteToken(token);
    }

    public abstract Task<string> GenerateAsync(AppUser user);
}

internal class AccessTokenService : TokenService, IAccessTokenService
{
    private readonly JwtSettings _jwtSettings;

    public AccessTokenService(JwtSettings jwtSettings, JwtSecurityTokenHandler jwtSecurityTokenHandler) : base(jwtSecurityTokenHandler)
    {
        _jwtSettings = jwtSettings;
    }

    public override Task<string> GenerateAsync(AppUser user)
    {
        List<Claim> claims = new()
        {
            new Claim("id", user.Id),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Name, user.UserName),
        };
        return Task.FromResult(Generate(_jwtSettings.TokenKey, _jwtSettings.TokenValidityInMinutes, claims));
    }
}

internal class RefreshTokenService : TokenService, IRefreshTokenService
{
    private readonly IRefreshTokenRepository _refreshTokenRepository;
    private readonly JwtSettings _jwtSettings;

    public RefreshTokenService(JwtSettings jwtSettings, IRefreshTokenRepository refreshTokenRepository, JwtSecurityTokenHandler jwtSecurityTokenHandler) : base(jwtSecurityTokenHandler)
    {
        _refreshTokenRepository = refreshTokenRepository;
        _jwtSettings = jwtSettings;
    }

    public override async Task<string> GenerateAsync(AppUser user)
    {
        var refreshToken = Generate(_jwtSettings.RefreshTokenKey, _jwtSettings.RefreshTokenValidityInMinutes);
        await _refreshTokenRepository.AddRefreshTokenAsync(refreshToken, user.Id);
        return refreshToken;
    }

    public async Task<RefreshToken> GetRefreshTokenAsync(string requestRefreshToken)
    {
        return await _refreshTokenRepository.GetRefreshTokenByRequestRefreshTokenAsync(requestRefreshToken);
    }
    
    public async Task RemoveRefreshTokenAsync(RefreshToken refreshToken)
    {
        if (refreshToken is null) throw new ArgumentNullException(nameof(refreshToken) + " can't be null.");
        await _refreshTokenRepository.RemoveRefreshTokenAsync(refreshToken);
    }

    public void Validate(string refreshToken)
        => Validate(refreshToken, _jwtSettings.TokenValidationParameters);
}