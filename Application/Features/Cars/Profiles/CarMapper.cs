using Application.Features.Cars.Commands.Create;
using Application.Features.Cars.Queries.GetById;
using Application.Features.Cars.Queries.GetListNoPaginate;
using AutoMapper;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Dtos;
using Domain.Entities;

namespace Application.Features.Cars.Profiles;

public class CarMapper : Profile
{
    public CarMapper()
    {
        CreateMap<CreateCarCommand, Car>().ReverseMap();
        CreateMap<Car, CreateCarCommandResponse>().ReverseMap();
        CreateMap<Paginate<CarDetailDto>, GetListResponse<CarDetailDto>>();
        CreateMap<Car, GetListNoPaginateCarItemDto>()
            .ForMember(dest => dest.ImagesRoot, opt => opt.MapFrom(src => src.Images.Select(i => i.Root).ToList()))
            .ForMember(d => d.BrandName, opt => opt.MapFrom(s=> s.Model.Brand.Name))
            .ForMember(d => d.FuelName, opt => opt.MapFrom(s=> s.Model.Fuel.Name))
            .ForMember(d => d.TransmissionName, opt => opt.MapFrom(s=> s.Model.Transmission.Name))
            .ForMember(d=>d.ColorName, opt => opt.MapFrom(c=>c.Color.Name))
            .ReverseMap();
        
        
        CreateMap<Car, GetByIdCarQueryItemDto>()
            .ForMember(dest => dest.ImagesRoot, opt => opt.MapFrom(src => src.Images.Select(i => i.Root).ToList()))
            .ForMember(d => d.BrandName, opt => opt.MapFrom(s=> s.Model.Brand.Name))
            .ForMember(d => d.FuelName, opt => opt.MapFrom(s=> s.Model.Fuel.Name))
            .ForMember(d => d.TransmissionName, opt => opt.MapFrom(s=> s.Model.Transmission.Name))
            .ForMember(d=>d.ColorName, opt => opt.MapFrom(c=>c.Color.Name))
            .ReverseMap();
    }
}