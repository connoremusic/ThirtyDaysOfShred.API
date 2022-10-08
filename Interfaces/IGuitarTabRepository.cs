using ThirtyDaysOfShred.API.DTOs;
using ThirtyDaysOfShred.API.Entities.GuitarTabs;

namespace ThirtyDaysOfShred.API.Interfaces
{
    public interface IGuitarTabRepository
    {
        void Update(GuitarTab guitarTab);
        Task<bool> SaveAllAsync();
        Task<IEnumerable<GuitarTab>> GetGuitarTabsAsync();
        Task<GuitarTab> GetGuitarTabByIdAsync(int id);
        Task<IEnumerable<GuitarTab>> GetGuitarTabsByTitleAsync(string title);
        Task<IEnumerable<GuitarTab>> GetGuitarTabsByAuthorAsync(string author);
        Task<IEnumerable<GuitarTab>> GetGuitarTabsBySkillLevel(int skillLevel);
        Task<IEnumerable<GuitarTabDto>> GetGuitarTabDtosAsync();
        Task<GuitarTabDto> GetGuitarTabDtoAsync(int guitarTabId);
    }
}
