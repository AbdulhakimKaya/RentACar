using Domain.Entities;
using Domain.Enums;

namespace Application.Features.Cars.Commands.Create;

public class CreateCarCommandResponse
{
    public Guid ModelId { get; set; }
    public Guid ColorId { get; set; }
    public int Kilometer { get; set; }
    public short ModelYear { get; set; }
    public string Plate { get; set; }
    public short MinFIndexScore { get; set; }
    public CarState CarState { get; set; }
}