using ThirtyDaysOfShred.API.Entities.Users;

namespace ThirtyDaysOfShred.API.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}
