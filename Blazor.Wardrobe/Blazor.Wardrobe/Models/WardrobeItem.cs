namespace Blazor.Wardrobe.Models;

public class WardrobeItem
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; } = string.Empty;
    public string? ImageUrl { get; set; } = string.Empty;
    public string? Category { get; set; } = string.Empty;
    public string? Brand { get; set; } = string.Empty;
}
