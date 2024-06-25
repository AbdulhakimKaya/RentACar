using Application.Features.Users.Commands.Update;
using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Core.Security.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class UserRepository : EfRepositoryBase<User, int, BaseDbContext>, IUserRepository
{
    public UserRepository(BaseDbContext context)
        : base(context) { }

    public Task<User> UpdateUserWithDto(UpdateUserDto dto)
    {
        throw new NotImplementedException();
    }
}