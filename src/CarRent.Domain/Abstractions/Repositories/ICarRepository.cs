using CarRent.Common.Enums;
using CarRent.Domain.Entities;

namespace CarRent.Domain.Abstractions.Repositories;

public interface ICarRepository : IRelationalRepository<Car>
{
    Task<IEnumerable<Car>> GetListAsync(string? brand, CarStatus? carStatus);
}
