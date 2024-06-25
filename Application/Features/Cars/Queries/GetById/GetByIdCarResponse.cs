using Domain.Enums;

namespace Application.Features.Cars.Queries.GetById;

public sealed record GetByIdCarResponse
{
    public Guid Id { get; set; }
    public string ModelId { get; init; }
    public string ModelName{ get; init; }
    public string BrandName { get; init; }
    public string TransmissionName { get; init; }
    public string FuelName { get; init; }
    public decimal DailyPrice { get; init; }
    public int Kilometer { get; init; }
    public short ModelYear { get; set; }
    public string Plate { get; init; }
    public short MinFIndexScore { get; init; }
    public CarState CarState { get; init; }
    public List<string> ImagesRoot { get; init; }
    public string ColorId { get; set; }
    public string ColorName { get; set; }
}