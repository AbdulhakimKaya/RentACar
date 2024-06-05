using Application.Features.Fuels.Commands.Create;
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
        CreateMap<CreateFuelCommand, Fuel>().ReverseMap();
        CreateMap<Fuel, CreateFuelResponse>().ReverseMap();


        CreateMap<Fuel, GetByListFuelResponse>().ReverseMap();

        CreateMap<Fuel, GetByIdQueryResponse>().ReverseMap();
        CreateMap<Paginate<Fuel>, GetListResponse<GetByListFuelResponse>>().ReverseMap();
    }
    
}