using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Users.Queries.GetListNoPaginate;

public class GetListNoPaginateUserQuery : IRequest<List<GetListNoPaginateUserItemDto>>
{
    
    
    public class GetListNoPaginateUserQueryHandler : IRequestHandler<GetListNoPaginateUserQuery,List<GetListNoPaginateUserItemDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetListNoPaginateUserQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }


        public async Task<List<GetListNoPaginateUserItemDto>> Handle(GetListNoPaginateUserQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.Query().AsNoTracking().ToListAsync(cancellationToken);

            var response = _mapper.Map<List<GetListNoPaginateUserItemDto>>(users);

            return response;

        }
    }
}