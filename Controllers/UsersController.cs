using System.Linq;
using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ThirtyDaysOfShred.API.Data;
using ThirtyDaysOfShred.API.DTOs;
using ThirtyDaysOfShred.API.Entities.GuitarTabs;
using ThirtyDaysOfShred.API.Entities.Users;
using ThirtyDaysOfShred.API.Extensions;
using ThirtyDaysOfShred.API.Helpers;
using ThirtyDaysOfShred.API.Interfaces;

namespace ThirtyDaysOfShred.API.Controllers
{
    [Authorize]
    public class UsersController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IPhotoService _photoService;

        public UsersController(IUnitOfWork unitOfWork, IMapper mapper, IPhotoService photoService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _photoService = photoService;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsersAsync([FromQuery]UserParams userParams)
        {
            var user = await _unitOfWork.UserRepository.GetUserByUsernameAsync(User.GetUsername());
            userParams.CurrentUserName = User.GetUsername();

            if (string.IsNullOrEmpty(userParams.Gender))
                userParams.Gender = user.Gender == "male" ? "female" : "male";

            var users = await _unitOfWork.UserRepository.GetMembersAsync(userParams);

            Response.AddPaginationHeader(users.CurrentPage, users.PageSize, users.TotalCount, users.TotalPages);

            return Ok(users);
        }
        
        [HttpGet("{username}", Name = "GetUser")]
        public async Task<ActionResult<MemberDto>> GetUserAsync(string username)
        {
            return await _unitOfWork.UserRepository.GetMemberAsync(username);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateUser(MemberUpdateDto memberUpdateDto)
        {
            var user = await _unitOfWork.UserRepository.GetUserByUsernameAsync(User.GetUsername());

            _mapper.Map(memberUpdateDto, user);

            _unitOfWork.UserRepository.Update(user);

            if (await _unitOfWork.Complete()) return NoContent();

            return BadRequest("Failed to update user");
        }

        [HttpPost("add-photo")]
        public async Task<ActionResult<ProfilePhotoDto>> UpdateProfilePhoto([FromForm]IFormFile file)
        {
            var user =  await _unitOfWork.UserRepository.GetUserByUsernameAsync(User.GetUsername());

            var result = await _photoService.AddPhotoAsync(file);

            if (result.Error != null) return BadRequest(result.Error.Message);

            var photo = new ProfilePhoto
            {
                //Id = user.Id,
                Url = result.SecureUrl.AbsoluteUri,
                //AppUser = user,
                PublicId = result.PublicId,
                //AppUserId = user.Id
            };

            if (user.ProfilePhoto != null)
            {
            await DeletePhoto(user.ProfilePhoto.Id);
            }

            user.ProfilePhoto = photo;

            if (await _unitOfWork.Complete())
            {
                return CreatedAtRoute("GetUser", new {username = user.UserName}, _mapper.Map<ProfilePhotoDto>(user.ProfilePhoto));
                //return _mapper.Map<ProfilePhotoDto>(user.ProfilePhoto);
            }

            return BadRequest("Problem adding photo");
        }

        [HttpDelete("delete-photo/{photoId}")]
        public async Task<ActionResult> DeletePhoto(int photoId)
        {
            var user = await _unitOfWork.UserRepository.GetUserByUsernameAsync(User.GetUsername());

            var photo = user.ProfilePhoto;

            if (photo == null) return NotFound();

            if (photo.PublicId != null)
            {
                var result = await _photoService.DeletePhotoAsync(photo.PublicId);
                if (result.Error != null) return BadRequest(result.Error.Message);
            }

            user.ProfilePhoto = null;

            if (await _unitOfWork.Complete()) return Ok();

            return BadRequest("Failed to delete the photo");
        }

        [HttpGet("favorite-tabs/{username}")]
        public async Task<ActionResult<IEnumerable<GuitarTab>>> GetUserFavTabsAsync(int userId)
        {
            var tabs = await _unitOfWork.GuitarTabRepository.GetUserGuitarTabDtosAsync(userId);
            return Ok(tabs);
        }     
    }
}
