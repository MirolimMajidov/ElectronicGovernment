using System.ComponentModel.DataAnnotations;

namespace ElectronicGovernment.DTO;

/// <summary>
/// This is for updating Organization info
/// </summary>
public record UpdateOrganization
{
    public string Name { get; set; }
    public string Description { get; set; }

    public Guid? LeaderId { get; set; }

    public Guid? OperatorId { get; set; }
}
