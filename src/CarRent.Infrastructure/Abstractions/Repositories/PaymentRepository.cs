using CarRent.Domain.Entities;
using CarRent.Infrastructure.Contexts;

namespace CarRent.Infrastructure.Abstractions.Repositories;

public class PaymentRepository : BaseRelationalRepository<Payment>
{
    public PaymentRepository(AppDbContext appDbContext)
    : base(appDbContext) { }
}
