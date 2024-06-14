using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Domain.Entities;
using MediatR;

namespace Application.Features.Transmissions.Commands.Update;

public class UpdateTransmissionCommand : IRequest<UpdatedTransmissionResponse>, ICacheRemoverRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public string CacheKey => "";
    public bool BypassCache => false;
    public string? CacheGroupKey => "GetTransmissions";
    
    public class UpdateTransmissionCommandHandler : IRequestHandler<UpdateTransmissionCommand, UpdatedTransmissionResponse>
    {
        private readonly ITransmissionRepository _transmissionRepository;
        private readonly IMapper _mapper;

        public UpdateTransmissionCommandHandler(ITransmissionRepository transmissionRepository, IMapper mapper)
        {
            _transmissionRepository = transmissionRepository;
            _mapper = mapper;
        }

        public async Task<UpdatedTransmissionResponse> Handle(UpdateTransmissionCommand request, CancellationToken cancellationToken)
        {
            Transmission? transmission = await _transmissionRepository.GetAsync(predicate: b => b.Id == request.Id,
                cancellationToken: cancellationToken);

            transmission = _mapper.Map(request, transmission);

            await _transmissionRepository.UpdateAsync(transmission);

            UpdatedTransmissionResponse response = _mapper.Map<UpdatedTransmissionResponse>(transmission);
            
            return response;
        }
    }
}