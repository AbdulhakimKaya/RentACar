using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Sliders.Queries.GetListNoPaginate;

public class GetListNoPaginateSliderQuery : IRequest<List<GetListNoPaginateSliderResponse>>, ICacheableRequest
{
    public string CacheKey => "GetListSliderQuery";
    public bool BypassCache { get; }
    public string? CacheGroupKey => "GetSliders";
    public TimeSpan? SlidingExpiration { get; }
    
    public class GetListNoPaginateSliderQueryHandler : IRequestHandler<GetListNoPaginateSliderQuery, List<GetListNoPaginateSliderResponse>>
    {
        private readonly ISliderRepository _sliderRepository;
        private readonly IMapper _mapper;

        public GetListNoPaginateSliderQueryHandler(ISliderRepository sliderRepository, IMapper mapper)
        {
            _sliderRepository = sliderRepository;
            _mapper = mapper;
        }

        public async Task<List<GetListNoPaginateSliderResponse>> Handle(GetListNoPaginateSliderQuery request,
            CancellationToken cancellationToken)
        {
            var sliders = await _sliderRepository.Query().AsNoTracking()
                .ToListAsync(cancellationToken: cancellationToken);
            List<GetListNoPaginateSliderResponse> dtos = _mapper.Map<List<GetListNoPaginateSliderResponse>>(sliders);

            return dtos;
        }
    }
}