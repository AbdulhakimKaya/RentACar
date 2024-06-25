using Application.Features.Cars.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using Domain.Entities;
using Domain.Enums;
using MediatR;

namespace Application.Features.Cars.Commands.Update;

public class UpdateCarCommand : IRequest<UpdateCarResponse>,ITransactionalRequest, ICacheRemoverRequest , ILoggableRequest
{

    public Guid Id { get; set; }
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
    
    
    
    public class UpdateCarCommandHandler : IRequestHandler<UpdateCarCommand,UpdateCarResponse>
    {

        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;
        private readonly CarBusinessRules _carBusiness;

        public UpdateCarCommandHandler(ICarRepository carRepository, IMapper mapper, CarBusinessRules carBusiness)
        {
            _carRepository = carRepository;
            _mapper = mapper;
            _carBusiness = carBusiness;
        }
        
        public async Task<UpdateCarResponse> Handle(UpdateCarCommand request, CancellationToken cancellationToken)
        {
            await _carBusiness.CarIsPresent(request.Id);

            var car = _mapper.Map<Car>(request);

            var updated = await _carRepository.UpdateAsync(car);

            var response = _mapper.Map<UpdateCarResponse>(updated);

            return response;
        }
    }
    
}