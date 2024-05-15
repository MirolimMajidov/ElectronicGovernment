namespace ElectronicGovernment.API.Models;
public class DocumentTemplate : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }

    public string FileName { get; set; }

    public Guid DepartmentId { get; set; }
    public Department Department { get; set; }

    public bool Status { get; set; } = false;

    public IList<Document> Documents { get; set; }
}
