using Domain.Enums;

namespace Application.Features.Brands.Queries.GetListRandom;

public class GetListRandomCarsResponse
{
    public Guid Id { get; set; }
    public string ModelName { get; init; }
    public string BrandName { get; init; }
    public string TransmissionName { get; init; }
    public string FuelName { get; init; }
    public decimal DailyPrice { get; init; }
    public string Plate { get; init; }
    public short ModelYear { get; init; }
    public short MinFIndexScore { get; init; }
    public CarState CarState { get; init; }
    public List<string> ImagesRoot { get; init; }
    
    public string ColorName { get; set; }
}