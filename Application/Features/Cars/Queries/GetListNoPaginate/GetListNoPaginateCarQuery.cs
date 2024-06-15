using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Domain.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Cars.Queries.GetListNoPaginate;

public class GetListNoPaginateCarQuery : IRequest<List<GetListNoPaginateCarItemDto>> , ICacheableRequest
{

    public string CacheKey => "GetListCarQuery";
    public bool BypassCache => false;
    public string? CacheGroupKey => "GetCars";
    public TimeSpan? SlidingExpiration { get; }
    
    
    public class GetListNoPaginateQueryHandler : IRequestHandler<GetListNoPaginateCarQuery,List<GetListNoPaginateCarItemDto>>
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;

        public GetListNoPaginateQueryHandler(ICarRepository carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }


        public async Task<List<GetListNoPaginateCarItemDto>> Handle(GetListNoPaginateCarQuery request, CancellationToken cancellationToken)
        {

            var cars = await _carRepository.Query()
                .Include(c => c.Images)
                .Include(c => c.Model)
                .Include(c => c.Model.Transmission)
                .Include(c => c.Model.Fuel)
                .Include(c => c.Model.Brand)
                .Include(c=>c.Color)
                .AsNoTracking()
                .ToListAsync(cancellationToken);
            
            var response = _mapper.Map<List<GetListNoPaginateCarItemDto>>(cars);

            return response;


        }
    }
    
    
    
}