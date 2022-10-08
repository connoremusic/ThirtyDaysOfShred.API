using ThirtyDaysOfShred.API.Entities.Users;

namespace ThirtyDaysOfShred.API.Entities.GuitarTabs
{
    public class GuitarTabFavorite
    {
        public AppUser AppUser { get; set; }
        public int AppUserId { get; set; }
        public GuitarTab GuitarTab { get; set; }
        public int GuitarTabId { get; set; }
    }
}
