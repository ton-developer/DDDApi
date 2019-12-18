using ProjectBC.Domain.Entities;

namespace ProjectBC.Domain
{
    public interface IProjectRepository
    {
        Project GetById(int id);
    }
}