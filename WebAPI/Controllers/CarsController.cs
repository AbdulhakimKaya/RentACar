using Application.Features.Brands.Queries.GetListRandom;
using Application.Features.Cars.Commands.Create;
using Application.Features.Cars.Commands.Delete;
using Application.Features.Cars.Commands.Update;
using Application.Features.Cars.Queries.GetById;
using Application.Features.Cars.Queries.GetListNoPaginate;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CarsController: BaseController
{


    [HttpPost("add")]
    public async Task<IActionResult> Create([FromBody] CreateCarCommand createCarCommand)
    {

        var response = await Mediator.Send(createCarCommand);
        return Created("/", response);
    }
    
    [HttpGet("getall")]
    public async Task<IActionResult> GetList()
    {
        var query = await Mediator.Send(new GetListNoPaginateCarQuery());
        return Ok(query);
    }
    
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        var query = await Mediator.Send(new GetByIdCarQuery() { Id = id });
        return Ok(query);
    }

    [HttpGet("random")]
    public async Task<IActionResult> GetAllRandom()
    {
        var response = await Mediator.Send(new GetListRandomCarsQuery());
        return Ok(response);
    }

    [HttpPut("update")]
    public async Task<IActionResult> Update([FromBody] UpdateCarCommand updateCarCommand)
    {
        var response = await Mediator.Send(updateCarCommand);

        return Ok(response);
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> Delete([FromQuery] Guid id)
    {
        DeleteCarCommand command = new DeleteCarCommand() { Id = id };
        var response = await Mediator.Send(command);
        return Ok(response);


    }
    
}