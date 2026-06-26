using AllSeriesApi.DTOS.Series;
namespace AllSeriesApi.Services.Series;

public interface ISeriesService
{
    public Task<List<SeriesResponse>> GetAllSeriesAsync(CancellationToken ct);
    public Task<SeriesResponse?> GetSeriesByIdAsync(Guid Id, CancellationToken ct);
    public Task<SeriesResponse> AddSeriesAsync(SeriesCreateRequest createRequest, CancellationToken ct);
    public Task UpdateSeriesAsync(Guid Id, SeriesUpdateRequest updateRequest, CancellationToken ct);
    public Task PatchSeriesAsync(Guid Id, SeriesPatchRequest patchRequest, CancellationToken ct);
    public Task DeleteSeriesAsync(Guid Id, CancellationToken ct);
    public Task<List<SeriesResponse>> GetPageAsync(int page, int size, CancellationToken ct);
    public Task<List<SeriesResponse>> SearchAsync(string quote, CancellationToken ct);
}
