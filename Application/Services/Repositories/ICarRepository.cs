using Core.Persistence.Paging;
using Core.Persistence.Repositories;
using Domain.Dtos;
using Domain.Entities;

namespace Application.Services.Repositories;

public interface ICarRepository : IAsyncRepository<Car, Guid>, IRepository<Car, Guid>
{
  
}