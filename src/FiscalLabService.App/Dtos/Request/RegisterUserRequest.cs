using System.ComponentModel.DataAnnotations;

namespace FiscalLabService.App.Dtos.Request;

public class RegisterUserRequest
{
    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
    
    [Required]
    [StringLength(50, MinimumLength = 6)]
    public string Password { get; set; } = string.Empty;
    
    [Compare(nameof(Password))]
    public string ConfirmPassword { get; set; } = string.Empty;
}