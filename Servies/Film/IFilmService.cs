using AllSeriesApi.DTOS.Film;
using AllSeriesApi.DTOS.Series;
namespace AllSeriesApi.Servies.Film;

public interface IFilmService
{
    public Task<List<FilmResponse>> GetAllFilmsAsync();
    public Task<FilmResponse?> GetFilmByIdAsync(Guid Id);
    public Task<FilmResponse> AddFilmAsync(FilmCreateRequest createRequest);
    public Task UpdateFilmAsync(Guid Id, FilmUpdateRequest updateRequest);
    public Task PatchFilmAsync(Guid Id, FilmPatchRequest patchRequest);
    public Task DeleteFilmAsync(Guid Id);
    public Task<List<FilmResponse>> GetPageAsync(int page, int size);
    public Task<List<FilmResponse>> SearchAsync(string quote);
}
