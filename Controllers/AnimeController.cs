using AllSeriesApi.DTOS.Anime;
using AllSeriesApi.Servies.Anime;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using AllSeriesApi.Services.Series;
using AllSeriesApi.DTOS.Base;

namespace AllSeriesApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AnimeController(IAnimeService service) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<AnimeResponse>>> GetAllAnimes(CancellationToken ct)
    {
        return Ok(await service.GetAllAnimeAsync(ct));
    }

    [HttpGet("{Id}")]
    public async Task<ActionResult<AnimeResponse>> GetAnimeById(Guid Id, CancellationToken ct)
    {
        var result = await service.GetAnimeByIdAsync(Id, ct);

        return result is null ? NotFound($"The Anime with this Id {Id} has not been found") : Ok(result);
    }

    [HttpGet("Page")]
    public async Task<ActionResult<List<AnimeResponse>>> GetAnimesPaged([FromQuery] PageRequest pageRequest, CancellationToken ct)
    {
        return Ok(await service.GetPageAsync(pageRequest.page, pageRequest.size, ct));
    }

    [HttpGet("Search")]
    public async Task<ActionResult<List<AnimeResponse>>> SearchAnimes([FromQuery] SearchRequest searchRequest, CancellationToken ct)
    {
        return Ok(await service.SearchAsync(searchRequest.quote, ct));
    }

    [HttpPost]
    public async Task<ActionResult<AnimeResponse>> AddAnime(AnimeCreateRequest createRequest, CancellationToken ct)
    {
        var result = await service.AddAnimeAsync(createRequest, ct);

        return CreatedAtAction(nameof(GetAnimeById), new { Id = result.Id }, result);
    }

    [HttpPut("{Id}")]
    public async Task<ActionResult<AnimeResponse>> UpdateAnime(Guid Id, AnimeUpdateRequest updateRequest, CancellationToken ct)
    {
        try
        {
            await service.UpdateAnimeAsync(Id, updateRequest, ct);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpPatch("{Id}")]
    public async Task<ActionResult<AnimeResponse>> PatchAnime(Guid Id, AnimePatchRequest patchRequest, CancellationToken ct)
    {
        try
        {
            await service.PatchAnimeAsync(Id, patchRequest, ct);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }
    
    [HttpDelete("{Id}")]
    public async Task<ActionResult<AnimeResponse>> DeleteAnime(Guid Id, CancellationToken ct)
    {
        try
        {
            await service.DeleteAnimeAsync(Id, ct);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }
}
