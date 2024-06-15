using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Model = Domain.Entities.Model;

namespace Application.Features.Models.Commands.Create;

public class CreateModelCommand : IRequest<CreatedModelResponse>, ITransactionalRequest, ICacheRemoverRequest, ILoggableRequest
{
    public Guid BrandId { get; set; }
    public Guid FuelId { get; set; }
    public Guid TransmissionId { get; set; }
    public string Name { get; set; }

    public string CacheKey => "";
    public bool BypassCache => false;
    public string? CacheGroupKey => "GetModels";
    
    public class CreateModelCommandHandler : IRequestHandler<CreateModelCommand, CreatedModelResponse>
    {
        private readonly IModelRepository _modelRepository;
        private readonly IMapper _mapper;

        public CreateModelCommandHandler(IModelRepository modelRepository, IMapper mapper)
        {
            _modelRepository = modelRepository;
            _mapper = mapper;
        }

        public async Task<CreatedModelResponse> Handle(CreateModelCommand request, CancellationToken cancellationToken)
        {
            Model mappedModel = _mapper.Map<Model>(request);
            Model createdModel = await _modelRepository.AddAsync(mappedModel);
            CreatedModelResponse createdModelDto = _mapper.Map<CreatedModelResponse>(createdModel);
            return createdModelDto;
        }
    }
}