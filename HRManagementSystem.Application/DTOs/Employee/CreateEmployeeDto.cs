using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagementSystem.Application.DTOs.Employee
{
    public class CreateEmployeeDto
    {
        // Basic info
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;

        // Identity info
        public string NationalId { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;

        // Address info
        public string Street { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;

        // Employment info
        public DateTime DateOfBirth { get; set; }
        public decimal Salary { get; set; }
        public int DepartmentId { get; set; }

        // Contract & Bank 
        public string BankAccountNumber { get; set; } = string.Empty;
        public string ContractType { get; set; } = "FullTime";
        public DateTime? ContractEndDate { get; set; }
    }
}
