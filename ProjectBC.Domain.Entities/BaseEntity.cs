using System.Collections.Generic;
using System.Data;

namespace ProjectBC.Domain.Entities
{
    public class BaseEntity
    {
        protected readonly List<IDomainEvent> _events;
        public IEnumerable<IDomainEvent> Events
        {
            get => _events;
        }

        public BaseEntity()
        {
            _events = new List<IDomainEvent>();
        }

        public void ClearEvents()
        {
            _events.Clear();
        }
    }
}