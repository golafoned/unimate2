using AutoMapper;
using UniMate2.Models.Domain;
using UniMate2.Models.DTO;

namespace Server.Data;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserDto>().ReverseMap();
        CreateMap<FriendRequest, FriendRequestDto>().ReverseMap();
        CreateMap<UserImage, UserImageDto>().ReverseMap();
        CreateMap<UpdateUserDto, User>().ReverseMap();
        CreateMap<Event, EventDto>();
    }
}
