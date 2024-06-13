using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Color: Entity<Guid>
{
    public string Name { get; set; }
    public virtual ICollection<Model> Models { get; set; }

    public Color()
    {
        Models = new HashSet<Model>();
    }
    
    public Color(Guid id, string name) : this()
    {
        Id = id;
        Name = name;
    }
}