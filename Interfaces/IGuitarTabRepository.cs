using ThirtyDaysOfShred.API.DTOs;
using ThirtyDaysOfShred.API.Entities.GuitarTabs;
using ThirtyDaysOfShred.API.Helpers;

namespace ThirtyDaysOfShred.API.Interfaces
{
    public interface IGuitarTabRepository
    {
        void Update(GuitarTab guitarTab);
        Task<IEnumerable<GuitarTab>> GetGuitarTabsAsync();
        Task<GuitarTab> GetGuitarTabByIdAsync(int id);
        Task<IEnumerable<GuitarTab>> GetGuitarTabsByTitleAsync(string title);
        Task<IEnumerable<GuitarTab>> GetGuitarTabsByAuthorAsync(string author);
        Task<IEnumerable<GuitarTab>> GetGuitarTabsBySkillLevel(int skillLevel);
        Task<PagedList<GuitarTabDto>> GetGuitarTabDtosAsync(GuitarTabParams guitarTabParams);
        Task<GuitarTabDto> GetGuitarTabDtoAsync(int guitarTabId);
        Task<IEnumerable<GuitarTabDto>> GetUserGuitarTabDtosAsync(int userId);
        Task<int> GetFavoriteCountAsync(int guitarTabId);
    }
}
