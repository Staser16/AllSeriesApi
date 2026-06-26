using System.ComponentModel.DataAnnotations;

namespace AllSeriesApi.DTOS.Base;

public class BasePatchRequest
{
    public string? Name { get; set; } = string.Empty;
    [Range(1, 10)]
    public int? Rating { get; set; }
}
