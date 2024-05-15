namespace ElectronicGovernment.API.Models
{
    public class Organization : BaseEntity
    {
        public Organization() : base()
        {
        }

        public Organization(Guid id) : base()
        {
            if (id != Guid.Empty)
                Id = id;
        }

        public string Name { get; set; }
        public string Description { get; set; }

        public Guid? CEOId { get; set; }
        public Employee CEO { get; set; } = null;

        public Guid? OperatorId { get; set; }
        public Employee Operator { get; set; } = null;

        public ICollection<Department> Departments { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
