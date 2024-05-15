namespace ElectronicGovernment.API.Models;

public class Employee : User
{
    public Guid OrganizationId { get; set; }
    public Organization Organization { get; set; }
}
