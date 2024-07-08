using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Models.Queries.GetListByDynamic;

public class GetListByDynamicModelQuery : IRequest<List<GetListByDynamicModelListItem>>
{

    public DynamicQuery DynamicQuery { get; set; }

    public class GetListByDynamicModelQueryHandler : IRequestHandler<GetListByDynamicModelQuery, List<GetListByDynamicModelListItem>>
    {
        private readonly IModelRepository _modelRepository;
        private readonly IMapper _mapper;
        
        public GetListByDynamicModelQueryHandler(IModelRepository modelRepository, IMapper mapper)
        {
            _modelRepository = modelRepository;
            _mapper = mapper;
        }
        
        public async Task<List<GetListByDynamicModelListItem>> Handle(GetListByDynamicModelQuery request,
            CancellationToken cancellationToken)
        {
            List<Model> models = await _modelRepository.GetListNoPaginateByDynamicAsync(
                dynamic: request.DynamicQuery,
                include: m => m.Include(m => m.Brand).Include(m => m.Fuel).Include(m => m.Transmission),
                cancellationToken: cancellationToken
                );

            var response = _mapper.Map<List<GetListByDynamicModelListItem>>(models);

            return response;
        }
    }
}