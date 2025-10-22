using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagementSystem.Domain.ValueObjects
{
    public class FullName
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        private FullName() { } 

        public FullName(string firstName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentException("First name is required.", nameof(firstName));
            if (string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException("Last name is required.", nameof(lastName));
            FirstName = firstName;
            LastName = lastName;
        }
        public override string ToString() => $"{FirstName} {LastName}";
    }
}
