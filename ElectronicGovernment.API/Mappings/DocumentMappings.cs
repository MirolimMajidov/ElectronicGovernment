using AutoMapper;
using ElectronicGovernment.API.Models;
using ElectronicGovernment.DTO;

namespace BankManagementSystem.Mappings;

public class DocumentMappings : Profile
{
    public DocumentMappings()
    {
        CreateMap<Document, DocumentInfo>();
        CreateMap<CreateDocument, Document>();
    }
}
