using Application.Features.Models.Queries.GetList;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Models.Queries.GetListNoPaginate;

public class GetListNoPaginateModelQuery : IRequest<List<GetListNoPaginateModelListItemDto>>, ICacheableRequest
{
    public string CacheKey => "GetListModelQuery";
    public bool BypassCache => false;
    public string? CacheGroupKey => "GetModels";
    public TimeSpan? SlidingExpiration { get; }
    
    public class GetListNoPaginateModelQueryHandler : IRequestHandler<GetListNoPaginateModelQuery,List<GetListNoPaginateModelListItemDto>>
    {
        private readonly IModelRepository _modelRepository;
        private readonly IMapper _mapper;

        public GetListNoPaginateModelQueryHandler(IModelRepository modelRepository, IMapper mapper)
        {
            _modelRepository = modelRepository;
            _mapper = mapper;
        }

        public async Task<List<GetListNoPaginateModelListItemDto>> Handle(GetListNoPaginateModelQuery request, CancellationToken cancellationToken)
        {
            var models = await _modelRepository.Query()
                .Include(x=>x.Brand)
                .Include(x=> x.Transmission)
                .Include(x=>x.Fuel)
                
                .AsNoTracking().ToListAsync(cancellationToken: cancellationToken);
            List<GetListNoPaginateModelListItemDto> dtos = _mapper.Map<List<GetListNoPaginateModelListItemDto>>(models);

            return dtos;
        }
    }
}