﻿using ThirtyDaysOfShred.API.Entities.GuitarTabs;
using ThirtyDaysOfShred.API.Entities.Users;

namespace ThirtyDaysOfShred.API.DTOs
{
    public class MemberDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public int Age { get; set; }
        public string KnownAs { get; set; }
        public string ProfileImageUrl { get; set; }
        public string Gender { get; set; }
        public string Country { get; set; }
        public string About { get; set; }
        public string Influences { get; set; }
        public ICollection<Goal> Goals { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime LastActive { get; set; } = DateTime.Now;
        public ICollection<AuthoredTabs> AuthoredTabs { get; set; }
        public ICollection<FavoritedTabs> FavoriteTabs { get; set; }
        public ICollection<LikedTabs> LikedTabs { get; set; }
        public ICollection<PracticeRoutineDto> PracticeRoutines { get; set; }
    }
}