namespace ElectronicGovernment.API.Models;

public class Role : BaseEntity
{
    public string Name { get; set; }
    public ICollection<UserRole> Users { get; set; }
}
