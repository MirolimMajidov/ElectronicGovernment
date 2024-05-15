using AutoMapper;
using ElectronicGovernment.API.Models;
using ElectronicGovernment.DTO;

namespace BankManagementSystem.Mappings;

public class OrganizationMappings : Profile
{
    public OrganizationMappings()
    {
        CreateMap<Organization, OrganizationInfo>();
        CreateMap<UpdateOrganization, Organization>();
    }
}
