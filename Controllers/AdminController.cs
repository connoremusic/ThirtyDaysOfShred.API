using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ThirtyDaysOfShred.API.DTOs;
using ThirtyDaysOfShred.API.Entities.GuitarTabs;
using ThirtyDaysOfShred.API.Entities.Users;
using ThirtyDaysOfShred.API.Interfaces;

namespace ThirtyDaysOfShred.API.Controllers
{
    public class AdminController : BaseApiController
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IPhotoService _photoService;
        private readonly ITabService _tabService;

        public AdminController(UserManager<AppUser> userManager, IUnitOfWork unitOfWork, IMapper mapper, IPhotoService photoService, ITabService tabService)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _photoService = photoService;
            _tabService = tabService;
        }

        [Authorize(Policy = "RequireAdminRole")]
        [HttpGet("users-with-roles")]
        public async Task<ActionResult> GetUsersWithRoles()
        {
            var users = await _userManager.Users
                .Include(r => r.UserRoles)
                .ThenInclude(r => r.Role)
                .OrderBy(u => u.UserName)
                .Select(u => new
                {
                    u.Id,
                    Username = u.UserName,
                    Roles = u.UserRoles.Select(r => r.Role.Name).ToList()
                })
                .ToListAsync();

            return Ok(users);
        }

        [Authorize(Policy = "RequireAdminRole")]
        [HttpPost("edit-roles/{username}")]
        public async Task<ActionResult> EditRoles(string username, [FromQuery] string roles)
        {
            var selectedRoles = roles.Split(",").ToArray();

            var user = await _userManager.FindByNameAsync(username);

            if (user == null) return NotFound("Could not find user");

            var userRoles = await _userManager.GetRolesAsync(user);

            var result = await _userManager.AddToRolesAsync(user, selectedRoles.Except(userRoles));

            if (!result.Succeeded) return BadRequest("Failed to add to roles");

            result = await _userManager.RemoveFromRolesAsync(user, userRoles.Except(selectedRoles));

            if (!result.Succeeded) return BadRequest("Faile to remove from roles");

            return Ok(await _userManager.GetRolesAsync(user));
        }

        [Authorize(Policy = "ModerateTabRole")]
        [HttpGet("tabs-to-moderate")]
        public ActionResult GetTabsForModeration()
        {
            return Ok("Admins or moderators can see this");
        }

        [Authorize(Policy = "ModerateTabRole")]
        [HttpPost("add-new-tab")]
        public async Task<ActionResult> AddNewGuitarTab([FromBody]GuitarTabDto guitarTabDto)
        {
            if (guitarTabDto == null) return NotFound("Guitar Tab Cannot be Null");

            var guitarTab = _mapper.Map<GuitarTab>(guitarTabDto);

            var newGuitarTab = new GuitarTab
            {
                Title = guitarTab.Title,
                Description = guitarTab.Description,
                SkillLevel = guitarTab.SkillLevel,
                Author = guitarTab.Author,
                Created = DateTime.UtcNow,
                IsPublic = true,
                Tags = guitarTab.Tags
            };

            await _unitOfWork.GuitarTabRepository.AddNewGuitarTab(newGuitarTab);

            if (await _unitOfWork.Complete()) return Ok();

            return BadRequest("Tab could not be added");
        }

        [Authorize(Policy = "ModerateTabRole")]
        [HttpPut("edit-tab-file/{guitarTabId}")]
        public async Task<ActionResult> UpdateTabFile([FromForm]IFormFile file, int guitarTabId)
        {
            var guitarTab = await _unitOfWork.GuitarTabRepository.GetGuitarTabByIdAsync(guitarTabId);

            var result = await _tabService.AddFileAsync(file);
            if (result.Error != null) return BadRequest(result.Error.Message);

            guitarTab.FileLocationUrl = result.SecureUrl.AbsoluteUri;

            if (await _unitOfWork.Complete()) return NoContent();

            return BadRequest("Failed to update user");
        }

        [Authorize(Policy = "ModerateTabRole")]
        [HttpPut("edit-tab-preview/{guitarTabId}")]
        public async Task<ActionResult> UpdateTabPreview([FromForm]IFormFile file, int guitarTabId)
        {
            var guitarTab = await _unitOfWork.GuitarTabRepository.GetGuitarTabByIdAsync(guitarTabId);

            var result = await _tabService.AddFileAsync(file);
            if (result.Error != null) return BadRequest(result.Error.Message);

            var tabPhoto = new TabPreviewImage
            {
                Url = result.SecureUrl.AbsoluteUri,
                PublicId = result.PublicId
            };

            guitarTab.PreviewImage = tabPhoto;

            if (await _unitOfWork.Complete()) return NoContent();

            return BadRequest("Failed to update user");
        }
    }
}
