using System.ComponentModel.DataAnnotations;
using AllSeriesApi.DTOS.Base;
namespace AllSeriesApi.DTOS.Anime;

public class AnimeResponse : BaseResponse
{
    [Required]
    [Range(0, int.MaxValue)]
    public int Episodes { get; set; }
    [Required]
    [Range(0,int.MaxValue)]
    public int Seasons { get; set; }
}
