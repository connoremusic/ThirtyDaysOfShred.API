using Microsoft.EntityFrameworkCore;
using ThirtyDaysOfShred.API.Data;
using ThirtyDaysOfShred.API.Helpers;
using ThirtyDaysOfShred.API.Interfaces;
using ThirtyDaysOfShred.API.Services;

namespace ThirtyDaysOfShred.API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.Configure<CloudinarySettings>(config.GetSection("CloudinarySettings"));
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IPhotoService, PhotoService>();
            services.AddScoped<LogUserActivity>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IGuitarTabRepository, GuitarTabRepository>();
            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            });

            return services;
        }
    }
}
