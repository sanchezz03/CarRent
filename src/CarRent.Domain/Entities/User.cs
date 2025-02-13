using Microsoft.AspNetCore.Identity;

namespace CarRent.Domain.Entities;

public class User : IdentityUser
{
    public string DisplayName { get; set; }


    #region Navigation Properties

    public ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    #endregion
}
