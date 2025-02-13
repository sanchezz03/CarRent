using CarRent.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarRent.Infrastructure.Contexts;

public class AppDbContext : IdentityDbContext<User>
{
    #region Entities DbSet

    public DbSet<User> Users { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<Payment> Payments { get; set; }

    #endregion

    public AppDbContext(DbContextOptions options) : base(options) { }

    #region Protected methods

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //}
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }

    #endregion
}
