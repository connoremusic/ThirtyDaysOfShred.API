using ThirtyDaysOfShred.API.Entities.GuitarTabs;

namespace ThirtyDaysOfShred.API.DTOs
{
    public class MemberDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public int Age { get; set; }
        public string KnownAs { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }
        public string Gender { get; set; }
        public string ProfileImageUrl { get; set; }
        public ICollection<AuthoredTabsDto> AuthoredTabs { get; set; }
        public ICollection<FavoritedTabsDto> FavoriteTabs { get; set; }
        public ICollection<LikedTabsDto> LikedTabs { get; set; }
        public ICollection<PracticeRoutineDto> PracticeRoutines { get; set; }
    }
}
