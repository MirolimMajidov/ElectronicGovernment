using System.ComponentModel.DataAnnotations;

namespace ElectronicGovernment.DTO;

/// <summary>
/// This is for creating or updating Employee
/// </summary>
public class CommandEmployee
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Username { get; set; }

    public string Password { get; set; }
}
