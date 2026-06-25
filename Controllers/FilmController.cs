using AllSeriesApi.DTOS.Film;
using AllSeriesApi.Servies.Film;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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

    [HttpGet("{Id}")]
    public async Task<ActionResult<FilmResponse>> GetFilmById(Guid Id)
    {
        var result = await service.GetFilmByIdAsync(Id);

        return result is null ? NotFound($"The Film with this Id {Id} has not been found") : Ok(result);
    }

    [HttpGet("Page")]
    public async Task<ActionResult<List<FilmResponse>>> GetPagedFilms([FromQuery] FilmPageRequest pageRequest)
    {
        return Ok(await service.GetPageAsync(pageRequest.page, pageRequest.size));
    }

    [HttpGet("Search")]
    public async Task<ActionResult<List<FilmResponse>>> SearchFilms([FromQuery] FilmSearchRequest searchRequest)
    {
        return Ok(await service.SearchAsync(searchRequest.quote));
    }

    [HttpPost]
    public async Task<ActionResult<FilmResponse>> AddFilm(FilmCreateRequest createRequest)
    {
        var result = await service.AddFilmAsync(createRequest);

        return CreatedAtAction(nameof(GetAllFilms), new { Id = result.Id }, result);
    }

    [HttpPut("{Id}")]
    public async Task<ActionResult<FilmResponse>> UpdateFilm(Guid Id, FilmUpdateRequest updateRequest)
    {
        try
        {
            await service.UpdateFilmAsync(Id, updateRequest);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpPatch("{Id}")]
    public async Task<ActionResult<FilmResponse>> PatchFilm(Guid Id, FilmPatchRequest patchRequest)
    {
        try
        {
            await service.PatchFilmAsync(Id, patchRequest);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }
    
    [HttpDelete("{Id}")]
    public async Task<ActionResult<FilmResponse>> DeleteFilm(Guid Id)
    {
        try
        {
            await service.DeleteFilmAsync(Id);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }
}
