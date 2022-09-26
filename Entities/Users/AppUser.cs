﻿using ThirtyDaysOfShred.API.Entities.GuitarTabs;
using ThirtyDaysOfShred.API.Extensions;

namespace ThirtyDaysOfShred.API.Entities.Users
{
    public class AppUser
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string KnownAs { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime LastActive { get; set; } = DateTime.Now;
        public string ProfileImageUrl { get; set; }
        public ICollection<AuthoredTabs> AuthoredTabs { get; set; }
        public ICollection<FavoritedTabs> FavoriteTabs { get; set; }
        public ICollection<LikedTabs> LikedTabs { get; set; }
        public ICollection<PracticeRoutine> PracticeRoutines { get; set; }

        public int GetAge()
        {
            return DateOfBirth.CalculateAge();
        }
    }
}
