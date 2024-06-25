using Application.Features.Users.Commands.Update;
using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Application.Services.Repositories;

public interface IUserRepository : IAsyncRepository<User, int>, IRepository<User, int>
{

    Task<User> UpdateUserWithDto(UpdateUserDto dto);
}