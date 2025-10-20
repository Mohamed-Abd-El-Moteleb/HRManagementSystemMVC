using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRManagementSystem.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [StringLength(50)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }


        [NotMapped]
        [Display(Name = "Full Name")]
        public string FullName => $"{FirstName} {LastName}";


        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [StringLength(100)]
        public string Email { get; set; }


        [Phone]
        [Display(Name = "Phone Number")]
        [StringLength(20)]
        public string PhoneNumber { get; set; }


        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        [CustomValidation(typeof(Employee), nameof(ValidateAge))]
        public DateTime DateOfBirth { get; set; }


        [Display(Name = "Hire Date")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Hire Date is required")]
        public DateTime HireDate { get; set; }

        [Required(ErrorMessage = "Job Title is required")]
        [StringLength(50)]
        [Display(Name = "Job Title")]
        public string JobTitle { get; set; }


        [Range(0, 2000000, ErrorMessage = "Salary must be positive")]
        [Column(TypeName = "decimal(18,2)")]
        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }


        [Display(Name = "Gender")]
        public string Gender { get; set; } // Male / Female


        [Display(Name = "Address")]
        [StringLength(200)]
        public string Address { get; set; }


        [Display(Name = "National ID")]
        [StringLength(14, MinimumLength = 14, ErrorMessage = "National ID must be 14 digits")]
        public string NationalId { get; set; }


        [Display(Name = "Is Active Employee?")]
        public bool IsActive { get; set; } = true;


        [Display(Name = "Profile Picture")]
        public string? ProfileImagePath { get; set; } // for image upload later

        [Display(Name = "Department")]
        public int DepartmentId { get; set; }

        [ForeignKey("DepartmentId")]
        public virtual Department? Department { get; set; }


        public static ValidationResult ValidateAge(DateTime birthDate, ValidationContext context)
        {
            var today = DateTime.Today;
            var minimumDate = today.AddYears(-18); 

            if (birthDate > minimumDate)
                return new ValidationResult("Employee Age Should be 18 At Least");

            return ValidationResult.Success;
        }
    }
}
