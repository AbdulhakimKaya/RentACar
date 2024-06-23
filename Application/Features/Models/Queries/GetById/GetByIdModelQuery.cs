using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Models.Queries.GetById.GetById.GetById;

public class GetByIdModelQuery : IRequest<GetByIdModelResponse>
{
    public Guid Id { get; set; }
    
    public class GetByIdModelQueryHandler : IRequestHandler<GetByIdModelQuery, GetByIdModelResponse>
    {
        private readonly IModelRepository _modelRepository;
        private readonly IMapper _mapper;

        public GetByIdModelQueryHandler(IModelRepository modelRepository, IMapper mapper)
        {
            _modelRepository = modelRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdModelResponse> Handle(GetByIdModelQuery request, CancellationToken cancellationToken)
        {
            var model = await _modelRepository.Query()
                .Include(m => m.Brand)
                .Include(m => m.Fuel)
                .Include(m => m.Transmission)
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            var response = _mapper.Map<GetByIdModelResponse>(model);

            return response;
        }
    }
}