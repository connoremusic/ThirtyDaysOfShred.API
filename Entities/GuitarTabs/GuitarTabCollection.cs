using ThirtyDaysOfShred.API.Entities.Users;

namespace ThirtyDaysOfShred.API.Entities.GuitarTabs
{
    public class GuitarTabCollection
    {
        public int Id { get; set; }
        public GuitarTab GuitarTab { get; set; }
        public AppUser AppUser { get; set; }
        public int AppUserId { get; set; }
    }

    public class AuthoredTab : GuitarTabCollection
    {

    }

    public class LikedTab : GuitarTabCollection
    {

    }

    public class FavoritedTab : GuitarTabCollection
    {

    }
}
