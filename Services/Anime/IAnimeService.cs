using System.ComponentModel;
using AllSeriesApi.DTOS.Anime;
using AllSeriesApi.Services.Series;
namespace AllSeriesApi.Servies.Anime;

public interface IAnimeService
{
    public Task<List<AnimeResponse>> GetAllAnimeAsync(CancellationToken ct);
    public Task<AnimeResponse?> GetAnimeByIdAsync(Guid Id, CancellationToken ct);
    public Task<AnimeResponse> AddAnimeAsync(AnimeCreateRequest createRequest, CancellationToken ct);
    public Task UpdateAnimeAsync(Guid Id, AnimeUpdateRequest updateRequest, CancellationToken ct);
    public Task PatchAnimeAsync(Guid Id, AnimePatchRequest patchRequest, CancellationToken ct);
    public Task DeleteAnimeAsync(Guid Id, CancellationToken ct);
    public Task<List<AnimeResponse>> GetPageAsync(int page, int size, CancellationToken ct);
    public Task<List<AnimeResponse>> SearchAsync(string quote, CancellationToken ct);
}
