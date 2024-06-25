using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Cars.Queries.GetById;

public class GetByIdCarQuery : IRequest<GetByIdCarResponse>
{
    public Guid Id { get; set; }
    
    public class GetByIdCarQueryHandler : IRequestHandler<GetByIdCarQuery,GetByIdCarResponse>
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;

        public GetByIdCarQueryHandler(ICarRepository carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdCarResponse> Handle(GetByIdCarQuery request, CancellationToken cancellationToken)
        {
            var car = await _carRepository.Query()
                .Include(c => c.Images)
                .Include(c => c.Model)
                .Include(c => c.Model.Transmission)
                .Include(c => c.Model.Fuel)
                .Include(c => c.Model.Brand)
                .Include(c => c.Color)
                .AsNoTracking()
                .SingleOrDefaultAsync(x=> x.Id==request.Id, cancellationToken);
            
            var response = _mapper.Map<GetByIdCarResponse>(car);

            return response;
        }
    }
    
    
}