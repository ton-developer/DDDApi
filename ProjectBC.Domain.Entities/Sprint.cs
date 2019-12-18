using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectBC.Domain.Entities
{
    public class Sprint
    {
        public int Id { get; set; }
        public DateRange DateRange { get; set; }

        public bool OverlapsWith(Sprint newSprint)
        {
            if (newSprint.DateRange.StartDate < this.DateRange.StartDate)
            {
                if (newSprint.DateRange.EndDate > this.DateRange.StartDate)
                {
                    return true;
                }
            }
            else
            {
                if (newSprint.DateRange.StartDate < this.DateRange.EndDate)
                {
                    return true;
                }
            }
            return false;
        }
    }
}

