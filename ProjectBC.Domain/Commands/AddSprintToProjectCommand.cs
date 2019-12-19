using ProjectBC.Domain.Entities;

namespace ProjectBC.Domain.Commands
{
    public class AddSprintToProjectCommand : IDomainCommand
    {
        public int ProjectId { get; }
        public Sprint Sprint { get; }

        public AddSprintToProjectCommand(int projectId, Sprint sprint )
        {
            ProjectId = projectId;
            Sprint = sprint;
        }
    }
}