using Blazor.Wardrobe.Data;
using Blazor.Wardrobe.Models;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;

namespace Blazor.Wardrobe.Services;

public class WardrobeItemService
{
    private readonly WardrobeContext _context;
    public WardrobeItemService(WardrobeContext context)
    {
        _context = context;
    }
    public async Task<List<WardrobeItem>?> GetAllAsync()
    {
        return await _context.WardrobeItems.ToListAsync();
    }

    public async Task<WardrobeItem?> GetByIdAsync(int id)
    {
        return await _context.WardrobeItems.FindAsync(id);
    }

    public async Task<bool> AddAsync(WardrobeItem item)
    {
        try
        {
            await _context.WardrobeItems.AddAsync(item);
            await _context.SaveChangesAsync();

            return true;
        } catch (Exception err)
        {
            return false;
        }
    }

    public async Task<bool> UpdateAsync(WardrobeItem item)
    {
        var existingItem = await _context.WardrobeItems.FindAsync(item.Id);

        if (existingItem == null)
            throw new Exception($"Wardrobe item with ID {item.Id} not found.");

        existingItem.Description = item.Description;
        existingItem.ImageUrl = item.ImageUrl;
        existingItem.Category = item.Category;
        existingItem.Brand = item.Brand;
        existingItem.Name = item.Name;

        _context.WardrobeItems.Update(existingItem);
        _context.SaveChanges();

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var item = await _context.WardrobeItems.FindAsync(id);
        if (item == null)
            throw new Exception($"Wardrobe item with ID {id} not found.");
        _context.WardrobeItems.Remove(item);
        _context.SaveChanges();
        return true;
    }
}
