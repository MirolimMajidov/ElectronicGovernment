using ElectronicGovernment.API.Infrastructure;
using ElectronicGovernment.API.Models;
using Microsoft.EntityFrameworkCore;

namespace BankManagementSystem.Infrastructure
{
    public class EGContext : DbContext, IEGContext
    {
        public EGContext(DbContextOptions options) : base(options)
        { }

        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Citizen> Citizens { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<DocumentTemplate> DocumentTemplates { get; set; }
        public DbSet<Document> Documents { get; set; }

        public IQueryable<T> GetEntities<T>() where T : BaseEntity
        {
            return Set<T>();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<BaseEntity>();

            var organization = new Organization()
            {
                Name = "Electronic Government",
                Description = "To automate all departments of the Government"
            };

            modelBuilder.Entity<Organization>(entity =>
            {
                entity.HasKey(p => p.Id);

                entity.HasData(organization);
                entity.HasMany(p => p.Departments).WithOne(e => e.Organization).HasForeignKey(e => e.OrganizationId).IsRequired();
                entity.HasOne(p => p.CEO).WithMany().HasForeignKey(e => e.CEOId).IsRequired(false);
                entity.HasOne(p => p.Operator).WithMany().HasForeignKey(e => e.OperatorId).IsRequired(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.HasIndex(p => p.Username).IsUnique();
                entity.HasMany(p => p.Roles).WithOne(e => e.User).HasForeignKey(e => e.UserId).IsRequired();
            });

            var admin = new Employee()
            {
                FirstName = "Admin",
                Username = "Admin",
                Password = "Admin"
            };
            var ceoOrg = new Employee()
            {
                FirstName = "CEO",
                LastName = "Organization",
                Username = "CEO",
                Password = "Organization"
            };
            var operatorOrg = new Employee()
            {
                FirstName = "Global",
                LastName = "Operator",
                Username = "GlobalOperator",
                Password = "Operator"
            };

            var leadDep1 = new Employee()
            {
                FirstName = "Leader",
                LastName = "Department1",
                Username = "LeadDep1",
                Password = "Dep1"
            };
            var leadDep2 = new Employee()
            {
                FirstName = "Leader",
                LastName = "Department2",
                Username = "LeadDep2",
                Password = "Dep2"
            };
            var operatorDep1 = new Employee()
            {
                FirstName = "Operator",
                LastName = "Department1",
                Username = "OpeDep1",
                Password = "Dep1"
            };
            var operatorDep2 = new Employee()
            {
                FirstName = "Leader",
                LastName = "Department2",
                Username = "OpeDep2",
                Password = "Dep2"
            };
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasData(admin, ceoOrg, operatorOrg, leadDep1, leadDep2, operatorDep1, operatorDep2);
            });
            modelBuilder.Entity<Citizen>(entity =>
            {
            });

            var department1 = new Department();
            department1.Name = "Department 1";
            department1.LeaderId = leadDep1.Id;
            department1.OperatorId = operatorDep1.Id;
            department1.OrganizationId = organization.Id;

            var department2 = new Department();
            department2.Name = "Department 2";
            department2.LeaderId = leadDep2.Id;
            department2.OperatorId = operatorDep2.Id;
            department2.OrganizationId = organization.Id;

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.HasIndex(p => p.Name).IsUnique();
                entity.HasData(department1, department2);
                entity.HasOne(p => p.Leader).WithMany().HasForeignKey(e => e.LeaderId).IsRequired(false);
                entity.HasOne(p => p.Operator).WithMany().HasForeignKey(e => e.OperatorId).IsRequired(false);
            });

            var adminRole = new Role()
            {
                Name = "Admin",
            };
            var ceoRole = new Role()
            {
                Name = "CEO",
            };
            var leadRole = new Role()
            {
                Name = "Lead",
            };
            var globalOperatorRole = new Role()
            {
                Name = "Global Operator",
            };
            var operatorRole = new Role()
            {
                Name = "Operator",
            };
            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.HasIndex(p => p.Name).IsUnique();
                entity.HasData(adminRole, ceoRole, leadRole, globalOperatorRole, operatorRole);
                entity.HasMany(p => p.Users).WithOne(e => e.Role).HasForeignKey(e => e.RoleId).IsRequired();
            });

            var roles = new List<UserRole>()
            {
                new UserRole() {UserId = admin.Id, RoleId = adminRole.Id},
                new UserRole() {UserId = ceoOrg.Id, RoleId = ceoRole.Id},
                new UserRole() {UserId = operatorOrg.Id, RoleId = globalOperatorRole.Id},
                new UserRole() {UserId = leadDep1.Id, RoleId = leadRole.Id},
                new UserRole() {UserId = leadDep2.Id, RoleId = leadRole.Id},
                new UserRole() {UserId = operatorDep1.Id, RoleId = operatorRole.Id},
                new UserRole() {UserId = operatorDep2.Id, RoleId = operatorRole.Id},
            };
            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasKey(p => p.Id);

                entity.HasIndex(p => new { p.UserId, p.RoleId }).IsUnique();
                entity.HasData(roles);
            });

            modelBuilder.Entity<DocumentTemplate>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.HasMany(p => p.Documents).WithOne(e => e.Template).HasForeignKey(e => e.TemplateId).IsRequired();
            });

            modelBuilder.Entity<Document>(entity =>
            {
                entity.HasKey(p => p.Id);
            });
        }
    }
}
