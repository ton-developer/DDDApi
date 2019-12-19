using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectBC.Api.Queries;
using ProjectBC.Infrastructure;
using ProjectsBC.Api.Queries.Dtos;

namespace ProjectsBC.Api.Queries
{
    public class ProjectQueries : IProjectQueries
    {
        private readonly ProjectsDbContext _projectsDbContext;

        public ProjectQueries(ProjectsDbContext projectsDbContext)
        {
            _projectsDbContext = projectsDbContext;
        }
        
        public async Task<IEnumerable<ProjectListItem>> GetAllWithSprints()
        {
            return await _projectsDbContext.Projects
                .Include(x => x.Sprints)
                .Include(x => x.Team)
                .Select(x => new ProjectListItem()
                {
                    Id = x.Id,
                    name = x.Description,
                    TeamName = x.Team.Name,
                    SprintCount = x.Sprints.Count()
                })
                .ToListAsync();
        }
    }
}