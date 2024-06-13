namespace Application.Features.Transmissions.Commands.Create;

public class CreatedTransmissionResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedDate { get; set; }
}