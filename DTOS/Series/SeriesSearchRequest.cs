using System.ComponentModel.DataAnnotations;

namespace AllSeriesApi.DTOS.Series;

public class SeriesSearchRequest
{
    [Required]
    [MinLength(2)]
    public string quote { get; set; } = string.Empty;
}
