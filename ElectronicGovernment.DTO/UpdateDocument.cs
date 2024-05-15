namespace ElectronicGovernment.DTO;

/// <summary>
/// This is for updating UpdateDocument
/// </summary>
public record UpdateDocument
{
    public string Sender { get; set; }

    public string PhoneNumber { get; set; }
}
