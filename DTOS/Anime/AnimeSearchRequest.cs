using System.ComponentModel.DataAnnotations;

namespace AllSeriesApi.DTOS.Anime;

public class AnimeSearchRequest
{
    [Required]
    [MinLength(2)]
    public string quote { get; set; } = string.Empty;
}
