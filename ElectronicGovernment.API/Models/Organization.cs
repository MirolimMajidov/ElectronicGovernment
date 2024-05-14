namespace ElectronicGovernment.API.Models
{
    public class Organization : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public Guid? CEOId { get; set; }
        public Employee CEO { get; set; } = null;

        public Guid? OperatorId { get; set; }
        public Employee Operator { get; set; } = null;

        public ICollection<Department> Departments { get; set; }
    }
}
