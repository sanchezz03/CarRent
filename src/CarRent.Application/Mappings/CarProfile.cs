using AutoMapper;
using CarRent.Application.Dtos.Cars;
using CarRent.Domain.Entities;

namespace CarRent.Application.Mappings;

public class CarProfile : Profile
{
    public CarProfile()
    {
        CreateMap<Car, CarDto>();
        CreateMap<CarDto, Car>();
    }
}
