using Microsoft.AspNetCore.Mvc;
using backend.DTOs;
using backend.Services;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly ProjectService _service;

        public ProjectsController(ProjectService service)
        {
            _service = service;
        }

        // GET: api/Projects
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectDto>>> GetProjects()
        {
            return Ok(await _service.GetAllAsync());
        }

        // GET: api/Projects/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectDto>> GetProject(int id)
        {
            var project = await _service.GetByIdAsync(id);
            return project == null ? NotFound() : Ok(project);
        }

        // POST: api/Projects
        [HttpPost]
        public async Task<ActionResult<ProjectDto>> PostProject(ProjectCreateDto dto)
        {
            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetProject), new { id = created.Id }, created);
        }

        // PUT: api/Projects/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProject(int id, ProjectCreateDto dto)
        {
            var updated = await _service.UpdateAsync(id, dto);
            return updated ? NoContent() : NotFound();
        }

        // DELETE: api/Projects/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            return deleted ? NoContent() : NotFound();
        }
    }
}
