namespace ElectronicGovernment.DTO;

public record EmployeeInfo
{
    public Guid Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string FullName { get; set; }
}
