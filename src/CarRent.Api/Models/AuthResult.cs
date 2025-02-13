using CarRent.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace CarRent.Api.Models;

public class AuthResult
{
    public IdentityResult Result { get; set; }
    public User User { get; set; }
}
