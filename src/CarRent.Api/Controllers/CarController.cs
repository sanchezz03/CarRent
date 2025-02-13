using CarRent.Application.Dtos.Cars;
using CarRent.Application.Dtos.Filters;
using CarRent.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace CarRent.Api.Controllers;

[Route("api/v{version:apiVersion}/[controller]")]
public class CarController : ControllerBase
{
    private readonly ICarService _carService;
    private readonly ILogger<CarController> _logger;

    public CarController(ICarService carService, ILogger<CarController> logger)
    {
        _carService = carService;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] CarFilterDto filter)
    {
        try
        {
            var cars = await _carService.GetAllAsync(filter);
            if (cars.IsNullOrEmpty())
            {
                return NotFound("No cars found.");
            }
            return Ok(cars);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving car list.");
            return StatusCode(500, "An error occurred while retrieving cars.");
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var car = await _carService.GetByIdAsync(id);
            if (car == null)
            {
                return NotFound($"Car with ID {id} not found.");
            }
            return Ok(car);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving car with ID {Id}.", id);
            return StatusCode(500, "An error occurred while retrieving the car.");
        }
    }

    [HttpPost]
  //  [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Create([FromBody]CarDto carDto)
    {
        try
        {
            await _carService.CreateAsync(carDto);
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating car.");
            return StatusCode(500, "An error occurred while creating the car.");
        }
    }

    [HttpPut("{id}")]
   // [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Update(int id, [FromBody] CarDto carDto)
    {
        try
        {
            if (id != carDto.Id)
            {
                return BadRequest("ID in the URL does not match ID in the body.");
            }

            await _carService.UpdateAsync(carDto);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound($"Car with ID {id} not found.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating car with ID {Id}.", id);
            return StatusCode(500, "An error occurred while updating the car.");
        }
    }

    [HttpDelete("{id}")]
   // [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _carService.DeleteAsync(id);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound($"Car with ID {id} not found.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting car with ID {Id}.", id);
            return StatusCode(500, "An error occurred while deleting the car.");
        }
    }
}
