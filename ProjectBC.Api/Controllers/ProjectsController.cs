using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectBC.Domain;
using ProjectBC.Domain.Commands;
using ProjectBC.Domain.Entities;
using ProjectBC.Infrastructure;
using ProjectsBC.Api.Dtos;

namespace ProjectsBC.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IPublisher _publisher;

        public ProjectsController(IProjectRepository projectRepository, IPublisher publisher)
        {
            _projectRepository = projectRepository;
            _publisher = publisher;
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
            await _projectRepository.UnitOfWork.CommitAsync();
            
            return Ok();
        }
    }
}