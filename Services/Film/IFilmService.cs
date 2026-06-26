using AllSeriesApi.DTOS.Film;
using AllSeriesApi.DTOS.Series;
namespace AllSeriesApi.Servies.Film;

public interface IFilmService
{
    public Task<List<FilmResponse>> GetAllFilmsAsync(CancellationToken ct);
    public Task<FilmResponse?> GetFilmByIdAsync(Guid Id, CancellationToken ct);
    public Task<FilmResponse> AddFilmAsync(FilmCreateRequest createRequest, CancellationToken ct);
    public Task UpdateFilmAsync(Guid Id, FilmUpdateRequest updateRequest, CancellationToken ct);
    public Task PatchFilmAsync(Guid Id, FilmPatchRequest patchRequest,CancellationToken ct);
    public Task DeleteFilmAsync(Guid Id, CancellationToken ct);
    public Task<List<FilmResponse>> GetPageAsync(int page, int size, CancellationToken ct);
    public Task<List<FilmResponse>> SearchAsync(string quote, CancellationToken ct);
}
