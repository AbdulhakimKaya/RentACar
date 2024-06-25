using Application.Features.Colors.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using Domain.Entities;
using MediatR;

namespace Application.Features.Colors.Commands.Create;

public class CreateColorCommand : IRequest<CreatedColorResponse>, ITransactionalRequest, ICacheRemoverRequest,
    ILoggableRequest
{
    public string Name { get; set; }
    public string CacheKey => "";
    public bool BypassCache => false;
    public string? CacheGroupKey => "GetColors,GetModels,GetCars";
    
    public class CreateColorCommandHandler : IRequestHandler<CreateColorCommand, CreatedColorResponse>
    {
        private readonly IColorRepository _colorRepository;
        private readonly ColorBusinessRules _colorBusinessRules;
        private readonly IMapper _mapper;

        public CreateColorCommandHandler(IColorRepository colorRepository, ColorBusinessRules colorBusinessRules, IMapper mapper)
        {
            _colorRepository = colorRepository;
            _colorBusinessRules = colorBusinessRules;
            _mapper = mapper;
        }

        public async Task<CreatedColorResponse> Handle(CreateColorCommand request, CancellationToken cancellationToken)
        {
            await _colorBusinessRules.ColorNameCannotBeDuplicatedWhenInserted(request.Name);
            
            Color color = _mapper.Map<Color>(request);
            color.Id = Guid.NewGuid();

            await _colorRepository.AddAsync(color);
            
            CreatedColorResponse createdColorResponse = _mapper.Map<CreatedColorResponse>(color);
            
            
            return createdColorResponse;
        }
    }
}