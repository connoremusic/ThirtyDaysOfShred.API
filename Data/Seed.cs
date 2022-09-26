using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using ThirtyDaysOfShred.API.Entities.GuitarTabs;
using ThirtyDaysOfShred.API.Entities.Users;

namespace ThirtyDaysOfShred.API.Data
{
    public class Seed
    {
        public static async Task SeedUsers(DataContext context)
        {
            if (await context.Users.AnyAsync()) return;

            var userData = await File.ReadAllTextAsync("Data/UserSeedData.json");
            var users = JsonSerializer.Deserialize<List<AppUser>>(userData);

            foreach (var user in users)
            {
                using var hmac = new HMACSHA512();

                user.UserName = user.UserName.ToLower();
                user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Pa$$w0rd"));
                user.PasswordSalt = hmac.Key;

                context.Users.Add(user);
            }

            await context.SaveChangesAsync();
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
