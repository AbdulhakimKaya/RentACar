using Application.Features.Cars.Commands.Create;
using Application.Features.Cars.Queries.GetList;
using Application.Features.Cars.Queries.GetListNoPaginate;
using Core.Application.Requests;
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

    [HttpGet("paginate")]
    public async Task<IActionResult> GetAll([FromQuery] PageRequest pageRequest)
    {
        
        GetListCarQuery query = new()
        {
            PageRequest = pageRequest
        };
        var response = await Mediator.Send(query);
        return Ok(response);
    }

    [HttpGet("getall")]
    public async Task<IActionResult> GetList()
    {
        var query = await Mediator.Send(new GetListNoPaginateQuery());
        return Ok(query);
    }
}