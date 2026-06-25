using System.ComponentModel.DataAnnotations;

namespace AllSeriesApi.DTOS.Film;

public class FilmSearchRequest
{
    [Required]
    [MinLength(2)]
    public string quote { get; set; } = string.Empty;
}
