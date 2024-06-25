using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using Domain.Entities;
using MediatR;

namespace Application.Features.Fuels.Commands.Delete;

public class DeleteFuelCommand: IRequest<DeletedFuelResponse>, ICacheRemoverRequest, ITransactionalRequest, ILoggableRequest
{
    public Guid Id { get; set; }
    public string? CacheKey => "";
    public bool BypassCache => false;
    public string? CacheGroupKey => "GetFuels";
    
    public class DeleteFuelCommandHandler : IRequestHandler<DeleteFuelCommand, DeletedFuelResponse>
    {
        private readonly IFuelRepository _fuelRepository;
        private readonly IMapper _mapper;

        public DeleteFuelCommandHandler(IFuelRepository fuelRepository, IMapper mapper)
        {
            _fuelRepository = fuelRepository;
            _mapper = mapper;
        }

        public async Task<DeletedFuelResponse> Handle(DeleteFuelCommand request, CancellationToken cancellationToken)
        {
            Fuel? fuel = await _fuelRepository.GetAsync(predicate: f => f.Id == request.Id,
                cancellationToken: cancellationToken);

            await _fuelRepository.DeleteAsync(fuel,permanent:true);

            DeletedFuelResponse response = _mapper.Map<DeletedFuelResponse>(fuel);

            return response;
        }
    }
}