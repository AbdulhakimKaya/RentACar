using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Slider : Entity<Guid>
{
    public string Name { get; set; }

    public string ImageUrl { get; set; }
}