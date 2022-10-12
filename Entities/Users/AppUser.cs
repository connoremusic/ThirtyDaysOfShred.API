using Microsoft.AspNetCore.Identity;
using ThirtyDaysOfShred.API.Entities.GuitarTabs;
using ThirtyDaysOfShred.API.Entities.PracticeRoutines;

namespace ThirtyDaysOfShred.API.Entities.Users
{
    public class AppUser : IdentityUser<int>
    {
        public string KnownAs { get; set; }
        public ProfilePhoto ProfilePhoto { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Country { get; set; }
        public string About { get; set; }
        public string Influences { get; set; }
        public ICollection<Goal> Goals { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime LastActive { get; set; } = DateTime.Now;
        public ICollection<GuitarTabFavorite> FavoriteTabs { get; set; }
        public ICollection<PracticeRoutine> PracticeRoutines { get; set; }
        public ICollection<Message> MessagesSent { get; set; }
        public ICollection<Message> MessagesReceived { get; set; }
        public ICollection<AppUserRole> UserRoles { get; set; }
    }
}
