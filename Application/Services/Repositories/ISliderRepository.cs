using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Services.Repositories;

public interface ISliderRepository : IAsyncRepository<Slider,Guid>, IRepository<Slider,Guid>
{
    
}