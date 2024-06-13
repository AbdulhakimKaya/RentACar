using Application.Features.Transmissions.Queries.GetList;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Transmissions.Queries.GetListNoPaginate;

public class GetListNoPaginateTransmissionQuery: IRequest<List<GetListTransmissionListItemDto>>, ICacheableRequest
{
    public string CacheKey => "GetListTransmissionQuery";
    public bool BypassCache => false;
    public string? CacheGroupKey => "GetTransmissions";
    public TimeSpan? SlidingExpiration { get; }
    
    public class GetListNoPaginateTransmissionQueryHandler : IRequestHandler<GetListNoPaginateTransmissionQuery,List<GetListTransmissionListItemDto>>
    {
        private readonly ITransmissionRepository _transmissionRepository;
        private readonly IMapper _mapper;

        public GetListNoPaginateTransmissionQueryHandler(ITransmissionRepository transmissionRepository, IMapper mapper)
        {
            _transmissionRepository = transmissionRepository;
            _mapper = mapper;
        }

        public async Task<List<GetListTransmissionListItemDto>> Handle(GetListNoPaginateTransmissionQuery request, CancellationToken cancellationToken)
        {
            var transmissions = await _transmissionRepository.Query().AsNoTracking().ToListAsync(cancellationToken: cancellationToken);
            List<GetListTransmissionListItemDto> dtos = _mapper.Map<List<GetListTransmissionListItemDto>>(transmissions);

            return dtos;
        }
    }
}