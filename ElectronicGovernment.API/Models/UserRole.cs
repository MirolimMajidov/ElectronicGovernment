using ElectronicGovernment.DTO;

namespace ElectronicGovernment.API.Models;

public class UserRole : BaseEntity
{
    public Guid UserId { get; set; }
    public User User { get; set; }

    public RoleType RoleType { get; set; } = RoleType.Employee;
}
