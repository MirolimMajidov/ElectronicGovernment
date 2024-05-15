namespace ElectronicGovernment.DTO;

/// <summary>
/// This is for creating Document
/// </summary>
public record CreateDocument : UpdateDocument
{
    public Guid TemplateId { get; set; }
}
