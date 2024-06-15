using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Domain.Entities;
using MediatR;

namespace Application.Features.Colors.Commands.Delete;

public class DeleteColorCommand: IRequest<DeletedColorResponse>, ICacheRemoverRequest
{
    public Guid Id { get; set; }
    public string CacheKey => "";
    public bool BypassCache => false;
    public string? CacheGroupKey => "GetColors";
    
    public class DeleteColorCommandHandler : IRequestHandler<DeleteColorCommand, DeletedColorResponse>
    {
        private readonly IColorRepository _colorRepository;
        private readonly IMapper _mapper;

        public DeleteColorCommandHandler(IColorRepository colorRepository, IMapper mapper)
        {
            _colorRepository = colorRepository;
            _mapper = mapper;
        }

        public async Task<DeletedColorResponse> Handle(DeleteColorCommand request, CancellationToken cancellationToken)
        {
            Color? color = await _colorRepository.GetAsync(predicate: c => c.Id == request.Id,
                cancellationToken: cancellationToken);

            await _colorRepository.DeleteAsync(color,true);

            DeletedColorResponse response = _mapper.Map<DeletedColorResponse>(color);

            return response;
        }
    }
}