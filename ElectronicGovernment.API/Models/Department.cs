namespace ElectronicGovernment.API.Models;

public class Department : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }

    public Guid? LeaderId { get; set; }
    public Employee Leader { get; set; }

    public Guid? OperatorId { get; set; }
    public Employee Operator { get; set; }
    public Guid OrganizationId { get; set; }
    public Organization Organization { get; set; }
    public ICollection<DocumentTemplate> DocumentTemplates { get; set; }
}
