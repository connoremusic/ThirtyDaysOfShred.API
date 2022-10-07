using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ThirtyDaysOfShred.API.Data;
using ThirtyDaysOfShred.API.Entities.GuitarTabs;
using ThirtyDaysOfShred.API.Interfaces;
using ThirtyDaysOfShred.API.Helpers;

namespace ThirtyDaysOfShred.API.Controllers
{
    [Authorize]
    public class GuitarTabsController : BaseApiController
    {
        private readonly IGuitarTabRepository _guitarTabRepository;
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public GuitarTabsController(IGuitarTabRepository guitarTabRepository, IMapper mapper, DataContext context)
        {
            _guitarTabRepository = guitarTabRepository;
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GuitarTab>>> GetTabsAsync()
        {
            var tabs = await _guitarTabRepository.GetGuitarTabDtosAsync();
            return Ok(tabs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GuitarTab>> GetTabAsync(int id)
        {
            return await _context.GuitarTabs.FindAsync(id);
        }
    }
}
