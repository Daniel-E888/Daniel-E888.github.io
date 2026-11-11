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

    public async Task<BlogpostDto> CreateAsync(BlogpostCreateDto dto)
    {
        var blogpost = ToEntity(dto);
        _context.Blogposts.Add(blogpost);
        await _context.SaveChangesAsync();
        return ToDto(blogpost);
    }

    public async Task<bool> UpdateAsync(int id, BlogpostCreateDto dto)
    {
        var blogpost = await _context.Blogposts.FindAsync(id);
        if (blogpost == null)
        {
            return false;
        }

        blogpost.Titel = dto.Titel;
        blogpost.Inhoud = dto.Inhoud;
        blogpost.Publicatiedatum = dto.Publicatiedatum;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var blogpost = await _context.Blogposts.FindAsync(id);
        if (blogpost == null)
        {
            return false;
        }

        _context.Blogposts.Remove(blogpost);
        await _context.SaveChangesAsync();
        return true;
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

    private static Blogpost ToEntity(BlogpostCreateDto dto)
    {
        return new Blogpost
        {
            Titel = dto.Titel,
            Inhoud = dto.Inhoud,
            Publicatiedatum = dto.Publicatiedatum
        };
    }
}
