using Application.Features.Transmissions.Commands.Create;
using Application.Features.Transmissions.Commands.Delete;
using Application.Features.Transmissions.Queries.GetListNoPaginate;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TransmissionsController: BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateTransmissionCommand createTransmissionCommand)
    {
        CreatedTransmissionResponse response = await Mediator!.Send(createTransmissionCommand);
        return Ok(response);
    }
    
    [HttpGet("getall")]
    public async Task<IActionResult> GetList()
    {
        var response = await Mediator.Send(new GetListNoPaginateTransmissionQuery());
        return Ok(response);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedTransmissionResponse response = await Mediator!.Send(new DeleteTransmissionCommand() { Id = id });

        return Ok(response);
    }
}