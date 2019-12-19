using System.Threading.Tasks;
using ProjectBC.Domain.Entities;

namespace ProjectBC.Domain
{
    public interface IProjectRepository
    {
        IUnitOfWork UnitOfWork { get; }
        Task<Project> GetByIdAsync(int id);
    }
}