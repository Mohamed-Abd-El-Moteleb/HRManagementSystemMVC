using AutoMapper;
using HRManagementSystem.Application.DTOs.Department;
using HRManagementSystem.Application.Interfaces.Repositories;
using HRManagementSystem.Application.Interfaces.Services;
using HRManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagementSystem.Application.Services
{
        public class DepartmentService : IDepartmentService
        {
            private readonly IDepartmentRepository _departmentRepository;
            private readonly IMapper _mapper;

            public DepartmentService(IDepartmentRepository departmentRepository, IMapper mapper)
            {
                _departmentRepository = departmentRepository;
                _mapper = mapper;
            }

            public async Task<IEnumerable<DepartmentDto>> GetAllAsync()
            {
                var departments = await _departmentRepository.GetAllAsync();
                return _mapper.Map<IEnumerable<DepartmentDto>>(departments);
            }

            public async Task<DepartmentDetailsDto> GetByIdAsync(int id)
            {
                var department = await _departmentRepository.GetByIdAsync(id);
                if (department == null)
                    throw new Exception($"Department with ID {id} not found");

                return _mapper.Map<DepartmentDetailsDto>(department);
            }

            public async Task CreateAsync(CreateDepartmentDto dto)
            {
                var department = _mapper.Map<Department>(dto);
                await _departmentRepository.AddAsync(department);
            }

            public async Task UpdateAsync(UpdateDepartmentDto dto)
            {
                var existingDepartment = await _departmentRepository.GetByIdAsync(dto.Id);
                if (existingDepartment == null)
                    throw new Exception($"Department with ID {dto.Id} not found");

                _mapper.Map(dto, existingDepartment);
                await _departmentRepository.Update(existingDepartment);
            }

            public async Task DeleteAsync(int id)
            {
                var department = await _departmentRepository.GetByIdAsync(id);
                if (department == null)
                    throw new Exception($"Department with ID {id} not found");

                await _departmentRepository.Delete(department);
            }
        }
    
}
