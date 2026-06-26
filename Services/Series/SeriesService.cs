using AllSeriesApi.Repository;
using AllSeriesApi.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using AllSeriesApi.Services.Series;
using AllSeriesApi.DTOS.Series;
namespace AllSeriesApi.Services.Series;

public class SeriesService(IGenericRepository<SeriesModel> repository) : ISeriesService
{
    public async Task<SeriesResponse> AddSeriesAsync(SeriesCreateRequest createRequest, CancellationToken ct)
    {
        var newSeries = new SeriesModel
        {
            Name = createRequest.Name,
            Rating = createRequest.Rating,
            Episodes = createRequest.Episodes,
            Seasons = createRequest.Seasons
        };

        await repository.AddAsync(newSeries, ct);

        await repository.SaveAsync(ct);

        return new SeriesResponse
        {
            Id = newSeries.Id,
            Name = newSeries.Name,
            Rating = newSeries.Rating,
            Episodes = newSeries.Episodes,
            Seasons = newSeries.Seasons
        };
    }

    public async Task DeleteSeriesAsync(Guid Id, CancellationToken ct)
    {
        var seriesDelete = await repository.GetByIdAsync(Id, ct);

        if (seriesDelete is null)
            throw new KeyNotFoundException($"Serieswith Id: {Id}, has not been found");

        repository.Delete(seriesDelete);
        await repository.SaveAsync(ct);
    }

    public async Task<List<SeriesResponse>> GetAllSeriesAsync(CancellationToken ct)
    => (await repository.GetAllAsync(ct)).Select(x => new SeriesResponse
        {
            Id = x.Id,
            Name = x.Name,
            Rating = x.Rating,
            Episodes = x.Episodes,
            Seasons = x.Seasons
        }).ToList();

    public async Task<SeriesResponse?> GetSeriesByIdAsync(Guid Id, CancellationToken ct)
    {
        var seriesById = await repository.GetByIdAsync(Id, ct);

        if (seriesById is null)
            throw new KeyNotFoundException($"Series with Id: {Id}, has not been found");

        return new SeriesResponse
        {
            Id = seriesById.Id,
            Name = seriesById.Name,
            Rating = seriesById.Rating,
            Episodes = seriesById.Episodes,
            Seasons = seriesById.Seasons
        };
    }

    public async Task PatchSeriesAsync(Guid Id, SeriesPatchRequest patchRequest, CancellationToken ct)
    {
        var seriesToPatch = await repository.GetByIdAsync(Id, ct);

        if (seriesToPatch is null)
            throw new KeyNotFoundException($"The series with Id {Id}, has not been found");

        if (patchRequest.Name is not null && patchRequest.Name != "")
        {
            if (patchRequest.Name.Length < 3)
                throw new ArgumentException("Name must be at least 3 characters long");
            else
                seriesToPatch.Name = patchRequest.Name;
        }
        if (patchRequest.Rating.HasValue) seriesToPatch.Rating = patchRequest.Rating.Value;
        if (patchRequest.Seasons.HasValue) seriesToPatch.Seasons = patchRequest.Seasons.Value;
        if (patchRequest.Episodes.HasValue) seriesToPatch.Episodes = patchRequest.Episodes.Value;
        seriesToPatch.UpdateDateTime = DateTime.UtcNow;

        await repository.SaveAsync(ct);
    }

    public async Task UpdateSeriesAsync(Guid Id, SeriesUpdateRequest updateRequest, CancellationToken ct)
    {
        var seriesToUpdate = await repository.GetByIdAsync(Id, ct);

        if (seriesToUpdate is null)
            throw new KeyNotFoundException($"The series with Id {Id}, has not been found");

        seriesToUpdate.Name = updateRequest.Name;
        seriesToUpdate.Rating = updateRequest.Rating;
        seriesToUpdate.Seasons = updateRequest.Seasons;
        seriesToUpdate.Episodes = updateRequest.Episodes;
        seriesToUpdate.UpdateDateTime = DateTime.UtcNow;

        await repository.SaveAsync(ct);
    }

    public async Task<List<SeriesResponse>> GetPageAsync(int page, int size, CancellationToken ct)
    {
        return (await repository.PageAsync(page, size, ct))
        .Select(x => new SeriesResponse
        {
            Id = x.Id,
            Name = x.Name,
            Rating = x.Rating,
            Seasons = x.Seasons,
            Episodes = x.Episodes
        })
        .ToList();
    }

    public async Task<List<SeriesResponse>> SearchAsync(string quote, CancellationToken ct)
    {
        return (await repository
        .SearchAsync(x=>x.Name.ToLower()
            .Contains(quote.ToLower()),
            ct
            )
        )
        .Select(x => new SeriesResponse
        {
            Id = x.Id,
            Name = x.Name,
            Rating = x.Rating,
            Seasons = x.Seasons,
            Episodes = x.Episodes
        })
        .ToList();
    }
    
}