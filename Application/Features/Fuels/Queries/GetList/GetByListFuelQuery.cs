using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using MediatR;

namespace Application.Features.Fuels.Queries.GetList;

public sealed class GetByListFuelQuery : IRequest<GetListResponse<GetByListFuelResponse>> , ICacheableRequest
{

    public PageRequest PageRequest { get; set; }

    public string CacheKey => $"GetListFuelQuery({PageRequest.PageIndex}, {PageRequest.PageSize})";
    public bool BypassCache => false;
    public string? CacheGroupKey => "GetFuels";
    public TimeSpan? SlidingExpiration { get; }
    
    
    public class GetByListFuelQueryHandler : IRequestHandler<GetByListFuelQuery,GetListResponse<GetByListFuelResponse>>
    {

        private readonly IFuelRepository _fuelRepository;
        private readonly IMapper _mapper;

        public GetByListFuelQueryHandler(IFuelRepository fuelRepository, IMapper mapper)
        {
            _fuelRepository = fuelRepository;
            _mapper = mapper;
        }
        
        

        public async Task<GetListResponse<GetByListFuelResponse>> Handle(GetByListFuelQuery request, CancellationToken cancellationToken)
        {
            var fuels = await _fuelRepository.GetListAsync(index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, cancellationToken: cancellationToken);


            GetListResponse<GetByListFuelResponse> response = _mapper.Map<GetListResponse<GetByListFuelResponse>>(fuels);

            return response;

        }
    }
    
}