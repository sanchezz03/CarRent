using CarRent.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CarRent.Domain.EntityConfigurations;

public class BookingConfiguration : IEntityTypeConfiguration<Booking>
{
    public void Configure(EntityTypeBuilder<Booking> builder)
    {
        builder
            .ToTable("Bookings");

        builder
            .HasKey(b => b.Id);

        builder
            .Property(b => b.StartDate)
            .IsRequired();

        builder
            .Property(b => b.EndDate)
            .IsRequired();

        builder
            .Property(b => b.Status)
            .IsRequired();

        builder
            .HasOne(b => b.Car)
            .WithMany(c => c.Bookings)
            .HasForeignKey(b => b.CarId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(b => b.User)
            .WithMany(u => u.Bookings)
            .HasForeignKey(b => b.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}