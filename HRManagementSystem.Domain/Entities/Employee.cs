using HRManagementSystem.Domain.Enums;
using HRManagementSystem.Domain.ValueObjects;
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
        public FullName FullName { get; private set; }
        public ContactInfo ContactInfo { get; private set; }
        public Address Address { get; private set; }
        public NationalIdentity NationalId { get; private set; }

        public Gender Gender { get; private set; }

        // Employment Details
        public DateTime DateOfBirth { get; private set; }
        public DateTime HireDate { get; private set; }
        public string JobTitle { get; private set; } = string.Empty;
        public Money Salary { get; private set; }
        public EmploymentStatus Status { get; private set; } = EmploymentStatus.Active;
        public JobLevel JobLevel { get; private set; }
        public ContractDetails ContractDetails { get; private set; } 
        public BankAccount BankAccount { get; private set; }

        // Relations
        public int DepartmentId { get; private set; }
        public Department? Department { get; private set; }

        // Extras
        public string? ProfileImagePath { get; private set; }

        // Business logic
        public void Terminate() => Status = EmploymentStatus.Terminated;
        public void Activate() => Status = EmploymentStatus.Active;
        public void SetOnLeave() => Status = EmploymentStatus.OnLeave;
        public void Resign() => Status = EmploymentStatus.Resigned;

        public void ChangeJobTitle(string newTitle)
        {
            if (newTitle.Length < 3)
                throw new ArgumentException("Job title must be at least 3 characters long.", nameof(newTitle));

            JobTitle = newTitle;
        }

        public void AssignToDepartment(int departmentId)
        {
            if (departmentId <= 0)
                throw new ArgumentException("Department ID must be greater than zero.", nameof(departmentId));

            DepartmentId = departmentId;
        }

        public void UnassignFromDepartment()
        {
            if (DepartmentId == 0)
                throw new InvalidOperationException("Employee is not assigned to any department.");
            DepartmentId = 0;
        }


        public void UpdateAddress(Address newAddress)
        {
            if (newAddress is null)
                throw new ArgumentNullException(nameof(newAddress), "Address cannot be null.");

            Address = newAddress;
        }

        public void UpdateContactInfo(ContactInfo newContactInfo)
        {
            if (newContactInfo == null)
                throw new ArgumentNullException(nameof(newContactInfo));

            ContactInfo = newContactInfo;
        }

        public void AdjustSalary(Money amount, bool increase = true)
        {
            if (amount == null)
                throw new ArgumentNullException(nameof(amount));

            if (amount.Amount <= 0)
                throw new ArgumentException("Salary adjustment amount must be greater than zero.", nameof(amount));

            Salary = increase 
                ? Salary.Add(amount) 
                : Salary.Subtract(amount);
        }

        public void Promote()
        {
            if (JobLevel == JobLevel.Director)
                throw new InvalidOperationException("Employee is already at the highest level.");
            JobLevel++;
        }

        public void Demote()
        {
            if (JobLevel == JobLevel.Intern)
                throw new InvalidOperationException("Employee is already at the lowest level.");
            JobLevel--;
        }

        public static Employee CreateNew(
    FullName fullName,
    ContactInfo contactInfo,
    Address address,
    NationalIdentity nationalId,
    Gender gender,
    DateTime dateOfBirth,
    Money startingSalary,
    ContractDetails contractDetails,
    BankAccount bankAccount)
        {
            if (dateOfBirth > DateTime.UtcNow)
                throw new ArgumentException("Date of birth cannot be in the future.", nameof(dateOfBirth));

            var today = DateTime.Today;
            int age = today.Year - dateOfBirth.Year;
            if (dateOfBirth.Date > today.AddYears(-age))
                age--;

            if (age < 18)
                throw new ArgumentException("Employee must be at least 18 years old.", nameof(dateOfBirth));

            if (startingSalary.Amount <= 0)
                throw new ArgumentException("Salary must be positive.", nameof(startingSalary));

            if (contractDetails is null)
                throw new ArgumentNullException(nameof(contractDetails));

            if (bankAccount is null)
                throw new ArgumentNullException(nameof(bankAccount));

            return new Employee
            {
                FullName = fullName,
                ContactInfo = contactInfo,
                Address = address,
                NationalId = nationalId,
                Gender = gender,
                DateOfBirth = dateOfBirth,
                HireDate = DateTime.UtcNow,
                Salary = startingSalary,
                ContractDetails = contractDetails,
                BankAccount = bankAccount,
                Status = EmploymentStatus.Active,
                JobLevel = JobLevel.Junior
            };
        }


    }
}
