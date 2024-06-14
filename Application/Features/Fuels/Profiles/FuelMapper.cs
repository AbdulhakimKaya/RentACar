using Application.Features.Brands.Commands.Update;
using Application.Features.Fuels.Commands.Create;
using Application.Features.Fuels.Commands.Delete;
using Application.Features.Fuels.Commands.Update;
using Application.Features.Fuels.Queries.GetById;
using Application.Features.Fuels.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Fuels.Profiles;

public class FuelMapper : Profile
{
    public FuelMapper()
    {
        CreateMap<Fuel, CreateFuelCommand>().ReverseMap();
        CreateMap<Fuel, CreateFuelResponse>().ReverseMap();
        
        CreateMap<Fuel, UpdateFuelCommand>().ReverseMap();
        CreateMap<Fuel, UpdatedFuelResponse>().ReverseMap();
        
        CreateMap<Fuel, DeleteFuelCommand>().ReverseMap();
        CreateMap<Fuel, DeletedFuelResponse>().ReverseMap();
        
        CreateMap<Fuel, GetListFuelListItemDto>().ReverseMap();

        CreateMap<Fuel, GetListFuelListItemDto>().ReverseMap();
        CreateMap<Fuel, GetByIdFuelResponse>().ReverseMap();
        CreateMap<Paginate<Fuel>, GetListResponse<GetListFuelListItemDto>>().ReverseMap();
    }
    
}