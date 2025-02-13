using CarRent.Application.Dtos.Bookings;
using CarRent.Common.Enums;

namespace CarRent.Application.Services.Interfaces;

public interface IBookingService
{
    Task<IEnumerable<BookingDto>> GetBookingsAsync();
    Task CreateAsync(BookingDto bookingDto);
    Task UpdateAsync(long id, int newStatus);
}
