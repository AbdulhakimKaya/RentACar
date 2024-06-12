using System;
using System.Collections.Generic;

namespace Persistence.Migrations;

public partial class Model
{
    public Guid Id { get; set; }

    public Guid BrandId { get; set; }

    public Guid FuelId { get; set; }

    public Guid TransmissionId { get; set; }

    public string Name { get; set; } = null!;

    public decimal DailyPrice { get; set; }

    public string ImageUrl { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public DateTime? DeletedDate { get; set; }

    public virtual Brand Brand { get; set; } = null!;

    public virtual ICollection<Car> Cars { get; set; } = new List<Car>();

    public virtual Fuel Fuel { get; set; } = null!;

    public virtual Transmission Transmission { get; set; } = null!;
}
