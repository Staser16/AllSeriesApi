using AllSeriesApi.Repository;
using AllSeriesApi.Models;
using AllSeriesApi.DTOS.Film;
namespace AllSeriesApi.Servies.Film;

public class FilmService(IGenericRepository<FilmModel> repository) : IFilmService
{
    public Task<FilmResponse> AddFilmAsync(FilmCreateRequest createRequest)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteFilmAsync(Guid Id)
    {
        var FilmDelete = await repository.GetByIdAsync(Id);

        if (FilmDelete is null)
            throw new KeyNotFoundException($"Film with Id: {Id}, has not been found");

        await repository.DeleteAsync(FilmDelete);
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

    public Task PatchFilmAsync(Guid Id, FilmPatchRequest patchRequest)
    {
        throw new NotImplementedException();
    }

    public Task UpdateFilmAsync(Guid Id, FilmUpdateRequest updateRequest)
    {
        throw new NotImplementedException();
    }
}
