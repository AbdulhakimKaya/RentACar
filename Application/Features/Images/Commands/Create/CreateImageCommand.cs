using System.Data;
using System.Diagnostics;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Dapper;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;

namespace Application.Features.Images.Commands.Create;

public class CreateImageCommand : IRequest<CreateImageCommandResponse>, ICacheRemoverRequest, ITransactionalRequest, ILoggableRequest
{
    public IFormFile? Image { get; set; }
    
    public Guid CarId { get; set; }
    public string? CacheKey => "";
    public bool BypassCache => false;
    public string? CacheGroupKey => "GetCars,Images";
    
    
    
    public class CreateImageCommandHandler : IRequestHandler<CreateImageCommand, CreateImageCommandResponse>
    {
        private readonly IDbConnection _dbConnection;
        private readonly IFileProvider _fileProvider;
        private readonly IMapper _mapper;


        public CreateImageCommandHandler(IConfiguration configuration,IDbConnection dbConnection, IFileProvider fileProvider, IMapper mapper)
        {
            _dbConnection = new SqlConnection(configuration.GetConnectionString("RentACar"));
            _fileProvider = fileProvider;
            _mapper = mapper;
        }

        public async Task<CreateImageCommandResponse> Handle(CreateImageCommand request, CancellationToken cancellationToken)
        {
          
            var car = await _dbConnection.QueryFirstOrDefaultAsync<Car>(
                "SELECT * FROM Cars WHERE Id = @Id",
                new { Id = request.CarId }
            );
            
            if (car == null)
            {
                throw new BusinessException("Car not found");
            }

            var created = new Image
            {
                CarId = request.CarId
            };

            if (request.Image != null && request.Image.Length > 0)
            {
                var root = _fileProvider.GetDirectoryContents("wwwroot");
                var images = root.First(x => x.Name == "images");
                var randomImageName = Guid.NewGuid() + Path.GetExtension(request.Image.FileName);
                var path = Path.Combine(images.PhysicalPath, randomImageName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await request.Image.CopyToAsync(stream);
                }

                created.Root = randomImageName;
            }
            var insertQuery = @"
                INSERT INTO Images (Id, CarId, Root, CreatedDate)
                VALUES (@Id, @CarId, @Root, @CreatedDate)";

            var imageId = Guid.NewGuid(); 
            
         var result =   await _dbConnection.ExecuteAsync(
                insertQuery,
                new
                {
                    Id = imageId,
                    CarId = created.CarId,
                    Root = created.Root,
                    CreatedDate = DateTime.Now
                }
            );

            if (result>0)
            {
                Console.WriteLine("Başarılı");
            }
            else
            {
                Console.WriteLine("Başarılı");
            }
            
            created.Id = imageId; 
            
            var response = _mapper.Map<CreateImageCommandResponse>(created);
            return response;
        }
    }
    
}