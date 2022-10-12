using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ThirtyDaysOfShred.API.Entities.GuitarTabs;
using ThirtyDaysOfShred.API.Entities.Users;

namespace ThirtyDaysOfShred.API.Data
{
    public class Seed
    {
        public static async Task SeedUsers(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            if (await userManager.Users.AnyAsync()) return;

            var userData = await File.ReadAllTextAsync("Data/UserSeedData.json");
            var users = JsonSerializer.Deserialize<List<AppUser>>(userData);
            if (users == null) return;

            var roles = new List<AppRole>
            {
                new AppRole{Name = "Member" },
                new AppRole{Name = "Admin" },
                new AppRole{Name = "Moderator"}
            };

            foreach (var role in roles)
            {
                await roleManager.CreateAsync(role);
            }

            foreach (var user in users)
            {
                user.UserName = user.UserName.ToLower();

                await userManager.CreateAsync(user, "Pa$$w0rd");
                await userManager.AddToRoleAsync(user, "Member");
            }

            var admin = new AppUser
            {
                UserName = "admin",
                KnownAs = "admin"
            };

            await userManager.CreateAsync(admin, "Pa$$w0rd");
            await userManager.AddToRolesAsync(admin, new[] { "Admin", "Moderator" });
        }

        public static async Task SeedGuitarTabs(DataContext context)
        {
            if (await context.GuitarTabs.AnyAsync()) return;

            var guitarTabData = await File.ReadAllTextAsync("Data/GuitarTabSeedData.json");
            var guitarTabs = JsonSerializer.Deserialize<List<GuitarTab>>(guitarTabData);

            foreach (var guitarTab in guitarTabs)
            {
                context.GuitarTabs.Add(guitarTab);
            }

            await context.SaveChangesAsync();
        }
    }
}
