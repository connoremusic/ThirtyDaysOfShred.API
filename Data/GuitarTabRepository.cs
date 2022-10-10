﻿using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using ThirtyDaysOfShred.API.DTOs;
using ThirtyDaysOfShred.API.Entities.GuitarTabs;
using ThirtyDaysOfShred.API.Helpers;
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

        public async Task<PagedList<GuitarTabDto>> GetGuitarTabDtosAsync(GuitarTabParams guitarTabParams)
        {
            var query = _context.GuitarTabs.AsQueryable();


            if (guitarTabParams.SearchString != null)
            {
            string[] tags = guitarTabParams.SearchString.Split(" ");

                foreach (var tag in tags)
                {
                    query = query.Where(t => t.Tags.Any(t => t.TagName.Contains(tag)) || t.Title.Contains(guitarTabParams.SearchString));
                }
            }
            
            query = query.Where(t => t.SkillLevel <= guitarTabParams.MaxSkillLevel && t.SkillLevel >= guitarTabParams.MinSkillLevel);

            query = guitarTabParams.OrderBy switch
            {
                "created" => query.OrderByDescending(t => t.Created),
                "popular" => query.OrderByDescending(t => t.NumberOfFavorites),
                _ => query.OrderByDescending(t => t.Title)
            };

            return await PagedList<GuitarTabDto>.CreateAsync(query.ProjectTo<GuitarTabDto>(_mapper
                .ConfigurationProvider).AsNoTracking(), guitarTabParams.PageNumber, guitarTabParams.PageSize);
        }

        public async Task<GuitarTabDto> GetGuitarTabDtoAsync(int guitarTabId)
        {
            return await _context.GuitarTabs.Where(x => x.Id == guitarTabId).ProjectTo<GuitarTabDto>(_mapper.ConfigurationProvider).SingleOrDefaultAsync();
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
            return await _context.GuitarTabs
                .Where(x => x.SkillLevel == skillLevel)
                .ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(GuitarTab guitarTab)
        {
            _context.Entry(guitarTab).State = EntityState.Modified;
        }

        public async Task<IEnumerable<GuitarTabDto>> GetUserGuitarTabDtosAsync(int userId)
        {
            return await _context.GuitarTabs
                .Include(x => x.FavoritedByUser)
                .Where(x => x.Equals(userId)).ProjectTo<GuitarTabDto>(_mapper.ConfigurationProvider).ToListAsync();
        }
    }
}
