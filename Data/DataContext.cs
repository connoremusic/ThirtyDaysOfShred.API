using Microsoft.EntityFrameworkCore;
using ThirtyDaysOfShred.API.Entities.GuitarTabs;
using ThirtyDaysOfShred.API.Entities.Lessons;
using ThirtyDaysOfShred.API.Entities.PracticeRoutines;
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
        public DbSet<GuitarTabTag> GuitarTabTags { get; set; }
        public DbSet<GuitarTabFavorite> FavoriteGuitarTabs { get; set; }
        public DbSet<LessonTag> LessonTags { get; set; }
        public DbSet<PracticeRoutineTag> PracticeRoutineTags { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<PracticeRoutine> PracticeRoutines { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<GuitarTabFavorite>()
                .HasKey(k => new { k.AppUserId, k.GuitarTabId });

            builder.Entity<GuitarTabFavorite>()
                .HasOne(u => u.AppUser)
                .WithMany(t => t.FavoriteTabs)
                .HasForeignKey(u => u.AppUserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<GuitarTabFavorite>()
                .HasOne(t => t.GuitarTab)
                .WithMany(u => u.FavoritedByUser)
                .HasForeignKey(t => t.GuitarTabId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
