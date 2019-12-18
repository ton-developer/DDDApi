using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectBC.Domain.Entities;
using ProjectBC.Infrastructure;
using ProjectsBC.Api.Dtos;

namespace ProjectsBC.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly ProjectsDbContext _db;

        public ProjectsController(ProjectsDbContext db)
        {
            _db = db;
        }
        [HttpPost]
        [Route("{projectId}/sprints")]
        public async Task<IActionResult> AddSprintToProject(int projectId, SprintDto sprint)
        {
            var sprintToAdd = new Sprint
            {
                DateRange = new DateRange(sprint.Start, sprint.Start.AddDays(sprint.Days))
            };

            var project = _db.Projects.Include(p => p.Sprints).
                FirstOrDefault(x => x.Id == projectId);
            if (project == null)
            {
                return NotFound();
            }
            
            project.AddSprint(sprintToAdd);

            await _db.SaveChangesAsync();
            
            return Ok();
        }
    }
}