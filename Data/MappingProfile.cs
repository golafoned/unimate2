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
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, UpdateUserDto>().ReverseMap();
            
            // Friend request mappings
            CreateMap<FriendRequest, FriendRequestDto>().ReverseMap();
            
            // Other mappings
            CreateMap<UserImage, UserImageDto>().ReverseMap();
            CreateMap<Event, EventDto>();
        }
    }
}
