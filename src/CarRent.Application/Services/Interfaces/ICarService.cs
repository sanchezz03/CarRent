using CarRent.Application.Dtos.Cars;
using CarRent.Application.Dtos.Filters;

namespace CarRent.Application.Services.Interfaces;

public interface ICarService
{
    Task<IEnumerable<CarDto>> GetAllAsync(CarFilterDto filter);
    Task<CarDto> GetByIdAsync(long id);
    Task CreateAsync(CarDto carDto);
    Task UpdateAsync(CarDto carDto);
    Task DeleteAsync(long id);
}
