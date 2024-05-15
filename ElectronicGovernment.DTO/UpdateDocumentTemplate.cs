namespace ElectronicGovernment.DTO;

/// <summary>
/// This is for updating DocumentTemplate
/// </summary>
public record UpdateDocumentTemplate
{
    public string Name { get; set; }

    public string Description { get; set; }
}
