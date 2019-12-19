namespace ProjectBC.Domain.Entities
{
    public class TaskStatusChanged : IDomainEvent
    {
        public int Id { get; }
        public ProjectTaskStatus OldStatus { get; }
        public ProjectTaskStatus NewStatus { get; }

        public TaskStatusChanged(int id, ProjectTaskStatus oldStatus, ProjectTaskStatus newStatus)
        {
            Id = id;
            OldStatus = oldStatus;
            NewStatus = newStatus;
        }
    }
}