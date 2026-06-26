using System.ComponentModel.DataAnnotations;
using AllSeriesApi.DTOS.Base;
namespace AllSeriesApi.DTOS.Anime;

public class AnimePatchRequest : BasePatchRequest
{
    [Range(0, int.MaxValue)]
    public int? Episodes { get; set; }
    [Range(0,int.MaxValue)]
    public int? Seasons { get; set; }
}
