using System.ComponentModel.DataAnnotations;
namespace AllSeriesApi.DTOS.Film;

public class FilmPatchRequest
{
    public string? Name { get; set; } = string.Empty;
    [Range(1, 10)]
    public int? Rating { get; set; }
    [Range(0, int.MaxValue)]
    public int? NumberOfMovies { get; set; }
}
