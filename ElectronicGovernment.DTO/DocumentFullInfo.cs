namespace ElectronicGovernment.DTO;

public record DocumentFullInfo : DocumentInfo
{
    public List<string> Attachments { get; set; } = [];
}
