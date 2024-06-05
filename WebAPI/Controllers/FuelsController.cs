using Application.Features.Fuels.Commands.Create;
using Application.Features.Fuels.Queries.GetById;
using Application.Features.Fuels.Queries.GetList;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;


[ApiController]
[Route("api/[controller]")]
public class FuelsController : BaseController
{

    [HttpPost("add")]
    public async Task<IActionResult> Add([FromBody] CreateFuelCommand createFuelCommand)
    {
        var result = await Mediator.Send(createFuelCommand);

        return Created("/", result);
        
    }

    [HttpGet("getall")]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetByListFuelQuery query = new()
        {
            PageRequest = pageRequest
        };
        
        var result = await Mediator.Send(query);

        return Ok(result);
    }

    [HttpGet("getbyid")]
    public async Task<IActionResult> GetById([FromQuery] Guid id)
    {
        GetByIdFuelQuery query = new(id);

        var result = await Mediator.Send(query);
        return Ok(result);
    }
    
}