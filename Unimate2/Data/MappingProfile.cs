using AutoMapper;
using UniMate2.Models.Domain;
using UniMate2.Models.DTO;

namespace UniMate2.Data
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // User mappings
            CreateMap<User, UserDto>()
                .ForMember(
                    dest => dest.ProfileImagePath,
                    opt =>
                        opt.MapFrom(src =>
                            src.Images != null && src.Images.Any()
                                ? src.Images.OrderBy(i => i.SerialNumber).First().ImagePath
                                : null
                        )
                );

            CreateMap<UserDto, User>();
            CreateMap<User, UpdateUserDto>().ReverseMap();

            // UserImage mappings
            CreateMap<UserImage, UserImageDto>();
            CreateMap<UserImageDto, User>();

            // Other mappings
            CreateMap<FriendRequest, FriendRequestDto>()
                .ReverseMap();
            CreateMap<Event, EventDto>();
        }
    }
}
