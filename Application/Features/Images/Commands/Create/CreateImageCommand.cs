using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;

namespace Application.Features.Images.Commands.Create;

public class CreateImageCommand : IRequest<CreateImageCommandResponse>, ICacheRemoverRequest
{
    public IFormFile? Image { get; set; }
    
    public Guid CarId { get; set; }
    public string? CacheKey => "";
    public bool BypassCache => false;
    public string? CacheGroupKey => "Images";
    
    
    public class CreateImageCommandHandler : IRequestHandler<CreateImageCommand,CreateImageCommandResponse>
    {

        private readonly IImageRepository _imageRepository;
        private readonly IFileProvider _fileProvider;
        private readonly IMapper _mapper;

        public CreateImageCommandHandler(IImageRepository imageRepository, IFileProvider fileProvider, IMapper mapper)
        {
            _imageRepository = imageRepository;
            _fileProvider = fileProvider;
            _mapper = mapper;
        }

        public async Task<CreateImageCommandResponse> Handle(CreateImageCommand request, CancellationToken cancellationToken)
        {
            var created = _mapper.Map<Image>(request);
            
            if (request.Image is {} && request.Image.Length>0)
            {
                var root = _fileProvider.GetDirectoryContents("wwwroot");
                
                var images = root.First(x => x.Name == "images");


                var randomImageName = Guid.NewGuid() + Path.GetExtension(request.Image.Name);
                
                var path = Path.Combine(images.PhysicalPath, randomImageName);
                
                using var stream = new FileStream(path, FileMode.Create);
                
                request.Image.CopyTo(stream);

                created.Root = randomImageName;

           
               
            }
            var mappedImage =  await _imageRepository.AddAsync(created);

            var response = _mapper.Map<CreateImageCommandResponse>(mappedImage);

            return response;
        }
    }
    
}