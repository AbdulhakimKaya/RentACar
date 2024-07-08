using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Entities;
using MediatR;

namespace Application.Features.Auth.Commands.Delete;

public class DeleteUserCommand: IRequest<DeletedUserResponse>
{
    public int Id { get; set; }
    
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, DeletedUserResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public DeleteUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<DeletedUserResponse> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            User? user = await _userRepository.GetAsync(predicate: u => u.Id == request.Id,
                cancellationToken: cancellationToken);

            await _userRepository.DeleteAsync(user, true);

            DeletedUserResponse response = _mapper.Map<DeletedUserResponse>(user);

            return response;
        }
    }
}