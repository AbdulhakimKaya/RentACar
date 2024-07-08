using Application.Features.Sliders.Commands.Create;
using Application.Features.Sliders.Commands.Delete;
using Application.Features.Sliders.Queries.GetListNoPaginate;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Sliders.Profiles;

public class Mapping : Profile
{
    public Mapping()
    {
        CreateMap<CreateSliderCommand, Slider>().ReverseMap();
        CreateMap<Slider, CreateSliderCommandResponse>().ReverseMap();
        
        CreateMap<Slider, DeleteSliderCommand>().ReverseMap();
        CreateMap<Slider, DeletedSliderResponse>().ReverseMap();
        
        CreateMap<Slider, GetListNoPaginateSliderResponse>().ReverseMap();
    }
}