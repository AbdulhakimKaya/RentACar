using Core.Persistence.Paging;
using Core.Persistence.Repositories;
using Domain.Dtos;
using Domain.Entities;

namespace Application.Services.Repositories;

public interface ICarRepository : IAsyncRepository<Car, Guid>, IRepository<Car, Guid>
{
    Task<Paginate<CarDetailDto>> GetAllDetails(int index, int size);
    Task<CarDetailDto> GetAllDetailsById(Guid id);

    Task<List<CarDetailDto>> GetDetailsNoPaginate();
}