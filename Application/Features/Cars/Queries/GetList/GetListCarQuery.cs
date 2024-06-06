using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Domain.Dtos;
using MediatR;

namespace Application.Features.Cars.Queries.GetList;

public class GetListCarQuery  //: IRequest<GetListResponse<CarDetailDto>>, ICacheableRequest
{

    // public PageRequest PageRequest { get; set; }
    // public string CacheKey => $"GetListCarQuery({PageRequest.PageIndex}, {PageRequest.PageSize})";
    // public bool BypassCache => false;
    // public string? CacheGroupKey => "GetCars";
    // public TimeSpan? SlidingExpiration { get; }
    //
    //
    //
    // public class GetListCarQueryHandler : IRequestHandler<GetListCarQuery, GetListResponse<CarDetailDto>>
    // {
    //     private readonly ICarRepository _carRepository;
    //     private readonly IMapper _mapper;
    //
    //     public GetListCarQueryHandler(ICarRepository carRepository, IMapper mapper)
    //     {
    //         _carRepository = carRepository;
    //         _mapper = mapper;
    //     }
    //     
    //     
    //
    //     public async Task<GetListResponse<CarDetailDto>> Handle(GetListCarQuery request, CancellationToken cancellationToken)
    //     {
    //         var datas = await _carRepository.GetAllDetails(request.PageRequest.PageIndex, request.PageRequest.PageSize);
    //
    //         var response = _mapper.Map<GetListResponse<CarDetailDto>>(datas);
    //
    //         return response;
    //     }
    // }
    
}