using AllSeriesApi.Repository;
using AllSeriesApi.Models;
using AllSeriesApi.DTOS.Film;
using Microsoft.AspNetCore.Http.HttpResults;
namespace AllSeriesApi.Servies.Film;

public class FilmService(IGenericRepository<FilmModel> repository) : IFilmService
{
    public async Task<FilmResponse> AddFilmAsync(FilmCreateRequest createRequest)
    {
        var newFilm = new FilmModel
        {
            Name = createRequest.Name,
            Rating = createRequest.Rating,
            NumberOfMovies = createRequest.NumberOfMovies
        };

        await repository.AddAsync(newFilm);

        await repository.SaveAsync();

        return new FilmResponse
        {
            Id = newFilm.Id,
            Name = newFilm.Name,
            Rating = newFilm.Rating,
            NumberOfMovies = newFilm.NumberOfMovies
        };
    }

    public async Task DeleteFilmAsync(Guid Id)
    {
        var FilmDelete = await repository.GetByIdAsync(Id);

        if (FilmDelete is null)
            throw new KeyNotFoundException($"Film with Id: {Id}, has not been found");

        repository.Delete(FilmDelete);
        await repository.SaveAsync();
    }

    public async Task<List<FilmResponse>> GetAllFilmsAsync()
    => (await repository.GetAllAsync()).Select(x => new FilmResponse
        {
            Id = x.Id,
            Name = x.Name,
            Rating = x.Rating,
            NumberOfMovies = x.NumberOfMovies
        }).ToList();

    public async Task<FilmResponse?> GetFilmByIdAsync(Guid Id)
    {
        var FilmById = await repository.GetByIdAsync(Id);

        if (FilmById is null)
            throw new KeyNotFoundException($"Film with Id: {Id}, has not been found");

        return new FilmResponse
        {
            Id = FilmById.Id,
            Name = FilmById.Name,
            Rating = FilmById.Rating,
            NumberOfMovies = FilmById.NumberOfMovies
        };
    }

    public async Task PatchFilmAsync(Guid Id, FilmPatchRequest patchRequest)
    {
        var filmToPatch = await repository.GetByIdAsync(Id);

        if (filmToPatch is null)
            throw new KeyNotFoundException($"The film with Id {Id}, has not been found");

        if (patchRequest.Name is not null && patchRequest.Name != "")
        {
            if (patchRequest.Name.Length < 3)
                throw new ArgumentException("Name must be at least 3 characters long");
            else
                filmToPatch.Name = patchRequest.Name;
        }
        if (patchRequest.Rating.HasValue) filmToPatch.Rating = patchRequest.Rating.Value;
        if (patchRequest.NumberOfMovies.HasValue) filmToPatch.NumberOfMovies = patchRequest.NumberOfMovies.Value;
        filmToPatch.UpdateDateTime = DateTime.UtcNow;

        await repository.SaveAsync();
    }

    public async Task UpdateFilmAsync(Guid Id, FilmUpdateRequest updateRequest)
    {
        var filmToUpdate = await repository.GetByIdAsync(Id);

        if (filmToUpdate is null)
            throw new KeyNotFoundException($"The film with Id {Id}, has not been found");

        filmToUpdate.Name = updateRequest.Name;
        filmToUpdate.Rating = updateRequest.Rating;
        filmToUpdate.NumberOfMovies = updateRequest.NumberOfMovies;
        filmToUpdate.UpdateDateTime = DateTime.UtcNow;

        await repository.SaveAsync();
    }

    public async Task<List<FilmResponse>> GetPageAsync(int page, int size)
    {
        return (await repository.PageAsync(page, size))
        .Select(x => new FilmResponse
        {
            Id = x.Id,
            Name = x.Name,
            Rating = x.Rating,
            NumberOfMovies = x.NumberOfMovies
        })
        .ToList();
    }

    public async Task<List<FilmResponse>> SearchAsync(string quote)
    {
        return (await repository
        .SearchAsync(x=>x.Name.ToLower()
            .Contains(quote.ToLower())
            )
        )
        .Select(x => new FilmResponse
        {
            Id = x.Id,
            Name = x.Name,
            Rating = x.Rating,
            NumberOfMovies = x.NumberOfMovies
        })
        .ToList();
    }
    
}
