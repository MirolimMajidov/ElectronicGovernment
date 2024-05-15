namespace ElectronicGovernment.DTO;

public class OrganizationInfo
{
    public string Name { get; set; }
    public string Description { get; set; }
    public Guid? CEOId { get; set; }
    public Guid? OperatorId { get; set; }
}
