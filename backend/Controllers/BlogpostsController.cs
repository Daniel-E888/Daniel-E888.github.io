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
    }
}
