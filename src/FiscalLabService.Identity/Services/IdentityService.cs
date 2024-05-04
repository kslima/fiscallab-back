using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using FiscalLabService.App.Dtos.Request;
using FiscalLabService.App.Dtos.Response;
using FiscalLabService.App.Interfaces;
using FiscalLabService.Identity.Resources;
using FiscalLabService.Shared.Responses;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace FiscalLabService.Identity.Services;

public class IdentityService : IIdentityService
{
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly JwtOptions _jwtOptions;

    public IdentityService(
        SignInManager<IdentityUser> signInManager,
        UserManager<IdentityUser> userManager,
        JwtOptions jwtOptions)
    {
        _signInManager = signInManager;
        _userManager = userManager;
        _jwtOptions = jwtOptions;
    }

    public async Task<Result<RegisterUserResponse>> RegisterUserAsync(RegisterUserRequest registerUserRequest)
    {
        var identityUser = new IdentityUser
        {
            UserName = registerUserRequest.Email,
            Email = registerUserRequest.Email,
            EmailConfirmed = true
        };

        var result = await _userManager.CreateAsync(identityUser, registerUserRequest.Password);
        if (result.Succeeded)
        {
            await _userManager.SetLockoutEnabledAsync(identityUser, false);
        }

        return Result<RegisterUserResponse>.Success(new RegisterUserResponse { Success = true });
    }

    public async Task<Result<LoginResponse>> LoginAsync(LoginRequest loginRequest)
    {
        var result = await _signInManager.PasswordSignInAsync(loginRequest.Email, loginRequest.Password, false, false);
        if (result.Succeeded)
        {
            return await GenerateToken(loginRequest.Email);
        }

        return Result<LoginResponse>.Failure(new Error("unauthorized", "unauthorized"));
    }

    private async Task<Result<LoginResponse>> GenerateToken(string email)
    {
        var user = await _userManager.FindByEmailAsync(email);
        var tokenClaims = await GetClaims(user!);
        
        var expireAt = DateTime.Now.AddDays(_jwtOptions.Expiration);
        
        var tokenDescriptor = new SecurityTokenDescriptor {
            Issuer =  _jwtOptions.Issuer,
            Audience = _jwtOptions.Audience,
            Subject = new ClaimsIdentity(tokenClaims),
            Expires= expireAt,
            SigningCredentials= new SigningCredentials(_jwtOptions.SecurityKey, SecurityAlgorithms.HmacSha512) };
        
        var securityToken = new JwtSecurityTokenHandler().CreateToken(tokenDescriptor);
        var token = new JwtSecurityTokenHandler().WriteToken(securityToken);
        return Result<LoginResponse>.Success(new LoginResponse { Success = true, Token = token, ExpireAt = expireAt});
    }

    private async Task<List<Claim>> GetClaims(IdentityUser user)
    {
        var claims = await _userManager.GetClaimsAsync(user);
        var roles = await _userManager.GetRolesAsync(user);

        claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id));
        claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
        claims.Add(new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString(CultureInfo.InvariantCulture)));
        claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, DateTime.UtcNow.ToString(CultureInfo.InvariantCulture)));
        claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email!));
        claims.Add(new Claim(ClaimTypes.Name, user.Email!));
        
        foreach (var role in roles)
        {
            claims.Add(new Claim("role", role));
        }

        return claims.ToList();
    }
}