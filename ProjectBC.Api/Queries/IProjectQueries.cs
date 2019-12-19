using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectsBC.Api.Queries.Dtos;

namespace ProjectBC.Api.Queries
{
    public interface IProjectQueries
    {
        Task<IEnumerable<ProjectListItem>> GetAllWithSprints();
    }
}