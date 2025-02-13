using AutoMapper;
using CarRent.Application.Dtos.Bookings;
using CarRent.Domain.Entities;

namespace CarRent.Application.Mappings;

public class BookingProfile : Profile
{
    public BookingProfile()
    {
        CreateMap<Booking, BookingDto>();
        CreateMap<BookingDto, Booking>();
    }
}
