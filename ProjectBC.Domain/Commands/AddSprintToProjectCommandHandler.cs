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
        public async Task Handle(IDomainCommand command)
        {
            var cmd = command as AddSprintToProjectCommand;
            var pr = await _projectRepository.GetByIdAsync(cmd.ProjectId);
            pr.AddSprint(cmd.Sprint);
        }

        public bool CanHandle(Type commandType) => commandType == this.GetType();
    }
}