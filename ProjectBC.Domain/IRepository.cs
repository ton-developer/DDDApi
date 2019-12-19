using System.Threading.Tasks;
using ProjectBC.Domain.Entities;

namespace ProjectBC.Domain
{
    public interface IProjectRepository
    {
        Task<Project> GetByIdAsync(int id);
    }
}