using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ElectronicGovernment.API.Migrations
{
    /// <inheritdoc />
    public partial class AddedSomeChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("17c8b94d-c6f4-4181-a78d-35e117a991f2"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("74d6fd9c-c498-4f2e-86c8-2413f0789327"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: new Guid("25968679-23a9-402a-ab2f-bd9c0bfbb98f"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: new Guid("4c25711b-a067-4110-91df-f1ec027f7fdb"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: new Guid("5a84228f-567b-4d58-8dd8-5e184b63483e"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: new Guid("899429e2-31a7-440f-97e0-4df180740253"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: new Guid("8e7508c5-65f2-459a-bee2-ba11727e8ca1"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: new Guid("ab4c7999-aa2e-4233-80e8-9f287484973c"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: new Guid("e2209066-ab56-4338-af7f-d1bc4cb2d690"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1fe1a7c6-57af-40e5-8cdb-77f40b0a02ec"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("25252f57-6208-410b-9709-e3f467bf4de7"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("30943e5d-1f9a-47dc-aa7f-a279847d5fde"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("80638a8a-6dab-480f-b062-bc3fefa56116"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("99fec809-ff99-4a9d-a8dc-25d9d2816686"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("af54e8dc-850a-448f-9755-730329bd9655"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e72ee12d-c187-42e8-867c-f6fa93d20dfa"));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "DocumentTemplates",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "DocumentTemplates",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "DocumentTemplates",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "DocumentTemplates",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsOnlyForWorkFlow",
                table: "Departments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Discriminator", "FirstName", "LastName", "Password", "RefreshToken", "Username" },
                values: new object[,]
                {
                    { new Guid("1e24802c-609d-42ca-bf98-9a3e37caa059"), "Employee", "Leader", "Department1", "Dep1", null, "LeadDep1" },
                    { new Guid("2bf591c5-1400-487f-8c16-02c5322f5273"), "Employee", "Leader", "Department2", "Dep2", null, "LeadDep2" },
                    { new Guid("41d5e1e0-9d77-4e77-bac1-b21077e7e12d"), "Employee", "Operator", "Department1", "Dep1", null, "OpeDep1" },
                    { new Guid("4599cc1d-0959-4671-9baf-30148dc043ee"), "Employee", "Leader", "Department2", "Dep2", null, "OpeDep2" },
                    { new Guid("4645e0fd-098a-4a80-883d-db674cf124ae"), "Employee", "Admin", null, "Admin", null, "Admin" },
                    { new Guid("670c96c2-9002-4d51-91ca-a8d27f35b570"), "Employee", "CEO", "Organization", "Organization", null, "CEO" },
                    { new Guid("921786c3-f775-4c21-b3ec-32ab0b27a431"), "Employee", "Global", "Operator", "Operator", null, "GlobalOperator" }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Description", "IsOnlyForWorkFlow", "LeaderId", "Name", "OperatorId", "OrganizationId" },
                values: new object[,]
                {
                    { new Guid("bb54f087-f38e-4e09-8874-3211f8f6b1c0"), null, false, new Guid("1e24802c-609d-42ca-bf98-9a3e37caa059"), "Department 1", new Guid("41d5e1e0-9d77-4e77-bac1-b21077e7e12d"), new Guid("2a720891-3e68-4538-bf8f-51b6b5c2067c") },
                    { new Guid("f3b2b4db-7993-4e5b-9434-7155d49944d0"), null, false, new Guid("2bf591c5-1400-487f-8c16-02c5322f5273"), "Department 2", new Guid("4599cc1d-0959-4671-9baf-30148dc043ee"), new Guid("2a720891-3e68-4538-bf8f-51b6b5c2067c") }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "RoleType", "UserId" },
                values: new object[,]
                {
                    { new Guid("04d2db05-ae72-487a-b95f-eadd4314df65"), 3, new Guid("2bf591c5-1400-487f-8c16-02c5322f5273") },
                    { new Guid("1a2438cb-0582-40c3-9a74-aa5f83a59d27"), 2, new Guid("670c96c2-9002-4d51-91ca-a8d27f35b570") },
                    { new Guid("5c1fdd95-6efa-449b-a8aa-95cd62cce8f2"), 5, new Guid("4599cc1d-0959-4671-9baf-30148dc043ee") },
                    { new Guid("702bee69-5047-4ff5-ab23-75c19aaf7ec4"), 4, new Guid("921786c3-f775-4c21-b3ec-32ab0b27a431") },
                    { new Guid("833fe662-5879-4e30-a13b-8ae5e7a8736b"), 1, new Guid("4645e0fd-098a-4a80-883d-db674cf124ae") },
                    { new Guid("a0fb7891-8c08-4826-adfb-1f9f98218b65"), 3, new Guid("670c96c2-9002-4d51-91ca-a8d27f35b570") },
                    { new Guid("a9e85a0b-6092-4a68-8f5d-22872f978eb0"), 5, new Guid("41d5e1e0-9d77-4e77-bac1-b21077e7e12d") },
                    { new Guid("ccec8b25-cdea-4e0f-8acb-d51661071eae"), 3, new Guid("1e24802c-609d-42ca-bf98-9a3e37caa059") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("bb54f087-f38e-4e09-8874-3211f8f6b1c0"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("f3b2b4db-7993-4e5b-9434-7155d49944d0"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: new Guid("04d2db05-ae72-487a-b95f-eadd4314df65"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: new Guid("1a2438cb-0582-40c3-9a74-aa5f83a59d27"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: new Guid("5c1fdd95-6efa-449b-a8aa-95cd62cce8f2"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: new Guid("702bee69-5047-4ff5-ab23-75c19aaf7ec4"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: new Guid("833fe662-5879-4e30-a13b-8ae5e7a8736b"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: new Guid("a0fb7891-8c08-4826-adfb-1f9f98218b65"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: new Guid("a9e85a0b-6092-4a68-8f5d-22872f978eb0"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: new Guid("ccec8b25-cdea-4e0f-8acb-d51661071eae"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1e24802c-609d-42ca-bf98-9a3e37caa059"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2bf591c5-1400-487f-8c16-02c5322f5273"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("41d5e1e0-9d77-4e77-bac1-b21077e7e12d"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("4599cc1d-0959-4671-9baf-30148dc043ee"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("4645e0fd-098a-4a80-883d-db674cf124ae"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("670c96c2-9002-4d51-91ca-a8d27f35b570"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("921786c3-f775-4c21-b3ec-32ab0b27a431"));

            migrationBuilder.DropColumn(
                name: "Description",
                table: "DocumentTemplates");

            migrationBuilder.DropColumn(
                name: "FileName",
                table: "DocumentTemplates");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "DocumentTemplates");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "DocumentTemplates");

            migrationBuilder.DropColumn(
                name: "IsOnlyForWorkFlow",
                table: "Departments");

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
        }
    }
}
