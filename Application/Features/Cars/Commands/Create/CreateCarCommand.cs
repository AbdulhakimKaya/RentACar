using Application.Features.Cars.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Transaction;
using Domain.Entities;
using Domain.Enums;
using MediatR;

namespace Application.Features.Cars.Commands.Create;

public class CreateCarCommand  : IRequest<CreateCarCommandResponse> , ITransactionalRequest, ICacheRemoverRequest
{
    public Guid ModelId { get; set; }
    
    public int Kilometer { get; set; }
    
    public short ModelYear { get; set; }

    public Guid ColorId { get; set; }
    public string Plate { get; set; }
    
    public short MinFIndexScore { get; set; }
    
    public CarState CarState { get; set; }

    public decimal DailyPrice { get; set; }
    
    public string? CacheKey => "";
    public bool BypassCache => false;
    public string? CacheGroupKey => "GetCars";
    
    
    
    public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand,CreateCarCommandResponse>
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;
        private readonly CarBusinessRules _rules;
    
        public CreateCarCommandHandler(ICarRepository carRepository, IMapper mapper, CarBusinessRules rules)
        {
            _carRepository = carRepository;
            _mapper = mapper;
            _rules = rules;
        }
    
    
        public async Task<CreateCarCommandResponse> Handle(CreateCarCommand request, CancellationToken cancellationToken)
        {
    
            await _rules.CarPlateMustBeUnique(request.Plate, cancellationToken);
            
            
            var car = _mapper.Map<Car>(request);

            car.Id = new Guid();
    
            var createdCar = await _carRepository.AddAsync(car);
    
            var response = _mapper.Map<CreateCarCommandResponse>(createdCar);
    
            return response;
    
        }
    }
    
    
}