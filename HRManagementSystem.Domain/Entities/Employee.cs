using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagementSystem.Domain.Entities
{
    public class Employee
    {
        public int Id { get; set; }

        // Basic Info
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty; // Male / Female

        // Employment Details
        public DateTime DateOfBirth { get; set; }
        public DateTime HireDate { get; set; }
        public string JobTitle { get; set; } = string.Empty;
        public decimal Salary { get; set; }
        public bool IsActive { get; private set; } = true;

        // Relations
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }

        // Extras
        public string NationalId { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string? ProfileImagePath { get; set; }

        // Business logic
        public void Deactivate() => IsActive = false;
        public void Activate() => IsActive = true;


    }
}
