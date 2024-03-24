using FiscalLabService.App.Dtos.Request;
using FiscalLabService.App.Dtos.Response;
using FiscalLabService.Shared.Responses;

namespace FiscalLabService.App.Interfaces;

public interface IIdentityService
{
    Task<Result<RegisterUserResponse>> RegisterUserAsync(RegisterUserRequest registerUserRequest);
    Task<Result<LoginResponse>> LoginAsync(LoginRequest loginRequest);
}