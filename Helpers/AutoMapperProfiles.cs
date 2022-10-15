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
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.DateOfBirth.CalculateAge()))
                .ForMember(dest => dest.ProfilePhoto, opt => opt.MapFrom(src => src.ProfilePhoto));
            CreateMap<Goal, GoalDto>();
            CreateMap<MemberUpdateDto, AppUser>();
            CreateMap<ProfilePhoto, ProfilePhotoDto>();
            CreateMap<TabPreviewImage, TabPreviewImageDto>();
            CreateMap<RegisterDto, AppUser>();
            CreateMap<GuitarTabTag, GuitarTabTagDto>();
            CreateMap<GuitarTab, GuitarTabDto>()
                .ForMember(dest => dest.PreviewImageUrl, opt => opt.MapFrom(src => src.PreviewImage.Url));
            CreateMap<GuitarTabFavorite, GuitarTabDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.GuitarTabId))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.GuitarTab.Title))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.GuitarTab.Description))
                .ForMember(dest => dest.SkillLevel, opt => opt.MapFrom(src => src.GuitarTab.SkillLevel))
                .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.GuitarTab.Author))
                .ForMember(dest => dest.IsPublic, opt => opt.MapFrom(src => src.GuitarTab.IsPublic))
                .ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.GuitarTab.Tags))
                .ForMember(dest => dest.FileLocationUrl, opt => opt.MapFrom(src => src.GuitarTab.FileLocationUrl))
                .ForMember(dest => dest.PreviewImageUrl, opt => opt.MapFrom(src => src.GuitarTab.PreviewImage.Url))
                .ForMember(dest => dest.NumberOfFavorites, opt => opt.MapFrom(src => src.GuitarTab.FavoritedByUser.Count));
            CreateMap<Message, MessageDto>()
                .ForMember(dest => dest.SenderPhotoUrl, opt => opt.MapFrom(src => src.Sender.ProfilePhoto.Url))
                .ForMember(dest => dest.RecipientPhotoUrl, opt => opt.MapFrom(src => src.Recipient.ProfilePhoto.Url));
            CreateMap<DateTime, DateTime>().ConvertUsing(d => DateTime.SpecifyKind(d, DateTimeKind.Utc));
        }
    }
}
