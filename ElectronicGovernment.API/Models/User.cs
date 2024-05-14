namespace ElectronicGovernment.API.Models;

public abstract class User : BaseEntity
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string FullName => $"{FirstName} {LastName}";

    public List<UserRole> Roles { get; set; }

    public string Username { get; set; }

    public string Password { get; set; }

    public string RefreshToken { get; set; }
}
