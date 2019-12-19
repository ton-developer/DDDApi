using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectBC.Domain;
using ProjectBC.Domain.Entities;

namespace ProjectBC.Infrastructure
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly ProjectsDbContext _ctx;

        public ProjectRepository(ProjectsDbContext ctx)
        {
            _ctx = ctx;
        }

        public IUnitOfWork UnitOfWork => _ctx;

        public async Task<Project> GetByIdAsync(int id)
        {
            return await _ctx.Projects
                .Include(x => x.Sprints)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}