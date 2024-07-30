namespace RSS_Feeder.Models;

public class Item
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? Link { get; set; }
    public string? Guid { get; set; }
    public string? Category { get; set; }
    public string? PubDate { get; set; }
}