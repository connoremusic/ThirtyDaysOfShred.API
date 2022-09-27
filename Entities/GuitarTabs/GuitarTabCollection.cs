﻿using ThirtyDaysOfShred.API.Entities.Users;

namespace ThirtyDaysOfShred.API.Entities.GuitarTabs
{
    public class GuitarTabCollection
    {
        public int Id { get; set; }
        public ICollection<GuitarTab> Tabs { get; set; }
        public AppUser AppUser { get; set; }
        public int AppUserId { get; set; }
    }

    public class AuthoredTabs : GuitarTabCollection
    {

    }

    public class LikedTabs : GuitarTabCollection
    {

    }

    public class FavoritedTabs : GuitarTabCollection
    {

    }
}