using Application.Features.Images.Commands.Create;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ImagesController : BaseController
{

    [HttpPost]
    public async Task<IActionResult> Create([FromForm] CreateImageCommand imageCommand)
    {
        var result = await Mediator.Send(imageCommand);
        return Created("/", result);
    }
    
}