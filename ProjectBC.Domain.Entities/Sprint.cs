using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectBC.Domain.Entities
{
    public class Sprint
    {
        public int Id { get; set; }
        public int Number { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Duration
        {
            get => (EndDate - StartDate).Days;
        }
    }
}
