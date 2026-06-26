using AllSeriesApi.DTOS.Base;
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
    public async Task<ActionResult<List<SeriesResponse>>> GetAllSeries(CancellationToken ct)
    {
        return Ok(await service.GetAllSeriesAsync(ct));
    }

    [HttpGet("{Id}")]
    public async Task<ActionResult<SeriesResponse>> GetSeriesById(Guid Id, CancellationToken ct)
    {
        var result = await service.GetSeriesByIdAsync(Id, ct);

        return result is null ? NotFound($"The Series with this Id {Id} has not been found") : Ok(result);
    }

    [HttpGet("Page")]
    public async Task<ActionResult<List<SeriesResponse>>> GetPagedSeries([FromQuery] PageRequest pageRequest, CancellationToken ct)
    {
        return Ok(await service.GetPageAsync(pageRequest.page, pageRequest.size, ct));
    }

    [HttpGet("Search")]
    public async Task<ActionResult<List<SeriesResponse>>> SearchSeries([FromQuery] SearchRequest searchRequest, CancellationToken ct)
    {
        return Ok(await service.SearchAsync(searchRequest.quote, ct));
    }

    [HttpPost]
    public async Task<ActionResult<SeriesResponse>> AddSeries(SeriesCreateRequest createRequest, CancellationToken ct)
    {
        var result = await service.AddSeriesAsync(createRequest, ct);

        return CreatedAtAction(nameof(GetAllSeries), new { Id = result.Id }, result);
    }

    [HttpPut("{Id}")]
    public async Task<ActionResult<SeriesResponse>> UpdateSeries(Guid Id, SeriesUpdateRequest updateRequest, CancellationToken ct)
    {
        try
        {
            await service.UpdateSeriesAsync(Id, updateRequest, ct);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpPatch("{Id}")]
    public async Task<ActionResult<SeriesResponse>> PatchSeries(Guid Id, SeriesPatchRequest patchRequest, CancellationToken ct)
    {
        try
        {
            await service.PatchSeriesAsync(Id, patchRequest, ct);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }
    
    [HttpDelete("{Id}")]
    public async Task<ActionResult<SeriesResponse>> DeleteSeries(Guid Id, CancellationToken ct)
    {
        try
        {
            await service.DeleteSeriesAsync(Id, ct);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }
}
