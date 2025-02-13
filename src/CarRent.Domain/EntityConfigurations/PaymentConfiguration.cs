using CarRent.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRent.Domain.EntityConfigurations;

public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder
            .ToTable("Payments");

        builder
            .HasKey(p => p.Id);

        builder
            .Property(p => p.Amount)
            .IsRequired();

        builder
            .Property(p => p.Method)
            .IsRequired();

        builder
            .Property(p => p.Date)
            .IsRequired();

        builder
            .HasOne(p => p.Booking)
            .WithOne(p => p.Payment)
            .HasForeignKey<Payment>(p => p.BookingId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
