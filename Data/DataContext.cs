using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ThirtyDaysOfShred.API.Entities.GuitarTabs;
using ThirtyDaysOfShred.API.Entities.Lessons;
using ThirtyDaysOfShred.API.Entities.PracticeRoutines;
using ThirtyDaysOfShred.API.Entities.Users;

namespace ThirtyDaysOfShred.API.Data
{
    public class DataContext : IdentityDbContext<AppUser, AppRole, int, 
        IdentityUserClaim<int>, AppUserRole, IdentityUserLogin<int>, 
        IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<GuitarTab> GuitarTabs { get; set; }
        public DbSet<GuitarTabTag> GuitarTabTags { get; set; }
        public DbSet<GuitarTabFavorite> FavoriteGuitarTabs { get; set; }
        public DbSet<LessonTag> LessonTags { get; set; }
        public DbSet<PracticeRoutineTag> PracticeRoutineTags { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<PracticeRoutine> PracticeRoutines { get; set; }
        public DbSet<PracticeRoutineTab> PracticeRoutinesTabs { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Connection> Connections { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AppUser>()
                .HasMany(ur => ur.UserRoles)
                .WithOne(u => u.User)
                .HasForeignKey(ur => ur.UserId)
                .IsRequired();

            builder.Entity<AppRole>()
                .HasMany(ur => ur.UserRoles)
                .WithOne(u => u.Role)
                .HasForeignKey(ur => ur.RoleId)
                .IsRequired();


            builder.Entity<GuitarTabTag>()
                .HasKey(k => new { k.GuitarTabId, k.TagName });

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

            builder.Entity<PracticeRoutineTab>()
                .HasKey(k => new { k.PracticeRoutineId, k.GuitarTabId });

            builder.Entity<PracticeRoutineTab>()
                .HasOne(t => t.GuitarTab)
                .WithMany(p => p.InPracticeRoutine)
                .HasForeignKey(t => t.GuitarTabId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<PracticeRoutineTab>()
                .HasOne(p => p.PracticeRoutine)
                .WithMany(t => t.HasGuitarTab)
                .HasForeignKey(p => p.PracticeRoutineId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Message>()
                .HasOne(u => u.Recipient)
                .WithMany(m => m.MessagesReceived)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Message>()
                .HasOne(u => u.Sender)
                .WithMany(m => m.MessagesSent)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
