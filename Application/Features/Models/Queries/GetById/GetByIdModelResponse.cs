namespace Application.Features.Models.Queries.GetById.GetById;

public class GetByIdModelResponse
{
    public Guid Id { get; set; }
    public string Name { get; init; }
    public string BrandId { get; init; }
    public string TransmissionId { get; init; }
    public string FuelId { get; init; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public DateTime? DeletedDate { get; set; }
}