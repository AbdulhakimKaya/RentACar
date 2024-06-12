using Application.Services.Repositories;
using Core.Application.Pipelines.Caching;
using Domain.Dtos;
using MediatR;

namespace Application.Features.Cars.Queries.GetListNoPaginate;

public class GetListNoPaginateQuery : IRequest<List<CarDetailDto>> , ICacheableRequest
{

    public string CacheKey => "GetListCarQuery";
    public bool BypassCache => false;
    public string? CacheGroupKey => "GetCars";
    public TimeSpan? SlidingExpiration { get; }
    
    
    
    
    public class GetListNoPaginateQueryHandler : IRequestHandler<GetListNoPaginateQuery,List<CarDetailDto>>
    {

        private readonly ICarRepository _carRepository;

        public GetListNoPaginateQueryHandler(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<List<CarDetailDto>> Handle(GetListNoPaginateQuery request, CancellationToken cancellationToken)
        {
            var result = await _carRepository.GetDetailsNoPaginate();
            return result;
        }
    }
    
    
}