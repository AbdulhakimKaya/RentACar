using Domain.Entities;

namespace Application.Features.Models.Commands.Create;

public class CreatedModelResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid BrandId { get; set; }
    public Guid FuelId { get; set; }
    public Guid TransmissionId { get; set; }
    public DateTime CreatedDate { get; set; }
}