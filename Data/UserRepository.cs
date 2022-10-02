﻿using Microsoft.EntityFrameworkCore;
using ThirtyDaysOfShred.API.DTOs;
using ThirtyDaysOfShred.API.Entities.Users;
using ThirtyDaysOfShred.API.Interfaces;
using AutoMapper.QueryableExtensions;
using AutoMapper;

namespace ThirtyDaysOfShred.API.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public UserRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<MemberDto> GetMemberAsync(string username)
        {
            return await _context.Users
                .Where(x => x.UserName == username)
                .ProjectTo<MemberDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<MemberDto>> GetMembersAsync()
        {
            return await _context.Users
                .ProjectTo<MemberDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<AppUser> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<AppUser> GetUserByUsernameAsync(string username)
        {
            return await _context.Users
                .Include(p => p.ProfilePhoto)
                .Include(x => x.PracticeRoutines)
                .Include(x => x.FavoriteTabs)
                .Include(x => x.LikedTabs)
                .SingleOrDefaultAsync(x => x.UserName == username);
        }

        public async Task<IEnumerable<AppUser>> GetUsersAsync()
        {
            return await _context.Users
                .Include(x => x.PracticeRoutines)
                .Include(x => x.FavoriteTabs)
                .Include(x => x.LikedTabs)
                .ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateProfilePhoto(ProfilePhoto photo)
        {
            _context.Entry(photo).State = EntityState.Modified;

            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(AppUser user)
        {
            _context.Entry(user).State = EntityState.Modified;
        }
    }
}
