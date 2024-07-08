using Application.Features.Sliders.Commands.Create;
using Application.Features.Sliders.Commands.Delete;
using Application.Features.Sliders.Queries.GetListNoPaginate;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SlidersController : BaseController
{


    [HttpPost]
    public async Task<IActionResult> Add([FromForm] CreateSliderCommand command)
    {
        var response = await Mediator.Send(command);
        return Created("/", response);
    }
    
    [HttpGet("getall")]
    public async Task<IActionResult> GetList()
    {
        var response = await Mediator.Send(new GetListNoPaginateSliderQuery());
        return Ok(response);
    }
    
    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedSliderResponse response = await Mediator!.Send(new DeleteSliderCommand() { Id = id });

        return Ok(response);
    }
}