using System.ComponentModel.DataAnnotations;
namespace AllSeriesApi.DTOS.Series;

public class SeriesResponse
{
    [Required]
    [MinLength(1)]
    public Guid Id { get; set; }
    [Required]
    [MinLength(3)]
    public string Name { get; set; } = string.Empty;
    [Required]
    [Range(1, 10)]
    public int Rating { get; set; }
    [Required]
    [Range(0, int.MaxValue)]
    public int Episodes { get; set; }
    [Required]
    [Range(0,int.MaxValue)]
    public int Seasons { get; set; }
}
