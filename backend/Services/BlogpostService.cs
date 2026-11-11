using Microsoft.EntityFrameworkCore;
using backend.Data;
using backend.DTOs;
using backend.Models;

namespace backend.Services;

public class BlogpostService
{
    private readonly PortfolioDbContext _context;

    public BlogpostService(PortfolioDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<BlogpostDto>> GetAllAsync()
    {
        var blogposts = await _context.Blogposts.ToListAsync();
        return blogposts.Select(ToDto);
    }

    public async Task<BlogpostDto?> GetByIdAsync(int id)
    {
        var blogpost = await _context.Blogposts.FindAsync(id);
        return blogpost == null ? null : ToDto(blogpost);
    }

    private static BlogpostDto ToDto(Blogpost blogpost)
    {
        return new BlogpostDto
        {
            Id = blogpost.Id,
            Titel = blogpost.Titel,
            Inhoud = blogpost.Inhoud,
            Publicatiedatum = blogpost.Publicatiedatum
        };
    }
}
