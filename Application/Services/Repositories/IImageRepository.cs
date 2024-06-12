using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Services.Repositories;

public interface IImageRepository : IAsyncRepository<Image,Guid>, IRepository<Image,Guid>
{
    
}