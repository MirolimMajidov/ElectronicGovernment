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
                values: new object[] { new Guid("2a720891-3e68-4538-bf8f-51b6b5c2067c"), null, "To automate all departments of the Government", "Electronic Government", null });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("3e6f4a44-ff47-45f4-88a6-cf573064276c"), "CEO" },
                    { new Guid("4a7d0e7a-2cda-476b-93fe-bf5f0413d054"), "Global Operator" },
                    { new Guid("7845152b-7d35-4f9b-a41a-ed8bc869d02a"), "Lead" },
                    { new Guid("81aea9e8-ca3e-43fb-b90b-5e6e1003f977"), "Operator" },
                    { new Guid("9df29616-ef70-4473-a23c-c19785704848"), "Admin" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Discriminator", "FirstName", "LastName", "Password", "RefreshToken", "Username" },
                values: new object[,]
                {
                    { new Guid("0d7a7563-5b29-40c9-8fbf-095620f547b9"), "Employee", "CEO", "Organization", "Organization", null, "CEO" },
                    { new Guid("1018f072-d70b-4e34-baf0-37bae980f977"), "Employee", "Global", "Operator", "Operator", null, "GlobalOperator" },
                    { new Guid("32761140-64e4-4c9d-b9f9-dc82a5a91131"), "Employee", "Leader", "Department1", "Dep1", null, "LeadDep1" },
                    { new Guid("53c1c562-2298-43d6-811c-dcfe0bc299f0"), "Employee", "Leader", "Department2", "Dep2", null, "LeadDep2" },
                    { new Guid("73e49a0c-2dce-4615-8397-9fd519c5f8c0"), "Employee", "Admin", null, "Admin", null, "Admin" },
                    { new Guid("a63e8ab6-e40f-46de-91bb-61bb8cccbb7c"), "Employee", "Leader", "Department2", "Dep2", null, "OpeDep2" },
                    { new Guid("ddadc393-6644-41e2-9c89-4e73dc6bd830"), "Employee", "Operator", "Department1", "Dep1", null, "OpeDep1" }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Description", "LeaderId", "Name", "OperatorId", "OrganizationId" },
                values: new object[,]
                {
                    { new Guid("2a8ad25a-fbaa-4fda-a73b-81527e9da610"), null, new Guid("32761140-64e4-4c9d-b9f9-dc82a5a91131"), "Department 1", new Guid("ddadc393-6644-41e2-9c89-4e73dc6bd830"), new Guid("2a720891-3e68-4538-bf8f-51b6b5c2067c") },
                    { new Guid("89ab32cc-4f65-4dfa-a5f7-18be9fa34608"), null, new Guid("53c1c562-2298-43d6-811c-dcfe0bc299f0"), "Department 2", new Guid("a63e8ab6-e40f-46de-91bb-61bb8cccbb7c"), new Guid("2a720891-3e68-4538-bf8f-51b6b5c2067c") }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("31c01df2-53c1-4c30-af69-73455a3d5804"), new Guid("81aea9e8-ca3e-43fb-b90b-5e6e1003f977"), new Guid("a63e8ab6-e40f-46de-91bb-61bb8cccbb7c") },
                    { new Guid("32d18cc7-3e74-4c94-a7da-e65d5247a2af"), new Guid("7845152b-7d35-4f9b-a41a-ed8bc869d02a"), new Guid("32761140-64e4-4c9d-b9f9-dc82a5a91131") },
                    { new Guid("63747848-2c32-4775-bfac-518762cb65ca"), new Guid("3e6f4a44-ff47-45f4-88a6-cf573064276c"), new Guid("0d7a7563-5b29-40c9-8fbf-095620f547b9") },
                    { new Guid("7ded988f-8ca6-4609-a504-c9b32ce180c7"), new Guid("7845152b-7d35-4f9b-a41a-ed8bc869d02a"), new Guid("53c1c562-2298-43d6-811c-dcfe0bc299f0") },
                    { new Guid("a82ee14c-3b6f-4cbe-92d1-455d8ef8a50a"), new Guid("4a7d0e7a-2cda-476b-93fe-bf5f0413d054"), new Guid("1018f072-d70b-4e34-baf0-37bae980f977") },
                    { new Guid("d4ec2f38-415d-4216-9d3d-8bcc0c269520"), new Guid("9df29616-ef70-4473-a23c-c19785704848"), new Guid("73e49a0c-2dce-4615-8397-9fd519c5f8c0") },
                    { new Guid("e2a9258a-90a9-4f21-b350-65892721523e"), new Guid("81aea9e8-ca3e-43fb-b90b-5e6e1003f977"), new Guid("ddadc393-6644-41e2-9c89-4e73dc6bd830") }
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
