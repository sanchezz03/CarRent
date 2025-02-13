using System.Linq.Expressions;

namespace CarRent.Domain.Abstractions.Specifications;

public interface ISpecification<T>
{
    bool AsNotTracking { get; set; }
    bool AsSplitQuery { get; set; }

    Expression<Func<T, bool>> Criteria { get; }
    List<Expression<Func<T, object>>> Includes { get; }
    List<string> IncludeStrings { get; }
}
