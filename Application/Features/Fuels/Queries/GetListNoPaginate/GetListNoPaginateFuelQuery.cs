using Application.Features.Fuels.Queries.GetList;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Fuels.Queries.GetListNoPaginate;

public class GetListNoPaginateFuelQuery: IRequest<List<GetListFuelListItemDto>>, ICacheableRequest
{
    public string CacheKey => "GetListFuelQuery";
    public bool BypassCache => false;
    public string? CacheGroupKey => "GetFuels";
    public TimeSpan? SlidingExpiration { get; }
    
    public class GetListNoPaginateFuelQueryHandler : IRequestHandler<GetListNoPaginateFuelQuery,List<GetListFuelListItemDto>>
    {
        private readonly IFuelRepository _fuelRepository;
        private readonly IMapper _mapper;

        public GetListNoPaginateFuelQueryHandler(IFuelRepository fuelRepository, IMapper mapper)
        {
            _fuelRepository = fuelRepository;
            _mapper = mapper;
        }

        public async Task<List<GetListFuelListItemDto>> Handle(GetListNoPaginateFuelQuery request, CancellationToken cancellationToken)
        {
            var fuels = await _fuelRepository.Query().AsNoTracking().ToListAsync(cancellationToken: cancellationToken);
            List<GetListFuelListItemDto> dtos = _mapper.Map<List<GetListFuelListItemDto>>(fuels);

            return dtos;
        }
    }
}