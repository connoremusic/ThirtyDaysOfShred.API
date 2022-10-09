using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ThirtyDaysOfShred.API.Data;
using ThirtyDaysOfShred.API.Entities.GuitarTabs;
using ThirtyDaysOfShred.API.Interfaces;
using ThirtyDaysOfShred.API.Helpers;
using ThirtyDaysOfShred.API.Extensions;

namespace ThirtyDaysOfShred.API.Controllers
{
    [Authorize]
    public class GuitarTabsController : BaseApiController
    {
        private readonly IGuitarTabRepository _guitarTabRepository;
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly IUserRepository _userRepository;

        public GuitarTabsController(IGuitarTabRepository guitarTabRepository, IMapper mapper, DataContext context, IUserRepository userRepository)
        {
            _guitarTabRepository = guitarTabRepository;
            _mapper = mapper;
            _context = context;
            _userRepository = userRepository;
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

        [HttpPost("{guitarTabId}")]
        public async Task<ActionResult> AddFavoriteTab(int guitarTabId)
        {
            var guitarTab = await _guitarTabRepository.GetGuitarTabByIdAsync(guitarTabId);
            if (guitarTab == null) return NotFound();

            var user = await _userRepository.GetUserByUsernameAsync(User.GetUsername());

            var guitarTabFavorite = await _userRepository.UserHasFavorite(user.Id, guitarTabId);
            if (guitarTabFavorite != null) return BadRequest("You already favorited this tab");

            guitarTabFavorite = new GuitarTabFavorite
            {
                GuitarTab = guitarTab,
                GuitarTabId = guitarTab.Id,
                AppUser = user,
                AppUserId = user.Id
            };

            user.FavoriteTabs.Add(guitarTabFavorite);

            if (await _userRepository.SaveAllAsync()) return Ok();

            return BadRequest("Failed to add to favorites");
        }
    }
}
