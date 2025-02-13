using AutoMapper;
using CarRent.Application.Dtos.Bookings;
using CarRent.Application.Dtos.Filters;
using CarRent.Application.Services.Interfaces;
using CarRent.Common.Enums;
using CarRent.Domain.Abstractions.Repositories;
using CarRent.Domain.Entities;

namespace CarRent.Application.Services;

public class BookingService : IBookingService
{
    private readonly IRelationalRepository<Booking> _bookingRepository;
    private readonly IMapper _mapper;

    public BookingService(IRelationalRepository<Booking> bookingRepository, IMapper mapper)
    {
        _bookingRepository = bookingRepository;
        _mapper = mapper;
    }

    public async Task CreateAsync(BookingDto bookingDto)
    {
        var booking = _mapper.Map<Booking>(bookingDto);

        await _bookingRepository.AddAsync(booking);
    }

    public async Task<IEnumerable<BookingDto>> GetBookingsAsync()
    {
        var bookings = await _bookingRepository.GetListAsync();

        return _mapper.Map<IEnumerable<BookingDto>>(bookings);
    }

    public async Task UpdateAsync(long id, int newStatus)
    {
        var booking = await _bookingRepository.GetAsync(id);

        booking.Status = (BookingStatus)newStatus;

        await _bookingRepository.UpdateAsync(booking);
    }
}
