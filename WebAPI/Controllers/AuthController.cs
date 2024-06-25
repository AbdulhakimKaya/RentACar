using Application.Features.Auth.Commands.Login;
using Application.Features.Auth.Commands.Register;
using Application.Features.Users.Commands.Update;
using Application.Features.Users.Queries.GetListNoPaginate;
using Core.Security.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;


[ApiController]
[Route("api/[controller]")]
public class AuthController : BaseController
{
    
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] UserForLoginDto userForLoginDto)
    {
        LoginCommand loginCommand = new() { UserForLoginDto = userForLoginDto, IpAddress = GetIpAddress() };
        LoggedResponse result = await Mediator.Send(loginCommand);

        if (result.RefreshToken is not null)
            SetRefreshTokenToCookie(result.RefreshToken);

        return Ok(result.ToHttpResponse());
    } 
    
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] UserForRegisterDto userForRegisterDto)
    {
        RegisterCommand registerCommand = new() { UserForRegisterDto = userForRegisterDto, IpAddress = GetIpAddress() };
        RegisteredResponse result = await Mediator.Send(registerCommand);
        SetRefreshTokenToCookie(result.RefreshToken);
        return Created(uri: "", result.AccessToken);
    }
    private string GetRefreshTokenFromCookies() =>
        Request.Cookies["refreshToken"] ?? throw new ArgumentException("Refresh token is not found in request cookies.");

    private void SetRefreshTokenToCookie(RefreshToken refreshToken)
    {
        CookieOptions cookieOptions = new() { HttpOnly = true, Expires = DateTime.UtcNow.AddDays(7) };
        Response.Cookies.Append(key: "refreshToken", refreshToken.Token, cookieOptions);
    }

    [HttpPut("update")]
    public async Task<IActionResult> Update(UpdateUserDto dto)
    {
        UpdateUserCommand command = new()
        {
            UpdateUserDto = dto,
            Id = GetUserIdFromRequest()
        };

        var response = await Mediator.Send(command);
        return Ok(response);
    }

    [HttpGet("getall")]
    public async Task<IActionResult> GetAll()
    {
        var response = await Mediator.Send(new GetListNoPaginateUserQuery());
        return Ok(response);
    } 
    
    
}