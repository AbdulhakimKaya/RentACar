using Domain.Enums;

namespace Domain.Dtos;

public record CarDetailDto
{
    public string ModelName { get; init; }
    public string BrandName { get; init; }
    public string TransmissionName { get; init; }
    public string FuelName { get; init; }
    public decimal DailyPrice { get; init; }
    public string Plate { get; init; }
    public short MinFIndexScore { get; init; }
    public CarState CarState { get; init; }
    public string ImageUrl { get; init; }
}