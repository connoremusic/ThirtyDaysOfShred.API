using AutoMapper;
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
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.DateOfBirth.CalculateAge()));
            CreateMap<AuthoredTabs, AuthoredTabsDto>();
            CreateMap<FavoritedTabs, FavoritedTabsDto>();
            CreateMap<LikedTabs, LikedTabsDto>();
            CreateMap<MemberUpdateDto, AppUser>();
        }
    }
}
