using System.Net.Mime;
using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ImageRepository: EfRepositoryBase<Image,Guid,BaseDbContext> , IImageRepository
{
    public ImageRepository(BaseDbContext context) : base(context)
    {
    }
}