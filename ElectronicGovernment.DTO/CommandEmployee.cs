using System.ComponentModel.DataAnnotations;

namespace ElectronicGovernment.DTO;

/// <summary>
/// This is for creating or updating Department
/// </summary>
public record CommandDepartment
{
    public string Name { get; set; }
    public string Description { get; set; }

    public Guid? LeaderId { get; set; }

    public Guid? OperatorId { get; set; }
}
