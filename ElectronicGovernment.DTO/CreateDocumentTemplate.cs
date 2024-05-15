namespace ElectronicGovernment.DTO;

/// <summary>
/// This is for creating or updating DocumentTemplate
/// </summary>
public record CreateDocumentTemplate : UpdateDocumentTemplate
{
    public Guid DepartmentId { get; set; }
}
