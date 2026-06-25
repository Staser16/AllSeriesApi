using AllSeriesApi.Repository;
using AllSeriesApi.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using AllSeriesApi.DTOS.Anime;
using AllSeriesApi.Services.Series;
namespace AllSeriesApi.Servies.Anime;

public class AnimeService(IGenericRepository<AnimeModel> repository) : IAnimeService
{
    public async Task<AnimeResponse> AddAnimeAsync(AnimeCreateRequest createRequest)
    {
        var newAnime = new AnimeModel
        {
            Name = createRequest.Name,
            Rating = createRequest.Rating,
            Episodes = createRequest.Episodes,
            Seasons = createRequest.Seasons
        };

        await repository.AddAsync(newAnime);

        await repository.SaveAsync();

        return new AnimeResponse
        {
            Id = newAnime.Id,
            Name = newAnime.Name,
            Rating = newAnime.Rating,
            Episodes = newAnime.Episodes,
            Seasons = newAnime.Seasons
        };
    }

    public async Task DeleteAnimeAsync(Guid Id)
    {
        var AnimeDelete = await repository.GetByIdAsync(Id);

        if (AnimeDelete is null)
            throw new KeyNotFoundException($"Anime with Id: {Id}, has not been found");

        await repository.DeleteAsync(AnimeDelete);
        await repository.SaveAsync();
    }

    public async Task<List<AnimeResponse>> GetAllAnimeAsync()
    => (await repository.GetAllAsync()).Select(x => new AnimeResponse
        {
            Id = x.Id,
            Name = x.Name,
            Rating = x.Rating,
            Episodes = x.Episodes,
            Seasons = x.Seasons
        }).ToList();

    public async Task<AnimeResponse?> GetAnimeByIdAsync(Guid Id)
    {
        var animeById = await repository.GetByIdAsync(Id);

        if (animeById is null)
            throw new KeyNotFoundException($"Anime with Id: {Id}, has not been found");

        return new AnimeResponse
        {
            Id = animeById.Id,
            Name = animeById.Name,
            Rating = animeById.Rating,
            Episodes = animeById.Episodes,
            Seasons = animeById.Seasons
        };
    }

    public async Task PatchAnimeAsync(Guid Id, AnimePatchRequest patchRequest)
    {
        var animeToPatch = await repository.GetByIdAsync(Id);

        if (animeToPatch is null)
            throw new KeyNotFoundException($"The anime with Id {Id}, has not been found");

        if (patchRequest.Name is not null && patchRequest.Name != "")
        {
            if (patchRequest.Name.Length < 3)
                throw new ArgumentException("Name must be at least 3 characters long");
            else
                animeToPatch.Name = patchRequest.Name;
        }
        if (patchRequest.Rating.HasValue) animeToPatch.Rating = patchRequest.Rating.Value;
        if (patchRequest.Seasons.HasValue) animeToPatch.Seasons = patchRequest.Seasons.Value;
        if (patchRequest.Episodes.HasValue) animeToPatch.Episodes = patchRequest.Episodes.Value;
        animeToPatch.UpdateDateTime = DateTime.UtcNow;

        await repository.SaveAsync();
    }

    public async Task UpdateAnimeAsync(Guid Id, AnimeUpdateRequest updateRequest)
    {
        var animeToUpdate = await repository.GetByIdAsync(Id);

        if (animeToUpdate is null)
            throw new KeyNotFoundException($"The anime with Id {Id}, has not been found");

        animeToUpdate.Name = updateRequest.Name;
        animeToUpdate.Rating = updateRequest.Rating;
        animeToUpdate.Seasons = updateRequest.Seasons;
        animeToUpdate.Episodes = updateRequest.Episodes;
        animeToUpdate.UpdateDateTime = DateTime.UtcNow;

        await repository.SaveAsync();
    }

    public async Task<List<AnimeResponse>> GetPageAsync(int page, int size)
    {
        return (await repository.PageAsync(page, size))
        .Select(x => new AnimeResponse
        {
            Id = x.Id,
            Name = x.Name,
            Rating = x.Rating,
            Seasons = x.Seasons,
            Episodes = x.Episodes
        })
        .ToList();
    }

    public async Task<List<AnimeResponse>> SearchAsync(string quote)
    {
        return (await repository
        .SearchAsync(x=>x.Name.ToLower()
            .Contains(quote.ToLower())
            )
        )
        .Select(x => new AnimeResponse
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