using System.ComponentModel.DataAnnotations;

namespace AllSeriesApi.DTOS.Base;

public class SearchRequest
{
    [Required]
    [MinLength(2)]
    public string quote { get; set; } = string.Empty;
}
