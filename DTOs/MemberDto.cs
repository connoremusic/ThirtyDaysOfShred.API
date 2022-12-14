using ThirtyDaysOfShred.API.Entities.GuitarTabs;
using ThirtyDaysOfShred.API.Entities.PracticeRoutines;
using ThirtyDaysOfShred.API.Entities.Users;

namespace ThirtyDaysOfShred.API.DTOs
{
    public class MemberDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public int Age { get; set; }
        public string KnownAs { get; set; }
        public ProfilePhotoDto ProfilePhoto { get; set; }
        public string Gender { get; set; }
        public string Country { get; set; }
        public string About { get; set; }
        public string Influences { get; set; }
        public ICollection<GoalDto> Goals { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime LastActive { get; set; } = DateTime.Now;
        public ICollection<GuitarTabDto> FavoriteTabs { get; set; }
        public ICollection<PracticeRoutine> PracticeRoutines { get; set; }
    }
}
