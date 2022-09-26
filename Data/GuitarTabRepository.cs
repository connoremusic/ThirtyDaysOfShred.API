using System.Linq;
using Microsoft.EntityFrameworkCore;
using ThirtyDaysOfShred.API.Entities.GuitarTabs;
using ThirtyDaysOfShred.API.Interfaces;

namespace ThirtyDaysOfShred.API.Data
{
    public class GuitarTabRepository : IGuitarTabRepository
    {
        private readonly DataContext _context;

        public GuitarTabRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GuitarTab>> GetGuitarTabsByAuthorAsync(string author)
        {
            return await _context.GuitarTabs.Where(x => x.Author == author).ToListAsync();
        }

        public async Task<GuitarTab> GetGuitarTabByIdAsync(int id)
        {
            return await _context.GuitarTabs.FindAsync(id);
        }

        public async Task<IEnumerable<GuitarTab>> GetGuitarTabsByTitleAsync(string title)
        {
            return await _context.GuitarTabs.Where(x => x.Title.Contains(title)).ToListAsync();
        }

        public async Task<IEnumerable<GuitarTab>> GetGuitarTabsAsync()
        {
            return await _context.GuitarTabs.ToListAsync();
        }

        public async Task<IEnumerable<GuitarTab>> GetGuitarTabsBySkillLevel(int skillLevel)
        {
            return await _context.GuitarTabs.ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(GuitarTab guitarTab)
        {
            _context.Entry(guitarTab).State = EntityState.Modified;
        }
    }
}
