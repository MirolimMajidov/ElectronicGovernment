using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ElectronicGovernment.API.Migrations
{
    /// <inheritdoc />
    public partial class DBCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CEOId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OperatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Organizations_Users_CEOId",
                        column: x => x.CEOId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Organizations_Users_OperatorId",
                        column: x => x.OperatorId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LeaderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OperatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrganizationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departments_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Departments_Users_LeaderId",
                        column: x => x.LeaderId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Departments_Users_OperatorId",
                        column: x => x.OperatorId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DocumentTemplates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentTemplates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentTemplates_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TemplateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Documents_DocumentTemplates_TemplateId",
                        column: x => x.TemplateId,
                        principalTable: "DocumentTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Organizations",
                columns: new[] { "Id", "CEOId", "Description", "Name", "OperatorId" },
                values: new object[] { new Guid("c5bdf0ae-7048-4c5b-aca4-6decb3376569"), null, "To automate all departments of the Government", "Electronic Government", null });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("57475bdd-a271-48d7-b321-cfc7e8df7de1"), "CEO" },
                    { new Guid("6eb85f88-a22c-4fec-a3e6-782909ae8e7d"), "Operator" },
                    { new Guid("7ab8c60d-06f9-46c7-ac36-ae471b0a8fae"), "Lead" },
                    { new Guid("a352e5ce-0d34-447b-8b3b-cfe5e00b5a2d"), "Global Operator" },
                    { new Guid("a5225c4b-c1e8-4587-b50a-af2eecb311b8"), "Admin" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Discriminator", "FirstName", "LastName", "Password", "RefreshToken", "Username" },
                values: new object[,]
                {
                    { new Guid("56a949e0-0ab1-42be-9b57-683251029674"), "Employee", "Operator", "Department1", "Dep1", null, "OpeDep1" },
                    { new Guid("82b0162c-fc08-4deb-acca-1d4bcc54e8f5"), "Employee", "Global", "Operator", "Operator", null, "GlobalOperator" },
                    { new Guid("8550b9c5-7e5a-4231-912c-fcf476250c4c"), "Employee", "Leader", "Department1", "Dep1", null, "LeadDep1" },
                    { new Guid("b06e4468-5f47-48a2-8784-fb290addf90f"), "Employee", "Leader", "Department2", "Dep2", null, "OpeDep2" },
                    { new Guid("bd609e39-781a-457b-a435-3e7418d29a00"), "Employee", "Leader", "Department2", "Dep2", null, "LeadDep2" },
                    { new Guid("bee61038-a334-498b-9764-454fc897d3e2"), "Employee", "Admin", null, "Admin", null, "Admin" },
                    { new Guid("c25675bc-c4c9-4035-8b79-8afa3827a09f"), "Employee", "CEO", "Organization", "Organization", null, "CEO" }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Description", "LeaderId", "Name", "OperatorId", "OrganizationId" },
                values: new object[,]
                {
                    { new Guid("29135890-b943-4d74-bc02-57eb7bb2eb94"), null, new Guid("bd609e39-781a-457b-a435-3e7418d29a00"), "Department 2", new Guid("b06e4468-5f47-48a2-8784-fb290addf90f"), new Guid("c5bdf0ae-7048-4c5b-aca4-6decb3376569") },
                    { new Guid("6e3e79b6-bb5c-4b7d-a2ce-80e351142022"), null, new Guid("8550b9c5-7e5a-4231-912c-fcf476250c4c"), "Department 1", new Guid("56a949e0-0ab1-42be-9b57-683251029674"), new Guid("c5bdf0ae-7048-4c5b-aca4-6decb3376569") }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("01c95a6e-3521-4fb1-a142-c7a4041aade3"), new Guid("a352e5ce-0d34-447b-8b3b-cfe5e00b5a2d"), new Guid("82b0162c-fc08-4deb-acca-1d4bcc54e8f5") },
                    { new Guid("3b78c21b-c2e2-482f-a007-316be434d534"), new Guid("57475bdd-a271-48d7-b321-cfc7e8df7de1"), new Guid("c25675bc-c4c9-4035-8b79-8afa3827a09f") },
                    { new Guid("55f656c5-623d-4ecf-948a-27481898b8b8"), new Guid("a5225c4b-c1e8-4587-b50a-af2eecb311b8"), new Guid("bee61038-a334-498b-9764-454fc897d3e2") },
                    { new Guid("5b27979d-b27d-4484-8542-5a3e0208c216"), new Guid("6eb85f88-a22c-4fec-a3e6-782909ae8e7d"), new Guid("56a949e0-0ab1-42be-9b57-683251029674") },
                    { new Guid("5da1071d-0e65-46d8-908e-fd5f04740193"), new Guid("7ab8c60d-06f9-46c7-ac36-ae471b0a8fae"), new Guid("8550b9c5-7e5a-4231-912c-fcf476250c4c") },
                    { new Guid("5ee17867-ad8d-4828-b333-1246f6df7d01"), new Guid("7ab8c60d-06f9-46c7-ac36-ae471b0a8fae"), new Guid("bd609e39-781a-457b-a435-3e7418d29a00") },
                    { new Guid("678be932-6823-4ed6-8c6e-b28f2c6b90ec"), new Guid("6eb85f88-a22c-4fec-a3e6-782909ae8e7d"), new Guid("b06e4468-5f47-48a2-8784-fb290addf90f") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Departments_LeaderId",
                table: "Departments",
                column: "LeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_Name",
                table: "Departments",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_OperatorId",
                table: "Departments",
                column: "OperatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_OrganizationId",
                table: "Departments",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_TemplateId",
                table: "Documents",
                column: "TemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentTemplates_DepartmentId",
                table: "DocumentTemplates",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_CEOId",
                table: "Organizations",
                column: "CEOId");

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_OperatorId",
                table: "Organizations",
                column: "OperatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_Name",
                table: "Roles",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId_RoleId",
                table: "UserRoles",
                columns: new[] { "UserId", "RoleId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true,
                filter: "[Username] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "DocumentTemplates");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Organizations");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
