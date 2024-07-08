using Application.Features.Auth.Commands.Delete;
using Application.Features.Users.Commands.Create;
using Application.Features.Users.Commands.Update;
using Application.Features.Users.Queries.GetListNoPaginate;
using AutoMapper;
using Core.Security.Entities;

namespace Application.Features.Users.Profiles;

public class MappingProfiles:Profile
{
    public MappingProfiles()
    {
        CreateMap<User, CreateUserCommand>().ReverseMap();
        CreateMap<User, CreatedUserResponse>().ReverseMap();
        
        CreateMap<User, DeleteUserCommand>().ReverseMap();
        CreateMap<User, DeletedUserResponse>().ReverseMap();
        
        CreateMap<User, UpdateUserResponseDto>();
        CreateMap<User, GetListNoPaginateUserItemDto>();

    }
}