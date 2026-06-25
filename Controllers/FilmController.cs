using AllSeriesApi.DTOS.Film;
using AllSeriesApi.Servies.Film;
using Microsoft.AspNetCore.Mvc;

namespace AllSeriesApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FilmController(IFilmService service) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<FilmResponse>>> GetAllFilms()
    {
        return Ok(await service.GetAllFilmsAsync());
    }
}
