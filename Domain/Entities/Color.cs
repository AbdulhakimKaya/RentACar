using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Color: Entity<Guid>
{
    public string Name { get; set; }
    public virtual ICollection<Car> Cars { get; set; }

    public Color()
    {
        Cars = new HashSet<Car>();
    }
    
    public Color(Guid id, string name) : this()
    {
        Id = id;
        Name = name;
    }
}