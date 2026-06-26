using AllSeriesApi.DTOS.Base;
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
    public async Task<ActionResult<List<FilmResponse>>> GetAllFilms(CancellationToken ct)
    {
        return Ok(await service.GetAllFilmsAsync(ct));
    }

    [HttpGet("{Id}")]
    public async Task<ActionResult<FilmResponse>> GetFilmById(Guid Id, CancellationToken ct)
    {
        var result = await service.GetFilmByIdAsync(Id, ct);

        return result is null ? NotFound($"The Film with this Id {Id} has not been found") : Ok(result);
    }

    [HttpGet("Page")]
    public async Task<ActionResult<List<FilmResponse>>> GetPagedFilms([FromQuery] PageRequest pageRequest, CancellationToken ct)
    {
        return Ok(await service.GetPageAsync(pageRequest.page, pageRequest.size, ct));
    }

    [HttpGet("Search")]
    public async Task<ActionResult<List<FilmResponse>>> SearchFilms([FromQuery] SearchRequest searchRequest, CancellationToken ct)
    {
        return Ok(await service.SearchAsync(searchRequest.quote, ct));
    }

    [HttpPost]
    public async Task<ActionResult<FilmResponse>> AddFilm(FilmCreateRequest createRequest, CancellationToken ct)
    {
        var result = await service.AddFilmAsync(createRequest, ct);

        return CreatedAtAction(nameof(GetFilmById), new { Id = result.Id }, result);
    }

    [HttpPut("{Id}")]
    public async Task<ActionResult<FilmResponse>> UpdateFilm(Guid Id, FilmUpdateRequest updateRequest, CancellationToken ct)
    {
        try
        {
            await service.UpdateFilmAsync(Id, updateRequest, ct);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpPatch("{Id}")]
    public async Task<ActionResult<FilmResponse>> PatchFilm(Guid Id, FilmPatchRequest patchRequest, CancellationToken ct)
    {
        try
        {
            await service.PatchFilmAsync(Id, patchRequest, ct);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }
    
    [HttpDelete("{Id}")]
    public async Task<ActionResult<FilmResponse>> DeleteFilm(Guid Id, CancellationToken ct)
    {
        try
        {
            await service.DeleteFilmAsync(Id, ct);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }
}
