using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Transmissions.Queries.GetById;

public class GetByIdTransmissionQuery : IRequest<GetByIdTransmissionResponse>
{
    public Guid Id { get; set; }
    
    public class GetByIdTransmissionQueryHandler : IRequestHandler<GetByIdTransmissionQuery, GetByIdTransmissionResponse>
    {
        private readonly ITransmissionRepository _transmissionRepository;
        private readonly IMapper _mapper;

        public GetByIdTransmissionQueryHandler(ITransmissionRepository transmissionRepository, IMapper mapper)
        {
            _transmissionRepository = transmissionRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdTransmissionResponse> Handle(GetByIdTransmissionQuery request,
            CancellationToken cancellationToken)
        {
            Transmission? transmission = await _transmissionRepository.GetAsync(predicate: t => t.Id == request.Id,
                withDeleted: true, cancellationToken: cancellationToken);

            GetByIdTransmissionResponse response = _mapper.Map<GetByIdTransmissionResponse>(transmission);

            return response;
        }
    }
}