using CarRent.Common.Enums;
using CarRent.Domain.Abstractions.Repositories;
using CarRent.Domain.Entities;
using CarRent.Infrastructure.Abstractions.Specifications.CarSpecifications;
using CarRent.Infrastructure.Contexts;

namespace CarRent.Infrastructure.Abstractions.Repositories;

public class CarRepository : BaseRelationalRepository<Car>, ICarRepository
{
    public CarRepository(AppDbContext appDbContext)
    : base(appDbContext) { }

    public async Task<IEnumerable<Car>> GetListAsync(string? brand, CarStatus? carStatus)
    {
        var specification = new CarsByBrandAndStatusSpecification(brand, carStatus);
        var entities = await FindBySpecificationAsync(specification);
        return entities;
    }
}
