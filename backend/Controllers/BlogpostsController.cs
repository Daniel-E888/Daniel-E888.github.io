using Microsoft.AspNetCore.Mvc;
using backend.DTOs;
using backend.Services;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogpostsController : ControllerBase
    {
        private readonly BlogpostService _service;

        public BlogpostsController(BlogpostService service)
        {
            _service = service;
        }

        // GET: api/Blogposts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BlogpostDto>>> GetBlogposts()
        {
            return Ok(await _service.GetAllAsync());
        }

        // GET: api/Blogposts/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<BlogpostDto>> GetBlogpost(int id)
        {
            var blogpost = await _service.GetByIdAsync(id);
            return blogpost == null ? NotFound() : Ok(blogpost);
        }

        // POST: api/Blogposts
        [HttpPost]
        public async Task<ActionResult<BlogpostDto>> PostBlogpost(BlogpostCreateDto dto)
        {
            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetBlogpost), new { id = created.Id }, created);
        }

        // PUT: api/Blogposts/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBlogpost(int id, BlogpostCreateDto dto)
        {
            var updated = await _service.UpdateAsync(id, dto);
            return updated ? NoContent() : NotFound();
        }

        // DELETE: api/Blogposts/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlogpost(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            return deleted ? NoContent() : NotFound();
        }
    }
}
