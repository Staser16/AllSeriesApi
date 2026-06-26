using System.ComponentModel.DataAnnotations;
using AllSeriesApi.DTOS.Base;
namespace AllSeriesApi.DTOS.Film;

public class FilmPatchRequest : BasePatchRequest
{
    [Range(0, int.MaxValue)]
    public int? NumberOfMovies { get; set; }
}
