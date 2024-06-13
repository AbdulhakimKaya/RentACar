using Application.Features.Colors.Commands.Create;
using Application.Features.Colors.Commands.Delete;
using Application.Features.Colors.Commands.Update;
using Application.Features.Colors.Queries.GetListNoPaginate;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ColorsController: BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateColorCommand createColorCommand)
    {
        CreatedColorResponse response = await Mediator!.Send(createColorCommand);
        return Ok(response);
    }
    
    
    [HttpGet("getall")]
    public async Task<IActionResult> GetList()
    {
        var response = await Mediator.Send(new GetListNoPaginateColorQuery());
        return Ok(response);

    }
    
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateColorCommand updateColorCommand)
    {
        UpdatedColorResponse response = await Mediator!.Send(updateColorCommand);

        return Ok(response);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedColorResponse response = await Mediator!.Send(new DeleteColorCommand { Id = id });

        return Ok(response);
    }
}