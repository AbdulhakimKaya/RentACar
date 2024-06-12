using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Image: Entity<Guid>
{
    public string Root { get; set; }
    
    public Guid CarId { get; set; }

    public Car Car { get; set; }

    public Image()
    {
        Root = string.Empty;
        Car = new Car();
    }

    public Image(string root, Guid carId)
    {
        Root = root;
        CarId = carId;

    }
    public Image(Guid id,string root, Guid carId) : base(id)
    {
        Root = root;
        CarId = carId;

    }
}