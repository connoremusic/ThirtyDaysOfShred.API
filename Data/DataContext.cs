using Microsoft.EntityFrameworkCore;
using ThirtyDaysOfShred.API.Entities.Users;

namespace ThirtyDaysOfShred.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<AppUser> Users { get; set; }
    }
}
