namespace ElectronicGovernment.DTO;

public record DocumentInfo
{
    public Guid Id { get; set; }

    public string TemplateName { get; set; }

    public string Sender { get; set; }

    public string PhoneNumber { get; set; }

    public DocumentStatus Status { get; set; } = DocumentStatus.NotStarted;

    public string Process { get; set; }

    public Guid DepartmentId { get; set; }
}
