namespace FiscalLabService.App.Dtos.Response;

public class LoginResponse
{
    public bool Success { get; set; }
    public string Token { get; set; } = string.Empty;
    public DateTime? ExpireAt { get; set; }
}