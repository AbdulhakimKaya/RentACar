using Application.Features.Fuels.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using Domain.Entities;
using MediatR;

namespace Application.Features.Fuels.Commands.Create;

public sealed record CreateFuelCommand(string Name) : IRequest<CreateFuelResponse> , ITransactionalRequest, ICacheRemoverRequest, ILoggableRequest
{
    public string? CacheKey => "";
    public bool BypassCache => false;
    public string? CacheGroupKey => "GetFuels";
    
    
    
    public class CreateFuelHandler : IRequestHandler<CreateFuelCommand,CreateFuelResponse>
    {
        private readonly IFuelRepository _fuelRepository;
        private readonly IMapper _mapper;
        private readonly FuelBusinessRules _fuelBusiness;

        public CreateFuelHandler(IFuelRepository fuelRepository, IMapper mapper, FuelBusinessRules fuelBusiness)
        {
            _fuelRepository = fuelRepository;
            _mapper = mapper;
            _fuelBusiness = fuelBusiness;
        }


        public async Task<CreateFuelResponse> Handle(CreateFuelCommand request, CancellationToken cancellationToken)
        {
            await _fuelBusiness.FuelMustBeUnique(request.Name);

            var fuel = _mapper.Map<Fuel>(request);

            var createdFuel = await _fuelRepository.AddAsync(fuel);

            var response = _mapper.Map<CreateFuelResponse>(createdFuel);
            
            return response;
        }
    }
    
    
}