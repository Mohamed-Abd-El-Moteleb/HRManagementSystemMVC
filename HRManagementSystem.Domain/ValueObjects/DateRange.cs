using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagementSystem.Domain.ValueObjects
{
        public class DateRange
        {
            public DateTime StartDate { get; private set; }
            public DateTime EndDate { get; private set; }

            public DateRange(DateTime startDate, DateTime endDate)
            {
                if (endDate < startDate)
                    throw new ArgumentException("End date cannot be earlier than start date.");

                StartDate = startDate;
                EndDate = endDate;
            }

            public int TotalDays => (EndDate - StartDate).Days + 1;

            public bool Overlaps(DateRange other)
            {
                if (other == null) return false;

                return StartDate <= other.EndDate && EndDate >= other.StartDate;
            }

            public bool Includes(DateTime date)
            {
                return date >= StartDate && date <= EndDate;
            }
        }
}
