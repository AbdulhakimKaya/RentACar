using System;
using System.Collections.Generic;

namespace Persistence.Migrations;

public partial class Car
{
    public Guid Id { get; set; }

    public Guid ModelId { get; set; }

    public int Kilometer { get; set; }

    public short ModelYear { get; set; }

    public string Plate { get; set; } = null!;

    public short MinFindexScore { get; set; }

    public int State { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public DateTime? DeletedDate { get; set; }

    public virtual Model Model { get; set; } = null!;
}
