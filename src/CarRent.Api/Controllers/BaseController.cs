using CarRent.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CarRent.Api.Controllers;

//[Authorize]
[ApiVersion(GlobalSettings.API_VERSION)]
[ApiController]
public class BaseController : ControllerBase
{
    private readonly UserManager<User> _userManager;

    public BaseController(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    #region Public methods

    protected virtual async Task<User> GetCurrentUserAsync()
    {
        return await _userManager.GetUserAsync(User);
    }

    #endregion
}

