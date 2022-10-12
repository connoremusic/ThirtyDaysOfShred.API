using ThirtyDaysOfShred.API.Entities.Users;

namespace ThirtyDaysOfShred.API.Interfaces
{
    public interface ITokenService
    {
        Task<string> CreateToken(AppUser user);
    }
}
