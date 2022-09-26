using ThirtyDaysOfShred.API.Entities.Users;

namespace ThirtyDaysOfShred.API.Entities.GuitarTabs
{
    public class TabCollection
    {
        public int Id { get; set; }
        public ICollection<Tab> Tabs { get; set; }
        public AppUser AppUser { get; set; }
        public int AppUserId { get; set; }
    }

    public class AuthoredTabs : TabCollection
    {

    }

    public class LikedTabs : TabCollection
    {

    }

    public class FavoritedTabs : TabCollection
    {

    }
}
