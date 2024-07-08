using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Domain.Entities;
using MediatR;

namespace Application.Features.Sliders.Commands.Delete;

public class DeleteSliderCommand : IRequest<DeletedSliderResponse>, ICacheRemoverRequest, ILoggableRequest
{
    public Guid Id { get; set; }

    public string CacheKey => "";
    public bool BypassCache => false;
    public string? CacheGroupKey => "GetSliders";
    
    public class DeleteSliderCommandHandler : IRequestHandler<DeleteSliderCommand, DeletedSliderResponse>
    {
        private readonly ISliderRepository _sliderRepository;
        private readonly IMapper _mapper;

        public DeleteSliderCommandHandler(ISliderRepository sliderRepository, IMapper mapper)
        {
            _sliderRepository = sliderRepository;
            _mapper = mapper;
        }

        public async Task<DeletedSliderResponse> Handle(DeleteSliderCommand request,
            CancellationToken cancellationToken)
        {
            Slider? slider = await _sliderRepository.GetAsync(predicate: s => s.Id == request.Id, cancellationToken: cancellationToken);

            await _sliderRepository.DeleteAsync(slider, true);

            DeletedSliderResponse response = _mapper.Map<DeletedSliderResponse>(slider);

            return response;
        }
    }
}