namespace Application.Features.Auth.Commands.Login;

public sealed class UserForLoginDto
{
    public string Email { get; set; }
    public string Password { get; set; }
    //public string? AuthenticatorCode { get; set; }
}