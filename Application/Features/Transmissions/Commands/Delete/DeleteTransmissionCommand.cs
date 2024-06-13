using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Domain.Entities;
using MediatR;

namespace Application.Features.Transmissions.Commands.Delete;

public class DeleteTransmissionCommand : IRequest<DeletedTransmissionResponse>, ICacheRemoverRequest
{
    public Guid Id { get; set; }

    public string CacheKey => "";
    public bool BypassCache => false;
    public string? CacheGroupKey => "GetTransmissions";
    
    public class DeleteTransmissionCommandHandler : IRequestHandler<DeleteTransmissionCommand, DeletedTransmissionResponse>
    {
        private readonly ITransmissionRepository _transmissionRepository;
        private readonly IMapper _mapper;

        public DeleteTransmissionCommandHandler(ITransmissionRepository transmissionRepository, IMapper mapper)
        {
            _transmissionRepository = transmissionRepository;
            _mapper = mapper;
        }

        public async Task<DeletedTransmissionResponse> Handle(DeleteTransmissionCommand request, CancellationToken cancellationToken)
        {
            Transmission? transmission = await _transmissionRepository.GetAsync(predicate: t => t.Id == request.Id,
                cancellationToken: cancellationToken);

            await _transmissionRepository.DeleteAsync(transmission);

            DeletedTransmissionResponse response = _mapper.Map<DeletedTransmissionResponse>(transmission);

            return response;
        }
    }
}