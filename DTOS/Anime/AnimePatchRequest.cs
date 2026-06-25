using System.ComponentModel.DataAnnotations;
namespace AllSeriesApi.DTOS.Anime;

public class AnimePatchRequest
{
    public string? Name { get; set; } = string.Empty;
    [Range(1, 10)]
    public int? Rating { get; set; }
    [Range(0, int.MaxValue)]
    public int? Episodes { get; set; }
    [Range(0,int.MaxValue)]
    public int? Seasons { get; set; }
}
