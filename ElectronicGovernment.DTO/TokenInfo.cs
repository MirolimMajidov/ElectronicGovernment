namespace ElectronicGovernment.DTO;

public record TokenInfo
{
    public string AccessToken { get; set; }

    public string RefreshToken { get; set; }
}
