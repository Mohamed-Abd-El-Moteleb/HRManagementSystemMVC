using Microsoft.EntityFrameworkCore;

namespace HRManagementSystem.Models
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options) { }
        
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>()
              .HasOne(e => e.Department)
              .WithMany(d => d.Employees)
              .HasForeignKey(e => e.DepartmentId)
              .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Department>()
               .HasOne(d => d.Manager)
               .WithMany()
               .HasForeignKey(d => d.ManagerId)
               .OnDelete(DeleteBehavior.SetNull);

            //  Department seeding
            modelBuilder.Entity<Department>().HasData(
                new Department
                {
                    Id = 1,
                    Name = "Unassigned",
                    Description = "Default department for new or unassigned employees"
                }
            );
        }
    }
}
