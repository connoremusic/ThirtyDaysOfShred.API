﻿using AutoMapper;
using ThirtyDaysOfShred.API.DTOs;
using ThirtyDaysOfShred.API.Entities.GuitarTabs;
using ThirtyDaysOfShred.API.Entities.Users;
using ThirtyDaysOfShred.API.Extensions;

namespace ThirtyDaysOfShred.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AppUser, MemberDto>()
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.DateOfBirth.CalculateAge()))
                .ForMember(dest => dest.ProfilePhoto, opt => opt.MapFrom(src => src.ProfilePhoto));
            CreateMap<Goal, GoalDto>();
            CreateMap<AuthoredTab, AuthoredTabDto>();
            CreateMap<FavoritedTab, FavoritedTabDto>();
            CreateMap<LikedTab, LikedTabDto>();
            CreateMap<MemberUpdateDto, AppUser>();
            CreateMap<ProfilePhoto, ProfilePhotoDto>();
            CreateMap<TabPreviewImage, TabPreviewImageDto>();
            CreateMap<RegisterDto, AppUser>();
        }
    }
}
