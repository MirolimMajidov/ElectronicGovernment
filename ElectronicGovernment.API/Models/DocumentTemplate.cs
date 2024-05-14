namespace ElectronicGovernment.API.Models;
public class DocumentTemplate : BaseEntity
{
    public Guid DepartmentId { get; set; }
    public Department Department { get; set; }
    public IList<Document> Documents { get; set; }
}
