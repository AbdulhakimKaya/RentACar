using Application.Services.Repositories;
using AutoMapper;
using Core.Persistence.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Brands.Queries.GetListRandom;

public class GetListRandomCarsQuery : IRequest<List<GetListRandomCarsResponse>>
{

    
    public class GetListRandomCarsQueryHandler : IRequestHandler<GetListRandomCarsQuery,List<GetListRandomCarsResponse>>
    {

        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;

        public GetListRandomCarsQueryHandler(ICarRepository carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }


        public async Task<List<GetListRandomCarsResponse>> Handle(GetListRandomCarsQuery request, CancellationToken cancellationToken)
        {

            var cars = await _carRepository
                .Query()
                .Where(c=>c.CarState==0)
                .Take(10)
                .OrderBy(c => Guid.NewGuid())
                .Include(c => c.Images)
                .Include(c => c.Model)
                .Include(c => c.Model.Transmission)
                .Include(c => c.Model.Fuel)
                .Include(c => c.Model.Brand)
                .Include(c => c.Color)
                .ToListAsync(cancellationToken);

            var response = _mapper.Map<List<GetListRandomCarsResponse>>(cars);

            return response;
        }
    }
}