using System.ComponentModel.DataAnnotations;

namespace AllSeriesApi.DTOS.Base;

public class BaseCreateRequest
{
    [Required]
    [MinLength(3)]
    public string Name { get; set; } = string.Empty;
    [Required]
    [Range(1, 10)]
    public int Rating { get; set; }
}
