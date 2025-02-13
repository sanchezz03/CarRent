using CarRent.Domain.Entities;
using CarRent.Infrastructure.Contexts;

namespace CarRent.Infrastructure.Abstractions.Repositories;

public class BookingRepository : BaseRelationalRepository<Booking>
{
    public BookingRepository(AppDbContext appDbContext)
    : base(appDbContext) { }
}
