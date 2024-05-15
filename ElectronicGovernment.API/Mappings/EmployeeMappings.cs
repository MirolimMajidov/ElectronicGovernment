using AutoMapper;
using ElectronicGovernment.API.Models;
using ElectronicGovernment.DTO;

namespace BankManagementSystem.Mappings;

public class EmployeeMappings : Profile
{
    public EmployeeMappings()
    {
        CreateMap<Employee, EmployeeInfo>();
        CreateMap<CommandEmployee, Employee>();
    }
}
