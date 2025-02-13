using CarRent.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CarRent.Domain.EntityConfigurations;

public class CarConfiguration : IEntityTypeConfiguration<Car>
{
    public void Configure(EntityTypeBuilder<Car> builder)
    {
        builder
            .ToTable("Cars");

        builder
            .HasKey(c => c.Id);

        builder
            .Property(c => c.Brand).IsRequired();

        builder
            .Property(c => c.Model).IsRequired();

        builder
            .Property(c => c.Year).IsRequired();

        builder
            .Property(c => c.PricePerDay).IsRequired();

        builder
            .Property(c => c.PhotoUrl).IsRequired();

        builder
            .Property(c => c.Status).IsRequired();

        builder
            .HasMany(c => c.Bookings)
            .WithOne(b => b.Car)
            .HasForeignKey(b => b.CarId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
