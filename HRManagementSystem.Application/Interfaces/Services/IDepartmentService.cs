using HRManagementSystem.Application.DTOs.Department;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagementSystem.Application.Interfaces.Services
{
    public interface IDepartmentService
    {
        Task<IEnumerable<DepartmentDto>> GetAllAsync();
        Task<DepartmentDetailsDto> GetByIdAsync(int id);
        Task CreateAsync(CreateDepartmentDto dto);
        Task UpdateAsync(UpdateDepartmentDto dto);
        Task DeleteAsync(int id);
    }

}
