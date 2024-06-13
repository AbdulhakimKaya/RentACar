using Application.Features.Brands.Commands.Delete;
using Application.Features.Colors.Commands.Create;
using Application.Features.Colors.Commands.Delete;
using Application.Features.Colors.Commands.Update;
using Application.Features.Colors.Queries.GetList;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Colors.Profiles;

public class MappingProfiles: Profile
{
    public MappingProfiles()
    {
        CreateMap<Color, CreateColorCommand>().ReverseMap();
        CreateMap<Color, CreatedColorResponse>().ReverseMap();
        
        CreateMap<Color, UpdateColorCommand>().ReverseMap();
        CreateMap<Color, UpdatedColorResponse>().ReverseMap();
        
        CreateMap<Color, DeleteColorCommand>().ReverseMap();
        CreateMap<Color, DeletedColorResponse>().ReverseMap();
        
        CreateMap<Color, GetListColorListItemDto>().ReverseMap();
    }
}