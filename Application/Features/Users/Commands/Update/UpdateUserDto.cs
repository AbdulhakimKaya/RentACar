namespace Application.Features.Users.Commands.Update;

public class UpdateUserDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string OldPassword { get; set; }
    public string NewPassword { get; set; }
}