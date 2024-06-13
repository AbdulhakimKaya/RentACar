using Application.Features.Brands.Queries.GetList;
using Application.Features.Colors.Queries.GetList;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Colors.Queries.GetListNoPaginate;

public class GetListNoPaginateColorQuery: IRequest<List<GetListColorListItemDto>>, ICacheableRequest
{
    public string CacheKey => "GetListColorQuery";
    public bool BypassCache => false;
    public string? CacheGroupKey => "GetColors";
    public TimeSpan? SlidingExpiration { get; }
    
    public class GetListNoPaginateColorQueryHandler : IRequestHandler<GetListNoPaginateColorQuery,List<GetListColorListItemDto>>
    {
        private readonly IColorRepository _colorRepository;
        private readonly IMapper _mapper;

        public GetListNoPaginateColorQueryHandler(IColorRepository colorRepository, IMapper mapper)
        {
            _colorRepository = colorRepository;
            _mapper = mapper;
        }

        public async Task<List<GetListColorListItemDto>> Handle(GetListNoPaginateColorQuery request, CancellationToken cancellationToken)
        {

            var colors = await _colorRepository.Query().AsNoTracking().ToListAsync(cancellationToken: cancellationToken);
            List<GetListColorListItemDto> dtos = _mapper.Map<List<GetListColorListItemDto>>(colors);

            return dtos;


        }
    }
}