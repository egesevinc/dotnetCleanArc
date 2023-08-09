using Dot7.CleanArchitecture.Application.Beach.CreateBeach;
using Dot7.CleanArchitecture.Application.Beach.DeleteBeach;
using Dot7.CleanArchitecture.Application.Beach.GetAllBeaches;
using Dot7.CleanArchitecture.Application.Beach.UpdateBeach;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dot7.CleanArchitecture.Api.Controllers;
[ApiController]
[Route("[controller]")]
public class BeachController : ControllerBase
{
    private readonly IMediator _mediator;
    public BeachController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpGet]
    public async Task<IActionResult> GetByFilter([FromQuery] GetAllBeachesRequest request)
    {
        var result = await _mediator.Send(request);
        return Ok(result);
    }


    [HttpPost("create")]
    public async Task<IActionResult> PostAsync(CreateBeachRequest payload)
    {
        var id = await _mediator.Send(payload);
        return Ok(id);
    }
    [HttpDelete("delete")]
    public async Task<IActionResult> DeleteAsync(DeleteBeachRequest payload)
    {
        var beachName = await _mediator.Send(payload);
        return Ok(beachName);
    }

    [HttpPut("update")]
    public async Task<IActionResult> UpdateBeachAsync(UpdateBeachRequest payload)
    {
        var id = await _mediator.Send(payload);
        return Ok(id);
    }
}