using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Fuels.Queries.GetById;

public sealed record GetByIdFuelQuery : IRequest<GetByIdFuelResponse> 
{
    public Guid Id { get; set; }
    
    public class  GetByIdQueryHandler : IRequestHandler<GetByIdFuelQuery,GetByIdFuelResponse>
    {

        private readonly IFuelRepository _fuelRepository;
        private readonly IMapper _mapper;

        public GetByIdQueryHandler(IFuelRepository fuelRepository, IMapper mapper)
        {
            _fuelRepository = fuelRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdFuelResponse> Handle(GetByIdFuelQuery request, CancellationToken cancellationToken)
        {
            Fuel? fuel = await _fuelRepository.GetAsync(predicate: f => f.Id == request.Id, withDeleted:true,
                cancellationToken: cancellationToken);


            GetByIdFuelResponse response = _mapper.Map<GetByIdFuelResponse>(fuel);

            return response;

        }
    }
    
}