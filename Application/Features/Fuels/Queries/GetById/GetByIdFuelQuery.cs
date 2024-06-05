using Application.Services.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.Fuels.Queries.GetById;

public sealed record GetByIdFuelQuery(Guid Id) : IRequest<GetByIdQueryResponse> 
{
    
    
    
    public class  GetByIdQueryHandler : IRequestHandler<GetByIdFuelQuery,GetByIdQueryResponse>
    {

        private readonly IFuelRepository _fuelRepository;
        private readonly IMapper _mapper;

        public GetByIdQueryHandler(IFuelRepository fuelRepository, IMapper mapper)
        {
            _fuelRepository = fuelRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdQueryResponse> Handle(GetByIdFuelQuery request, CancellationToken cancellationToken)
        {
            var fuel = await _fuelRepository.GetAsync(predicate: x => x.Id == request.Id,
                cancellationToken: cancellationToken);


            var fuelResponse = _mapper.Map<GetByIdQueryResponse>(fuel);

            return fuelResponse;

        }
    }
    
}