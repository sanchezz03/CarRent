using AutoMapper;
using CarRent.Application.Dtos.Cars;
using CarRent.Application.Dtos.Filters;
using CarRent.Application.Services.Interfaces;
using CarRent.Domain.Abstractions.Repositories;
using CarRent.Domain.Entities;

namespace CarRent.Application.Services;

public class CarService : ICarService
{
    private readonly ICarRepository _carRepository;
    private readonly IMapper _mapper;

    public CarService(ICarRepository carRepository, IMapper mapper)
    {
        _carRepository = carRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CarDto>> GetAllAsync(CarFilterDto filter)
    {
        var entities = await _carRepository.GetListAsync(filter.Brand, filter.Status);

        return _mapper.Map<IEnumerable<CarDto>>(entities);
    }

    public async Task CreateAsync(CarDto carDto)
    {
        var car = _mapper.Map<Car>(carDto);

        await _carRepository.AddAsync(car);
    }

    public async Task DeleteAsync(long id)
    {
        await _carRepository.DeleteByIdAsync(id);
    }

    public async Task<CarDto> GetByIdAsync(long id)
    {
        var car = await _carRepository.GetAsync(id);

        return _mapper.Map<CarDto>(car);
    }

    public async Task UpdateAsync(CarDto carDto)
    {
        var car = _mapper.Map<Car>(carDto);

       await _carRepository.UpdateAsync(car);
    }
}
