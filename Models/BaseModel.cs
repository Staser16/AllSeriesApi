namespace AllSeriesApi.Models;

public class BaseModel
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Rating { get; set; }
    public DateTime CreationDateTime { get; set; } = DateTime.UtcNow;
    public DateTime? UpdateDateTime { get; set; }
}
