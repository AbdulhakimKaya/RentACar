namespace Application.Features.Images.Commands.Create;

public class CreateImageCommandResponse
{

    public Guid Id { get; set; }
    public Guid CarId { get; set; }
    public string Root { get; set; }
    
}