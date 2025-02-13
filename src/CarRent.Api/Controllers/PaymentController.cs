using CarRent.Application.Dtos.Payments;
using CarRent.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarRent.Api.Controllers;


[Route("api/v{version:apiVersion}/[controller]")]
public class PaymentController : ControllerBase
{
    private readonly IPaymentService _paymentService;
    private readonly ILogger<PaymentController> _logger;

    public PaymentController(IPaymentService paymentService, ILogger<PaymentController> logger)
    {
        _paymentService = paymentService;
        _logger = logger;
    }

    [HttpPost]
    [Authorize(Roles = "Client")]
    public async Task<IActionResult> ProcessPayment([FromBody] PaymentDto paymentDto)
    {
        try
        {
            await _paymentService.ProcessPaymentAsync(paymentDto);
            return Ok("Payment successful.");
        }
        catch (ArgumentException ex)
        {
            _logger.LogWarning(ex, "Invalid payment data: {Message}", ex.Message);
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error processing payment");
            return StatusCode(500, "An error occurred while processing the payment.");
        }
    }
}
