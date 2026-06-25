namespace AllSeriesApi.Models;

public class AnimeModel
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Rating { get; set; }
    public int Episodes { get; set; }
    public int Seasons { get; set; }
    public DateTime CreationDateTime { get; set; } = DateTime.UtcNow;
    public DateTime? UpdateDateTime { get; set; }

}
