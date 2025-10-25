﻿using AutoMapper;
using HRManagementSystem.Application.DTOs.Department;
using HRManagementSystem.Application.DTOs.Employee;
using HRManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagementSystem.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Employee, EmployeeDto>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName.ToString()))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address.ToString()))
                .ForMember(dest => dest.Salary, opt => opt.MapFrom(src => src.Salary.Amount))
                .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department != null ? src.Department.Name : string.Empty));

            CreateMap<Employee, EmployeeDetailsDto>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName.ToString()))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.ContactInfo.Email))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.ContactInfo.PhoneNumber))
                .ForMember(dest => dest.EmergencyContactName, opt => opt.MapFrom(src => src.ContactInfo.EmergencyContactName))
                .ForMember(dest => dest.EmergencyContactPhone, opt => opt.MapFrom(src => src.ContactInfo.EmergencyContactPhone))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address.ToString()))
                .ForMember(dest => dest.NationalId, opt => opt.MapFrom(src => src.NationalId.NationalId))
                .ForMember(dest => dest.JobLevel, opt => opt.MapFrom(src => src.JobLevel.ToString()))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()))
                .ForMember(dest => dest.ContractType, opt => opt.MapFrom(src => src.ContractDetails.ContractType.ToString()))
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.ContractDetails.StartDate))
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.ContractDetails.EndDate))
                .ForMember(dest => dest.BankName, opt => opt.MapFrom(src => src.BankAccount.BankName))
                .ForMember(dest => dest.AccountNumber, opt => opt.MapFrom(src => src.BankAccount.AccountNumber))
                .ForMember(dest => dest.IBAN, opt => opt.MapFrom(src => src.BankAccount.IBAN))
                .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department != null ? src.Department.Name : string.Empty))
                .ForMember(dest => dest.Salary, opt => opt.MapFrom(src => src.Salary.Amount))
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => DateTime.Now.Year - src.DateOfBirth.Year));

            CreateMap<CreateEmployeeDto, Employee>();
            CreateMap<UpdateEmployeeDto, Employee>();

            // Department
            CreateMap<Department, DepartmentDetailsDto>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.IsActive ? "Active" : "Inactive"))
                .ForMember(dest => dest.ManagerName, opt => opt.MapFrom(src => src.Manager != null ? src.Manager.FullName.ToString() : string.Empty))
                .ForMember(dest => dest.Employees, opt => opt.MapFrom(src => src.Employees));

            CreateMap<CreateDepartmentDto, Department>();
            CreateMap<UpdateDepartmentDto, Department>();

        }
    }
}
