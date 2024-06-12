using Application.Features.Cars.Commands.Create;
using AutoMapper;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Dtos;
using Domain.Entities;

namespace Application.Features.Cars.Profiles;

public class CarMapper: Profile
{
    public CarMapper()
    {
        CreateMap<CreateCarCommand, Car>().ReverseMap();
        CreateMap<Car, CreateCarCommandResponse>().ReverseMap();
        CreateMap<Paginate<CarDetailDto>, GetListResponse<CarDetailDto>>();
    }
}