using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CarRent.Api.Dtos.AuthDto;

public class RegisterDto
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [PasswordPropertyText]
    public string Password { get; set; }

    [Required]
    public string DisplayName { get; set; }

    [Required]
    public string Username { get; set; }
}
