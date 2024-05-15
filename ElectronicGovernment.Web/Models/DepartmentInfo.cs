namespace ElectronicGovernment.DTO;

public record DepartmentInfo
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}
