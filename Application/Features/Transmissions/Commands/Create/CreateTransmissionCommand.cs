using Application.Features.Brands.Commands.Create;
using Application.Features.Brands.Rules;
using Application.Features.Transmissions.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using Domain.Entities;
using MediatR;

namespace Application.Features.Transmissions.Commands.Create;

public class CreateTransmissionCommand: IRequest<CreatedTransmissionResponse>, ITransactionalRequest, ICacheRemoverRequest, ILoggableRequest
{
    public string Name { get; set; }
    public string? CacheKey { get; }
    public bool BypassCache { get; }
    public string? CacheGroupKey { get; }
    
    public class CreateTransmissionCommandHandler : IRequestHandler<CreateTransmissionCommand, CreatedTransmissionResponse>
    {
        private readonly ITransmissionRepository _transmissionRepository;
        private readonly TransmissionBusinessRules _transmissionBusinessRules;
        private readonly IMapper _mapper;

        public CreateTransmissionCommandHandler(ITransmissionRepository transmissionRepository, TransmissionBusinessRules transmissionBusinessRules, IMapper mapper)
        {
            _transmissionRepository = transmissionRepository;
            _transmissionBusinessRules = transmissionBusinessRules;
            _mapper = mapper;
        }

        public async Task<CreatedTransmissionResponse> Handle(CreateTransmissionCommand request, CancellationToken cancellationToken)
        {
            await _transmissionBusinessRules.TransmissionNameCannotBeDuplicatedWhenInserted(request.Name);
            
            Transmission transmission = _mapper.Map<Transmission>(request);
            transmission.Id = Guid.NewGuid();

            await _transmissionRepository.AddAsync(transmission);
            
            CreatedTransmissionResponse createdTransmissionResponse = _mapper.Map<CreatedTransmissionResponse>(transmission);
            return createdTransmissionResponse;
        }
    }
}