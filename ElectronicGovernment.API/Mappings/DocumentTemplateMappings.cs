using AutoMapper;
using ElectronicGovernment.API.Models;
using ElectronicGovernment.DTO;

namespace BankManagementSystem.Mappings;

public class DocumentTemplateMappings : Profile
{
    public DocumentTemplateMappings()
    {
        CreateMap<DocumentTemplate, DocumentTemplateInfo>();
        CreateMap<CreateDocumentTemplate, DocumentTemplate>();
    }
}
