using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectBC.Api.Queries;
using ProjectBC.Domain;
using ProjectBC.Domain.Commands;
using ProjectBC.Domain.Entities;
using ProjectBC.Infrastructure;
using ProjectsBC.Api.Dtos;
using ProjectsBC.Api.Queries;

namespace ProjectsBC.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IPublisher _publisher;
        private readonly IProjectQueries _projectQueries;

        public ProjectsController(IPublisher publisher, IProjectQueries projectQueries)
        {
            _publisher = publisher;
            _projectQueries = projectQueries;
        }
        [HttpPost]
        [Route("{projectId}/sprints")]
        public async Task<IActionResult> AddSprintToProject(int projectId, SprintDto sprint)
        {
            var sprintToAdd = new Sprint
            {
                DateRange = new DateRange(sprint.Start, sprint.Start.AddDays(sprint.Days))
            };

            var command = new AddSprintToProjectCommand(projectId, sprintToAdd);
            await _publisher.Publish(command);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetProjectsWithSprintsCount()
        {
            return Ok(await _projectQueries.GetAllWithSprints());
        }
    }
}