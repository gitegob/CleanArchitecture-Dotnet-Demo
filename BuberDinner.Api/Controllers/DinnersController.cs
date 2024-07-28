using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

[Route("dinners")]
[Tags("Dinners")]
public class DinnersController(
    ISender sender,
    IMapper mapper) : BaseController
{
    [HttpGet]
    public async Task<IActionResult> ListDinners()
    {
        await Task.CompletedTask;
        return Ok(new List<string>());
    }
}