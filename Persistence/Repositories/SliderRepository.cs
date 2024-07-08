using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class SliderRepository: EfRepositoryBase<Slider,Guid,BaseDbContext>, ISliderRepository
{
    public SliderRepository(BaseDbContext context) : base(context)
    {
    }
}