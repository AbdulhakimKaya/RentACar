using Application.Features.Fuels.Commands.Create;
using Application.Features.Fuels.Commands.Delete;
using Application.Features.Fuels.Commands.Update;
using Application.Features.Fuels.Queries.GetById;
using Application.Features.Fuels.Queries.GetList;
using Application.Features.Fuels.Queries.GetListNoPaginate;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;


[ApiController]
[Route("api/[controller]")]
public class FuelsController : BaseController
{

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateFuelCommand createFuelCommand)
    {
        var result = await Mediator.Send(createFuelCommand);

        return Created("/", result);
        
    }

    [HttpGet("paginate")]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListFuelQuery query = new()
        {
            PageRequest = pageRequest
        };
        
        var result = await Mediator.Send(query);

        return Ok(result);
    }

    [HttpGet("getall")]
    public async Task<IActionResult> GetList()
    {
        var response = await Mediator.Send(new GetListNoPaginateFuelQuery());
        return Ok(response);
    }
    
    [HttpGet("getbyid")]
    public async Task<IActionResult> GetById([FromQuery] Guid id)
    {
        GetByIdFuelQuery query = new(id);

        var result = await Mediator.Send(query);
        return Ok(result);
    }
    
    
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateFuelCommand updateFuelCommand)
    {
        UpdatedFuelResponse response = await Mediator!.Send(updateFuelCommand);

        return Ok(response);
    }

    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedFuelResponse response = await Mediator!.Send(new DeleteFuelCommand() { Id = id });

        return Ok(response);
    }
}