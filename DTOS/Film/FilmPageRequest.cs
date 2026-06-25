using System.ComponentModel.DataAnnotations;
namespace AllSeriesApi.DTOS.Film;

public class FilmPageRequest
{
    [Required]
    [Range(1, int.MaxValue)]
    public int page { get; set; }
    [Required]
    [Range(1,int.MaxValue)]
    public int size { get; set; }
}
