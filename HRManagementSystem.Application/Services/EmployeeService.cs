using AutoMapper;
using HRManagementSystem.Application.DTOs.Employee;
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
    public class EmployeeService:IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EmployeeDto>> GetAllAsync()
        {
            var employees = await _employeeRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<EmployeeDto>>(employees);
        }

        public async Task<EmployeeDetailsDto> GetByIdAsync(int id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);
            if (employee == null)
                throw new Exception($"Employee with ID {id} not found");

            return _mapper.Map<EmployeeDetailsDto>(employee);
        }

        public async Task CreateAsync(CreateEmployeeDto dto)
        {
            var employee = _mapper.Map<Employee>(dto);
            await _employeeRepository.AddAsync(employee);
        }

        public async Task UpdateAsync(UpdateEmployeeDto dto)
        {
            var existingEmployee = await _employeeRepository.GetByIdAsync(dto.Id);
            if (existingEmployee == null)
                throw new Exception($"Employee with ID {dto.Id} not found");

            _mapper.Map(dto, existingEmployee);
            await _employeeRepository.Update(existingEmployee);
        }

        public async Task DeleteAsync(int id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);
            if (employee == null)
                throw new Exception($"Employee with ID {id} not found");

            await _employeeRepository.Delete(employee);
        }
    }
}
