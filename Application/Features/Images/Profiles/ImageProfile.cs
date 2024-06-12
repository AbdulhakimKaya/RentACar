using Application.Features.Images.Commands.Create;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Images.Profiles;

public class ImageProfile : Profile
{

    public ImageProfile()
    {
        CreateMap<CreateImageCommand, Image>();
        CreateMap<Image, CreateImageCommandResponse>();
    }
}