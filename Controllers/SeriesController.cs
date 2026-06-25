using AllSeriesApi.DTOS.Series;
using AllSeriesApi.Services.Series;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AllSeriesApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SeriesController(ISeriesService service) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<SeriesResponse>>> GetAllSeries()
    {
        return Ok(await service.GetAllSeriesAsync());
    }

    [HttpGet("{Id}")]
    public async Task<ActionResult<SeriesResponse>> GetSeriesById(Guid Id)
    {
        var result = await service.GetSeriesByIdAsync(Id);

        return result is null ? NotFound($"The Series with this Id {Id} has not been found") : Ok(result);
    }

    [HttpGet("Page")]
    public async Task<ActionResult<List<SeriesResponse>>> GetPagedSeries([FromQuery] SeriesPageRequest pageRequest)
    {
        return Ok(await service.GetPageAsync(pageRequest.page, pageRequest.size));
    }

    [HttpGet("Search")]
    public async Task<ActionResult<List<SeriesResponse>>> SearchSeries([FromQuery] SeriesSearchRequest searchRequest)
    {
        return Ok(await service.SearchAsync(searchRequest.quote));
    }

    [HttpPost]
    public async Task<ActionResult<SeriesResponse>> AddSeries(SeriesCreateRequest createRequest)
    {
        var result = await service.AddSeriesAsync(createRequest);

        return CreatedAtAction(nameof(GetAllSeries), new { Id = result.Id }, result);
    }

    [HttpPut("{Id}")]
    public async Task<ActionResult<SeriesResponse>> UpdateSeries(Guid Id, SeriesUpdateRequest updateRequest)
    {
        try
        {
            await service.UpdateSeriesAsync(Id, updateRequest);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpPatch("{Id}")]
    public async Task<ActionResult<SeriesResponse>> PatchSeries(Guid Id, SeriesPatchRequest patchRequest)
    {
        try
        {
            await service.PatchSeriesAsync(Id, patchRequest);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }
    
    [HttpDelete("{Id}")]
    public async Task<ActionResult<SeriesResponse>> DeleteSeries(Guid Id)
    {
        try
        {
            await service.DeleteSeriesAsync(Id);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }
}
