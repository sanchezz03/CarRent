using CarRent.Application.Dtos.Bookings;
using CarRent.Application.Dtos.Filters;
using CarRent.Application.Services.Interfaces;
using CarRent.Common.Enums;
using CarRent.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace CarRent.Api.Controllers;

[Route("api/v{version:apiVersion}/[controller]")]
public class BookingController : BaseController
{
    private readonly IBookingService _bookingService;
    private readonly ILogger<BookingController> _logger;

    public BookingController(IBookingService bookingService, ILogger<BookingController> logger,
        UserManager<User> userManager) : base(userManager)
    {
        _bookingService = bookingService;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var bookings = await _bookingService.GetBookingsAsync();
            if (bookings.IsNullOrEmpty())
            {
                return NotFound("No bookings found.");
            }

            return Ok(bookings);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving bookings.");
            return StatusCode(500, "An error occurred while retrieving bookings.");
        }
    }

    [HttpPost]
    [Authorize(Roles = "Client")]
    public async Task<IActionResult> Create([FromBody] BookingDto bookingDto)
    {
        try
        {
            var user = await GetCurrentUserAsync();

            bookingDto.UserId = user.Id;
            bookingDto.UserName = user.UserName;

            await _bookingService.CreateAsync(bookingDto);
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating booking.");
            return StatusCode(500, "An error occurred while creating the booking.");
        }
    }

    [HttpPut("{id}/status")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateStatus(int id, int newStatus)
    {
        try
        {
            await _bookingService.UpdateAsync(id, newStatus);

            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating booking status.");
            return StatusCode(500, "An error occurred while updating the booking status.");
        }
    }
}
