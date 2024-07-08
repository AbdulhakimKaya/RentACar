using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Slider : Entity<Guid>
{


    public string ImageUrl { get; set; }
}