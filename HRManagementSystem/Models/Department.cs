using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRManagementSystem.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }


        [Required(ErrorMessage = "Department Name is required")]
        [StringLength(100)]
        [Display(Name = "Department Name")]
        public string Name { get; set; }


        [StringLength(300)]
        [Display(Name = "Description")]
        public string? Description { get; set; }


        [Display(Name = "Department Code")]
        [StringLength(10)]
        public string? Code { get; set; }


        [Display(Name = "Is Active")]
        public bool IsActive { get; set; } = true;


     
        [Display(Name = "Manager")]
        public int? ManagerId { get; set; }


        [ForeignKey("ManagerId")]
        public virtual Employee? Manager { get; set; }


        public virtual ICollection<Employee>? Employees { get; set; }
    }
}
