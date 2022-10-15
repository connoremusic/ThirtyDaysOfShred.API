using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ThirtyDaysOfShred.API.Data;
using ThirtyDaysOfShred.API.Entities.GuitarTabs;
using ThirtyDaysOfShred.API.Interfaces;
using ThirtyDaysOfShred.API.Helpers;
using ThirtyDaysOfShred.API.Extensions;
using ThirtyDaysOfShred.API.DTOs;

namespace ThirtyDaysOfShred.API.Controllers
{
    [Authorize]
    public class GuitarTabsController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly DataContext _context;

        public GuitarTabsController(IUnitOfWork unitOfWork, DataContext context)
        {
            _unitOfWork = unitOfWork;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GuitarTabDto>>> GetTabsAsync([FromQuery]GuitarTabParams guitarTabParams)
        {
            var tabs = await _unitOfWork.GuitarTabRepository.GetGuitarTabDtosAsync(guitarTabParams);

            Response.AddPaginationHeader(tabs.CurrentPage, tabs.PageSize, tabs.TotalCount, tabs.TotalPages);
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
            var guitarTab = await _unitOfWork.GuitarTabRepository.GetGuitarTabByIdAsync(guitarTabId);
            if (guitarTab == null) return NotFound();

            var user = await _unitOfWork.UserRepository.GetUserByUsernameAsync(User.GetUsername());

            var guitarTabFavorite = await _unitOfWork.UserRepository.UserHasFavorite(user.Id, guitarTabId);
            if (guitarTabFavorite != null) return BadRequest("You already favorited this tab");

            guitarTabFavorite = new GuitarTabFavorite
            {
                GuitarTab = guitarTab,
                GuitarTabId = guitarTab.Id,
                AppUser = user,
                AppUserId = user.Id
            };

            user.FavoriteTabs.Add(guitarTabFavorite);

            if (await _unitOfWork.Complete()) return Ok();

            return BadRequest("Failed to add to favorites");
        }
    }
}
