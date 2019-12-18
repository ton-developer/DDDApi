using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectBC.Domain.Entities.Exceptions;

namespace ProjectBC.Domain.Entities
{
    public class Project
    {
        private readonly List<Sprint> _sprints;
        public int Id { get; set; }
        public string Description { get; set; }
        public ICollection<Pbi> Backlog { get; set; }

        public IEnumerable<Sprint> Sprints
        {
            get => _sprints;
        }
        public Team Team { get; set; }

        public Project()
        {
            _sprints = new List<Sprint>();
        }
        public void AddSprint(Sprint sprintToAdd)
        {
            if (!CheckOverlapping(sprintToAdd))
            {
                _sprints.Add(sprintToAdd);
            }
            else
            {
                throw new DomainException($"Cannot add sprint due overlap on dates.");
            }
        }

        private bool CheckOverlapping(Sprint newSprint)
        {
            return Sprints.Any(x => x.OverlapsWith(newSprint));
        }
    }
}
