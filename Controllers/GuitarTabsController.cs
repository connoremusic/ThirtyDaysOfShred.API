using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ThirtyDaysOfShred.API.Data;
using ThirtyDaysOfShred.API.Entities.GuitarTabs;

namespace ThirtyDaysOfShred.API.Controllers
{
    [Authorize]
    public class GuitarTabsController : BaseApiController
    {
        private readonly DataContext _context;

        public GuitarTabsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GuitarTab>>> GetTabsAsync()
        {
            return await _context.GuitarTabs.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GuitarTab>> GetTabAsync(int id)
        {
            return await _context.GuitarTabs.FindAsync(id);
        }
    }
}
