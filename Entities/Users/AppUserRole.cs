using Microsoft.AspNetCore.Identity;

namespace ThirtyDaysOfShred.API.Entities.Users
{
    public class AppUserRole : IdentityUserRole<int>
    {
        public AppUser User { get; set; }
        public AppRole Role { get; set; }
    }
}
