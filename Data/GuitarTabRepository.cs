using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using ThirtyDaysOfShred.API.DTOs;
using ThirtyDaysOfShred.API.Entities.GuitarTabs;
using ThirtyDaysOfShred.API.Interfaces;

namespace ThirtyDaysOfShred.API.Data
{
    public class GuitarTabRepository : IGuitarTabRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public GuitarTabRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GuitarTabDto>> GetGuitarTabDtosAsync()
        {
            return await _context.GuitarTabs.ProjectTo<GuitarTabDto>(_mapper.ConfigurationProvider).ToListAsync();
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
            return await _context.GuitarTabs
                .Include(x => x.Tags)
                .Include(x => x.PreviewImage)
                .ToListAsync();
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
