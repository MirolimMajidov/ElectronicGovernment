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
                    RoleType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
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
                    LeaderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OperatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                values: new object[] { new Guid("2a720891-3e68-4538-bf8f-51b6b5c2067c"), null, "To automate all departments of the Government", "Electronic Government", null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Discriminator", "FirstName", "LastName", "Password", "RefreshToken", "Username" },
                values: new object[,]
                {
                    { new Guid("1fe1a7c6-57af-40e5-8cdb-77f40b0a02ec"), "Employee", "Leader", "Department2", "Dep2", null, "OpeDep2" },
                    { new Guid("25252f57-6208-410b-9709-e3f467bf4de7"), "Employee", "Global", "Operator", "Operator", null, "GlobalOperator" },
                    { new Guid("30943e5d-1f9a-47dc-aa7f-a279847d5fde"), "Employee", "Operator", "Department1", "Dep1", null, "OpeDep1" },
                    { new Guid("80638a8a-6dab-480f-b062-bc3fefa56116"), "Employee", "CEO", "Organization", "Organization", null, "CEO" },
                    { new Guid("99fec809-ff99-4a9d-a8dc-25d9d2816686"), "Employee", "Leader", "Department1", "Dep1", null, "LeadDep1" },
                    { new Guid("af54e8dc-850a-448f-9755-730329bd9655"), "Employee", "Leader", "Department2", "Dep2", null, "LeadDep2" },
                    { new Guid("e72ee12d-c187-42e8-867c-f6fa93d20dfa"), "Employee", "Admin", null, "Admin", null, "Admin" }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Description", "LeaderId", "Name", "OperatorId", "OrganizationId" },
                values: new object[,]
                {
                    { new Guid("17c8b94d-c6f4-4181-a78d-35e117a991f2"), null, new Guid("99fec809-ff99-4a9d-a8dc-25d9d2816686"), "Department 1", new Guid("30943e5d-1f9a-47dc-aa7f-a279847d5fde"), new Guid("2a720891-3e68-4538-bf8f-51b6b5c2067c") },
                    { new Guid("74d6fd9c-c498-4f2e-86c8-2413f0789327"), null, new Guid("af54e8dc-850a-448f-9755-730329bd9655"), "Department 2", new Guid("1fe1a7c6-57af-40e5-8cdb-77f40b0a02ec"), new Guid("2a720891-3e68-4538-bf8f-51b6b5c2067c") }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "RoleType", "UserId" },
                values: new object[,]
                {
                    { new Guid("25968679-23a9-402a-ab2f-bd9c0bfbb98f"), 1, new Guid("e72ee12d-c187-42e8-867c-f6fa93d20dfa") },
                    { new Guid("4c25711b-a067-4110-91df-f1ec027f7fdb"), 2, new Guid("80638a8a-6dab-480f-b062-bc3fefa56116") },
                    { new Guid("5a84228f-567b-4d58-8dd8-5e184b63483e"), 3, new Guid("af54e8dc-850a-448f-9755-730329bd9655") },
                    { new Guid("899429e2-31a7-440f-97e0-4df180740253"), 4, new Guid("25252f57-6208-410b-9709-e3f467bf4de7") },
                    { new Guid("8e7508c5-65f2-459a-bee2-ba11727e8ca1"), 5, new Guid("30943e5d-1f9a-47dc-aa7f-a279847d5fde") },
                    { new Guid("ab4c7999-aa2e-4233-80e8-9f287484973c"), 3, new Guid("99fec809-ff99-4a9d-a8dc-25d9d2816686") },
                    { new Guid("e2209066-ab56-4338-af7f-d1bc4cb2d690"), 5, new Guid("1fe1a7c6-57af-40e5-8cdb-77f40b0a02ec") }
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
                name: "IX_UserRoles_UserId_RoleType",
                table: "UserRoles",
                columns: new[] { "UserId", "RoleType" },
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
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Organizations");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
