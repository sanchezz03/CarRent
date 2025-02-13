using CarRent.Api.Dtos.AuthDto;
using CarRent.Api.Models;
using CarRent.Api.Services;
using CarRent.Common.Enums;
using CarRent.Common.Helpers;
using CarRent.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CarRent.Api.Controllers;

[ApiVersion(GlobalSettings.API_VERSION)]
[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
public class AccountController : ControllerBase
{
    private readonly UserManager<User> _userManager;
    private readonly TokenService _tokenService;

    public AccountController(UserManager<User> userManager, TokenService tokenService)
    {
        _userManager = userManager;
        _tokenService = tokenService;
    }

    [AllowAnonymous]
    [HttpPost("authenticate")]
    public async Task<ActionResult<UserDto>> Authenticate([FromBody] LoginDto loginDto)
    {
        var user = await _userManager.FindByEmailAsync(loginDto.Email);

        if (!await IsPasswordCorrect(user, loginDto.Password))
        {
            return Unauthorized();
        }

        return CreateUserDto(user);
    }

    [AllowAnonymous]
    [HttpPost("registeration")]
    public async Task<ActionResult<UserDto>> Registeration([FromBody] RegisterDto registerDto)
    {
        var isUsernameExist = await _userManager.Users.AnyAsync(x => x.UserName == registerDto.Username);

        if (isUsernameExist)
        {
            return BadRequest("Username is already taken");
        }

        var authResult = await CreateUserAsync(registerDto);

        if (authResult.Result.Succeeded)
        {
            return CreateUserDto(authResult.User);
        }

        return BadRequest(authResult.Result.Errors);
    }

    [Authorize]
    [HttpGet("information")]
    public async Task<ActionResult<UserDto>> Information()
    {
        var user = await _userManager.FindByEmailAsync(User.FindFirstValue(ClaimTypes.Email));

        return CreateUserDto(user);
    }

    #region Private methods

    private async Task<bool> IsPasswordCorrect(User? user, string password)
    {
        if (user == null)
        {
            return false;
        }

        return await _userManager.CheckPasswordAsync(user, password);
    }

    private async Task<AuthResult> CreateUserAsync(RegisterDto registerDto)
    {
        var user = CreateUser(registerDto);

        var result = await _userManager.CreateAsync(user, registerDto.Password);
        result = await _userManager.AddToRoleAsync(user, UserRole.Client.ToDisplayText());

        return new AuthResult()
        {
            Result = result,
            User = user
        };
    }

    private User CreateUser(RegisterDto registerDto)
    {
        return new User()
        {
            DisplayName = registerDto.DisplayName,
        };
    }

    private UserDto CreateUserDto(User user)
    {
        return new UserDto()
        {
            DisplayName = user.DisplayName,
            Token = _tokenService.CreateToken(user),
        };
    }

    #endregion
}

