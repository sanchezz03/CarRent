using CarRent.Common.Enums;
using CarRent.Domain.Entities;

namespace CarRent.Infrastructure.Abstractions.Specifications.CarSpecifications;

public class CarsByBrandAndStatusSpecification : BaseSpecification<Car>
{
    public CarsByBrandAndStatusSpecification(string? brand, CarStatus? status)
        : base(c => (string.IsNullOrEmpty(brand) || c.Brand.ToLower().Equals(brand.ToLower())) &&
      (!status.HasValue || c.Status == status.Value))
    {
        
    }
}
