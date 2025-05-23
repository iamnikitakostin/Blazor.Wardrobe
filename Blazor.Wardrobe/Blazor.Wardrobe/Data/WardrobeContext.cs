using Blazor.Wardrobe.Models;
using Microsoft.EntityFrameworkCore;

namespace Blazor.Wardrobe.Data;

public class WardrobeContext : DbContext
{
    public WardrobeContext(DbContextOptions<WardrobeContext> options) : base(options)
    {
    }
    public DbSet<WardrobeItem> WardrobeItems { get; set; } = null!;
}
