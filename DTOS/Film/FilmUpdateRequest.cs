using System.ComponentModel.DataAnnotations;
namespace AllSeriesApi.DTOS.Film;

public class FilmUpdateRequest
{
    [Required]
    [MinLength(3)]
    public string Name { get; set; } = string.Empty;
    [Required]
    [Range(1, 10)]
    public int Rating { get; set; }
    [Required]
    [Range(0, int.MaxValue)]
    public int NumberOfMovies { get; set; }
}
