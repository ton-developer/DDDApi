using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectBC.Domain.Entities
{
    public class Task : BaseEntity
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public ProjectTaskStatus Status { get;  private set; }
        public User Owner { get; set; }

        public Task() : base()
        {
            
        }
        
        public void SetStatus(ProjectTaskStatus newStatus)
        {
            var oldStatus = newStatus;
            Status = newStatus;
            _events.Add( new TaskStatusChanged(Id, oldStatus, newStatus));
        }
    }
}
