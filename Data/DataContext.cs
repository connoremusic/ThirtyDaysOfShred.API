using Microsoft.EntityFrameworkCore;
using ThirtyDaysOfShred.API.Entities.GuitarTabs;
using ThirtyDaysOfShred.API.Entities.Lessons;
using ThirtyDaysOfShred.API.Entities.Users;

namespace ThirtyDaysOfShred.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<AppUser> Users { get; set; }
        public DbSet<GuitarTab> GuitarTabs { get; set; }
        public DbSet<FavoritedTabs> FavoritedTabs { get; set; }
        public DbSet<LikedTabs> LikedTabs { get; set; }
        public DbSet<AuthoredTabs> AuthoredTabs { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<PracticeRoutine> PracticeRoutines { get; set; }
    }
}
