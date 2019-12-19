using System;
using System.Threading.Tasks;

namespace ProjectBC.Domain.Commands
{
    public class AddSprintToProjectCommandHandler : IDomainCommandHandler
    {
        private readonly IProjectRepository _projectRepository;

        public AddSprintToProjectCommandHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
        public async Task HandleAsync(IDomainCommand command)
        {
            var cmd = command as AddSprintToProjectCommand;
            var pr = await _projectRepository.GetByIdAsync(cmd.ProjectId);
            pr.AddSprint(cmd.Sprint);
            await _projectRepository.UnitOfWork.CommitAsync();
        }

        public bool CanHandle(Type commandType) => commandType == this.GetType();
    }
}