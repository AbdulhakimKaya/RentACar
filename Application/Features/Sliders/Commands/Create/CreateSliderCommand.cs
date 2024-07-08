using Application.Services.FileServices;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.Sliders.Commands.Create;

public class CreateSliderCommand : IRequest<CreateSliderCommandResponse>, ITransactionalRequest, ICacheRemoverRequest, ILoggableRequest
{
    
    public IFormFile File { get; set; }
    public string CacheKey => "";
    public bool BypassCache => false;
    public string? CacheGroupKey => "GetSliders";
    
    
    public class CreateSliderCommandHandler: IRequestHandler<CreateSliderCommand,CreateSliderCommandResponse>
    {
        private readonly IFileService _fileService;
        private readonly IMapper _mapper;
        private readonly ISliderRepository _sliderRepository;

        public CreateSliderCommandHandler(IFileService fileService, IMapper mapper, ISliderRepository sliderRepository)
        {
            _fileService = fileService;
            _mapper = mapper;
            _sliderRepository = sliderRepository;
        }


        public async Task<CreateSliderCommandResponse> Handle(CreateSliderCommand request, CancellationToken cancellationToken)
        {

            var slider = _mapper.Map<Slider>(request);
            
            var url = await _fileService.UploadImage(request.File);


            slider.ImageUrl = url;

            


            var createdSlider = await _sliderRepository.AddAsync(slider);

            var response = _mapper.Map<CreateSliderCommandResponse>(createdSlider);
            return response;
        }
    }
    
    
}