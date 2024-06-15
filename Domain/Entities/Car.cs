using Core.Persistence.Repositories;
using Domain.Enums;

namespace Domain.Entities;

public class Car : Entity<Guid>
{
    public Guid ModelId { get; set; }

    public Guid ColorId { get; set; }
    public int Kilometer { get; set; }
    public short ModelYear { get; set; }
    public string Plate { get; set; }
    public short MinFIndexScore { get; set; }
    public CarState CarState { get; set; }

    public decimal DailyPrice { get; set; }

    public Color Color { get; set; }
    public virtual Model? Model { get; set; }

    public ICollection<Image> Images { get; set; }
    

    public Car()
    {
    }

    public Car(Guid id, Guid modelId, Guid colorId, int kilometer, short modelYear, string plate, short minFIndexScore, decimal dailyPrice) : this()
    {
        Id = id;
        ModelId = modelId;
        ColorId = colorId;
        Kilometer = kilometer;
        DailyPrice = dailyPrice;
        ModelYear = modelYear;
        Plate = plate;
        MinFIndexScore = minFIndexScore;
        Images = new HashSet<Image>();
        
    }
}