using System;
using System.Collections.Generic;

namespace Persistence.Migrations;

public partial class Brand
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public DateTime? DeletedDate { get; set; }

    public virtual ICollection<Model> Models { get; set; } = new List<Model>();
}
