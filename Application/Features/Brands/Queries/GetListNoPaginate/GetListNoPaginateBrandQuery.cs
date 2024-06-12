using Application.Features.Brands.Queries.GetList;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Brands.Queries.GetListNoPaginate;

public class GetListNoPaginateBrandQuery  : IRequest<List<GetListBrandListItemDto>> , ICacheableRequest
{
    public string CacheKey => "GetListBrandQuery";
    public bool BypassCache => false;
    public string? CacheGroupKey => "GetBrands";
    public TimeSpan? SlidingExpiration { get; }
    
    
    public class GetListNoPaginateBrandQueryHandler : IRequestHandler<GetListNoPaginateBrandQuery,List<GetListBrandListItemDto>>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;

        public GetListNoPaginateBrandQueryHandler(IBrandRepository brandRepository, IMapper mapper)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
        }

        public async Task<List<GetListBrandListItemDto>> Handle(GetListNoPaginateBrandQuery request, CancellationToken cancellationToken)
        {

            var brands = await _brandRepository.Query().AsNoTracking().ToListAsync(cancellationToken: cancellationToken);
            List<GetListBrandListItemDto> dtos = _mapper.Map<List<GetListBrandListItemDto>>(brands);

            return dtos;


        }
    }
    
}