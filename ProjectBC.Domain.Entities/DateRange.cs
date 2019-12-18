using ProjectBC.Domain.Entities.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectBC.Domain.Entities
{
    public class DateRange
    {
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public int Duration
        {
            get => (EndDate - StartDate).Days;
        }

        private DateRange() { }

        public DateRange(DateTime startDate, DateTime endDate)
        {
            if (endDate <= startDate)
            {
                throw new DomainException($"End date {endDate} cannot happend before the start date {startDate}");
            }

            StartDate = startDate;
            EndDate = endDate;
        }

        public static bool operator ==(DateRange one, DateRange two)
            => one.EndDate == two.EndDate && one.StartDate == two.StartDate;

        public static bool operator !=(DateRange one, DateRange two)
            => !(one == two);

        public override bool Equals(object obj)
        {
            if (obj is DateRange)
            {
                return ((DateRange)obj) == this;
            }
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return Duration.GetHashCode();
        }
    }
}
