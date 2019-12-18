using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectBC.Domain.Entities
{
    public class Project
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public ICollection<Pbi> Backlog { get; set; }
        public ICollection<Sprint> Sprints { get; set; }

    }
}
