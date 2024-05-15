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
                values: new object[] { new Guid("7a7b234e-0d6f-4974-ba2a-90b0422a9f46"), null, "To automate all departments of the Government", "Electronic Government", null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Discriminator", "FirstName", "LastName", "Password", "RefreshToken", "Username" },
                values: new object[,]
                {
                    { new Guid("1d450a24-6fa8-4410-bd52-81dc6bcd4165"), "Employee", "CEO", "Organization", "Organization", null, "CEO" },
                    { new Guid("49517a80-cf04-483d-98b3-8bc0968aa13d"), "Employee", "Admin", null, "Admin", null, "Admin" },
                    { new Guid("5b9e0b4f-1d7f-47db-a449-73f258eb148a"), "Employee", "Leader", "Department2", "Dep2", null, "OpeDep2" },
                    { new Guid("73270360-ffaa-4506-a232-b995a03a5e0c"), "Employee", "Leader", "Department1", "Dep1", null, "LeadDep1" },
                    { new Guid("a75da4ab-b7ca-4fba-b2e2-7d3f82419340"), "Employee", "Leader", "Department2", "Dep2", null, "LeadDep2" },
                    { new Guid("d7f2c471-f05e-4c86-a5d3-d3d5a7194424"), "Employee", "Operator", "Department1", "Dep1", null, "OpeDep1" },
                    { new Guid("d87cf56e-8714-4136-8048-988fd24b75ea"), "Employee", "Global", "Operator", "Operator", null, "GlobalOperator" }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Description", "LeaderId", "Name", "OperatorId", "OrganizationId" },
                values: new object[,]
                {
                    { new Guid("4462ba3e-a60a-4fa6-ab08-46eafe00d278"), null, new Guid("a75da4ab-b7ca-4fba-b2e2-7d3f82419340"), "Department 2", new Guid("5b9e0b4f-1d7f-47db-a449-73f258eb148a"), new Guid("7a7b234e-0d6f-4974-ba2a-90b0422a9f46") },
                    { new Guid("db5e6b8e-f1f5-4a4a-9f15-61e98f7b38e8"), null, new Guid("73270360-ffaa-4506-a232-b995a03a5e0c"), "Department 1", new Guid("d7f2c471-f05e-4c86-a5d3-d3d5a7194424"), new Guid("7a7b234e-0d6f-4974-ba2a-90b0422a9f46") }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "RoleType", "UserId" },
                values: new object[,]
                {
                    { new Guid("2d7cb3d4-5ad6-45b0-bcb5-62ca4db3b8b5"), 1, new Guid("49517a80-cf04-483d-98b3-8bc0968aa13d") },
                    { new Guid("6295d455-be24-451a-9ec9-80f2c5dea4d7"), 2, new Guid("1d450a24-6fa8-4410-bd52-81dc6bcd4165") },
                    { new Guid("6a033322-cde4-4a96-b345-7efdb1c9c14f"), 4, new Guid("d87cf56e-8714-4136-8048-988fd24b75ea") },
                    { new Guid("6de80a6f-0cc9-451b-a573-98cdbfb4542a"), 5, new Guid("d7f2c471-f05e-4c86-a5d3-d3d5a7194424") },
                    { new Guid("b58e9213-a906-460a-89d3-4785af4bd64f"), 3, new Guid("a75da4ab-b7ca-4fba-b2e2-7d3f82419340") },
                    { new Guid("ce02fd05-9e31-4979-824c-5358893eb887"), 5, new Guid("5b9e0b4f-1d7f-47db-a449-73f258eb148a") },
                    { new Guid("df4533fd-2f42-4e20-a82a-26c0597ed120"), 3, new Guid("73270360-ffaa-4506-a232-b995a03a5e0c") }
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
