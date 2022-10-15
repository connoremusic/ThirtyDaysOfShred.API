using ThirtyDaysOfShred.API.DTOs;
using ThirtyDaysOfShred.API.Entities.GuitarTabs;
using ThirtyDaysOfShred.API.Entities.Users;
using ThirtyDaysOfShred.API.Helpers;

namespace ThirtyDaysOfShred.API.Interfaces
{
    public interface IUserRepository
    {
        void Update(AppUser user);
        Task<IEnumerable<AppUser>> GetUsersAsync();
        Task<AppUser> GetUserByIdAsync(int id);
        Task<AppUser> GetUserByUsernameAsync(string username);
        Task<PagedList<MemberDto>> GetMembersAsync(UserParams userParams);
        Task<MemberDto> GetMemberAsync(string username);
        Task<bool> UpdateProfilePhoto(ProfilePhoto photo);
        Task<bool> LikeGuitarTabAsync(GuitarTab guitarTab);
        Task<GuitarTabFavorite> UserHasFavorite(int userId, int guitarTabId);
    }
}
