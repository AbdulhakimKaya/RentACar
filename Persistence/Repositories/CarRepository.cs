using Application.Services.Repositories;
using Core.Persistence.Paging;
using Core.Persistence.Repositories;
using Domain.Dtos;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
namespace Persistence.Repositories;

public class CarRepository : EfRepositoryBase<Car, Guid, BaseDbContext>, ICarRepository
{
    public CarRepository(BaseDbContext context) : base(context)
    {
    }

    public async Task<Paginate<CarDetailDto>> GetAllDetails(int index, int size)
    {
        var detail =

            from c in Context.Cars
            join m in Context.Models on c.ModelId equals m.Id
            join b in Context.Brands on m.BrandId  equals b.Id
            join f in Context.Fuels on m.FuelId equals f.Id
            join t in Context.Transmissions  on m.TransmissionId equals t.Id 
            select new CarDetailDto()
            {
                Plate = c.Plate,
                CarState = c.CarState,
                DailyPrice = m.DailyPrice,
                ImageUrl = m.ImageUrl,
                BrandName = b.Name,
                FuelName = f.Name,
                MinFIndexScore = c.MinFIndexScore,
                ModelName = m.Name,
                TransmissionName = t.Name
            };
        var response = await detail.ToPaginateAsync(index: index, size: size);

        return response;
    }

    public async Task<CarDetailDto> GetAllDetailsById(Guid id)
    {
        var detail =
            
            from c in Context.Cars
            join m in Context.Models on c.ModelId equals m.Id
            join b in Context.Brands on m.BrandId  equals b.Id
            join f in Context.Fuels on m.FuelId equals f.Id
            join t in Context.Transmissions  on m.TransmissionId equals t.Id 
            select new CarDetailDto()
            {
                Plate = c.Plate,
                CarState = c.CarState,
                DailyPrice = m.DailyPrice,
                ImageUrl = m.ImageUrl,
                BrandName = b.Name,
                FuelName = f.Name,
                MinFIndexScore = c.MinFIndexScore,
                ModelName = m.Name,
                TransmissionName = t.Name
            };
        var response = await detail.SingleAsync();

        return response;
    }
}