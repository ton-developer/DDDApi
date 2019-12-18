using Microsoft.AspNetCore.Mvc;
using ProjectBC.Domain.Entities;

namespace ProjectsBC.Api.Controllers
{
    [Route("api/[controller]")]
    public class ProjectsController : ControllerBase
    {
        // GET
        public IActionResult AddSprintToProject(int projectId, Sprint sprint)
        {
            return Ok();
        }
    }
}