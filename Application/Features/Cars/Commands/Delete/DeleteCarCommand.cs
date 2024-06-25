using Application.Features.Cars.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;

namespace Application.Features.Cars.Commands.Delete;

public class DeleteCarCommand : IRequest<DeletedCarResponse>,ITransactionalRequest, ICacheRemoverRequest , ILoggableRequest
{
    public Guid Id { get; set; }
    
    public string? CacheKey => "";
    public bool BypassCache => false;
    public string? CacheGroupKey => "GetCars";
    
    public class DeleteCarCommandHandler : IRequestHandler<DeleteCarCommand,DeletedCarResponse>
    {

        private readonly IMapper _mapper;
        private readonly ICarRepository _carRepository;
        private readonly CarBusinessRules _carBusiness;

        public DeleteCarCommandHandler(IMapper mapper, ICarRepository carRepository, CarBusinessRules carBusiness)
        {
            _mapper = mapper;
            _carRepository = carRepository;
            _carBusiness = carBusiness;
        }


        public async Task<DeletedCarResponse> Handle(DeleteCarCommand request, CancellationToken cancellationToken)
        {
            await _carBusiness.CarIsPresent(request.Id);

            var car = await _carRepository.GetAsync(x => x.Id.Equals(request.Id), cancellationToken: cancellationToken);

            var deleted = await _carRepository.DeleteAsync(car);

            var response = _mapper.Map<DeletedCarResponse>(deleted);

            return response;
        }
    }
}