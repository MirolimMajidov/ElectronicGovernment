using AutoMapper;
using ElectronicGovernment.API.Models;
using ElectronicGovernment.DTO;

namespace BankManagementSystem.Mappings;

public class DepartmentMappings : Profile
{
    public DepartmentMappings()
    {
        CreateMap<Department, DepartmentInfo>();
        CreateMap<CommandDepartment, Department>();
    }
}
