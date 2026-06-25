using AllSeriesApi.DTOS.Anime;
using AllSeriesApi.Services.Series;
namespace AllSeriesApi.Servies.Anime;

public interface IAnimeService
{
    public Task<List<AnimeResponse>> GetAllAnimeAsync();
    public Task<AnimeResponse?> GetAnimeByIdAsync(Guid Id);
    public Task<AnimeResponse> AddAnimeAsync(AnimeCreateRequest createRequest);
    public Task UpdateAnimeAsync(Guid Id, AnimeUpdateRequest updateRequest);
    public Task PatchAnimeAsync(Guid Id, AnimePatchRequest patchRequest);
    public Task DeleteAnimeAsync(Guid Id);
    public Task<List<AnimeResponse>> GetPageAsync(int page, int size);
    public Task<List<AnimeResponse>> SearchAsync(string quote);
}
