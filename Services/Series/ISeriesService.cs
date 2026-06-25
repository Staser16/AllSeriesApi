using AllSeriesApi.DTOS.Series;
namespace AllSeriesApi.Services.Series;

public interface ISeriesService
{
    public Task<List<SeriesResponse>> GetAllSeriesAsync();
    public Task<SeriesResponse?> GetSeriesByIdAsync(Guid Id);
    public Task<SeriesResponse> AddSeriesAsync(SeriesCreateRequest createRequest);
    public Task UpdateSeriesAsync(Guid Id, SeriesUpdateRequest updateRequest);
    public Task PatchSeriesAsync(Guid Id, SeriesPatchRequest patchRequest);
    public Task DeleteSeriesAsync(Guid Id);
    public Task<List<SeriesResponse>> GetPageAsync(int page, int size);
    public Task<List<SeriesResponse>> SearchAsync(string quote);
}
