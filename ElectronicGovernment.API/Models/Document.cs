namespace ElectronicGovernment.API.Models;
public class Document : BaseEntity
{
    public Guid TemplateId { get; set; }
    public DocumentTemplate Template { get; set; }

    public DocumentStatus Status { get; set; } =  DocumentStatus.None;
}
