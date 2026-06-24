using Microsoft.AspNetCore.Mvc;

namespace AllSeriesApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FilmController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok();
    }
}
