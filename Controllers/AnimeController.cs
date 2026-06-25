using AllSeriesApi.DTOS.Anime;
using AllSeriesApi.Servies.Anime;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using AllSeriesApi.Services.Series;

namespace AllSeriesApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AnimeController(IAnimeService service) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<AnimeResponse>>> GetAllAnimes()
    {
        return Ok(await service.GetAllAnimeAsync());
    }

    [HttpGet("{Id}")]
    public async Task<ActionResult<AnimeResponse>> GetAnimeById(Guid Id)
    {
        var result = await service.GetAnimeByIdAsync(Id);

        return result is null ? NotFound($"The Anime with this Id {Id} has not been found") : Ok(result);
    }

    [HttpGet("Page")]
    public async Task<ActionResult<List<AnimeResponse>>> GetAnimesPaged([FromQuery] AnimePageRequest pageRequest)
    {
        return Ok(await service.GetPageAsync(pageRequest.page, pageRequest.size));
    }

    [HttpGet("Search")]
    public async Task<ActionResult<List<AnimeResponse>>> SearchAnimes([FromQuery] AnimeSearchRequest searchRequest)
    {
        return Ok(await service.SearchAsync(searchRequest.quote));
    }

    [HttpPost]
    public async Task<ActionResult<AnimeResponse>> AddAnime(AnimeCreateRequest createRequest)
    {
        var result = await service.AddAnimeAsync(createRequest);

        return CreatedAtAction(nameof(GetAllAnimes), new { Id = result.Id }, result);
    }

    [HttpPut]
    public async Task<ActionResult<AnimeResponse>> UpdateAnime(Guid Id, AnimeUpdateRequest updateRequest)
    {
        try
        {
            await service.UpdateAnimeAsync(Id, updateRequest);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpPatch]
    public async Task<ActionResult<AnimeResponse>> PatchAnime(Guid Id, AnimePatchRequest patchRequest)
    {
        try
        {
            await service.PatchAnimeAsync(Id, patchRequest);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }
    
    [HttpDelete]
    public async Task<ActionResult<AnimeResponse>> DeleteAnime(Guid Id)
    {
        try
        {
            await service.DeleteAnimeAsync(Id);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }
}
