using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Domain.Entities;
using MediatR;

namespace Application.Features.Fuels.Commands.Update;

public class UpdateFuelCommand : IRequest<UpdatedFuelResponse>, ICacheRemoverRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public string CacheKey => "";
    public bool BypassCache => false;
    public string? CacheGroupKey => "GetFuels";
    
    public class UpdateFuelCommandHandler : IRequestHandler<UpdateFuelCommand, UpdatedFuelResponse>
    {
        private readonly IFuelRepository _fuelRepository;
        private readonly IMapper _mapper;

        public UpdateFuelCommandHandler(IFuelRepository fuelRepository, IMapper mapper)
        {
            _fuelRepository = fuelRepository;
            _mapper = mapper;
        }


        public async Task<UpdatedFuelResponse> Handle(UpdateFuelCommand request, CancellationToken cancellationToken)
        {
            Fuel? fuel = await _fuelRepository.GetAsync(predicate: b => b.Id == request.Id,
                cancellationToken: cancellationToken);

            fuel = _mapper.Map(request, fuel);

            await _fuelRepository.UpdateAsync(fuel);

            UpdatedFuelResponse response = _mapper.Map<UpdatedFuelResponse>(fuel);
            
            return response;
        }
    }
}