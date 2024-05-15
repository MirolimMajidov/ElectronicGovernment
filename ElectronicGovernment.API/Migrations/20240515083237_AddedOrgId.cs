using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ElectronicGovernment.API.Migrations
{
    /// <inheritdoc />
    public partial class AddedOrgId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<Guid>(
                name: "OrganizationId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Discriminator", "FirstName", "LastName", "OrganizationId", "Password", "RefreshToken", "Username" },
                values: new object[,]
                {
                    { new Guid("00bac9d3-b015-4fb1-a856-ac970375062f"), "Employee", "Leader", "Department2", new Guid("2a720891-3e68-4538-bf8f-51b6b5c2067c"), "Dep2", null, "OpeDep2" },
                    { new Guid("18137aa1-2a2a-4dc9-8a43-5f7bbded1584"), "Employee", "Operator", "Department1", new Guid("2a720891-3e68-4538-bf8f-51b6b5c2067c"), "Dep1", null, "OpeDep1" },
                    { new Guid("1e02d3aa-6c12-452a-b0c4-3a439e3ebba6"), "Employee", "CEO", "Organization", new Guid("2a720891-3e68-4538-bf8f-51b6b5c2067c"), "Organization", null, "CEO" },
                    { new Guid("3e8a031b-1b0b-4be8-8251-b935dc800a33"), "Employee", "Admin", null, new Guid("2a720891-3e68-4538-bf8f-51b6b5c2067c"), "Admin", null, "Admin" },
                    { new Guid("baa8114f-498e-4678-9163-ad1eb903c3ed"), "Employee", "Leader", "Department2", new Guid("2a720891-3e68-4538-bf8f-51b6b5c2067c"), "Dep2", null, "LeadDep2" },
                    { new Guid("c0cacb6a-ce34-492b-aa44-388fc4107285"), "Employee", "Global", "Operator", new Guid("2a720891-3e68-4538-bf8f-51b6b5c2067c"), "Operator", null, "GlobalOperator" },
                    { new Guid("d1888053-30e5-440c-97cc-274295276422"), "Employee", "Leader", "Department1", new Guid("2a720891-3e68-4538-bf8f-51b6b5c2067c"), "Dep1", null, "LeadDep1" }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Description", "IsOnlyForWorkFlow", "LeaderId", "Name", "OperatorId", "OrganizationId" },
                values: new object[,]
                {
                    { new Guid("3de05800-1edc-453b-a58d-043cd4305296"), null, false, new Guid("d1888053-30e5-440c-97cc-274295276422"), "Department 1", new Guid("18137aa1-2a2a-4dc9-8a43-5f7bbded1584"), new Guid("2a720891-3e68-4538-bf8f-51b6b5c2067c") },
                    { new Guid("b17b7d15-a161-462d-b5c9-f482121d7403"), null, false, new Guid("baa8114f-498e-4678-9163-ad1eb903c3ed"), "Department 2", new Guid("00bac9d3-b015-4fb1-a856-ac970375062f"), new Guid("2a720891-3e68-4538-bf8f-51b6b5c2067c") }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "RoleType", "UserId" },
                values: new object[,]
                {
                    { new Guid("078242d0-d283-49d5-8c6e-7eaf778c8e66"), 3, new Guid("1e02d3aa-6c12-452a-b0c4-3a439e3ebba6") },
                    { new Guid("5cc016cc-f615-4be9-a609-b1dd35723bb7"), 5, new Guid("00bac9d3-b015-4fb1-a856-ac970375062f") },
                    { new Guid("9b38b704-343e-457e-8d0a-bea98f23c4c5"), 2, new Guid("1e02d3aa-6c12-452a-b0c4-3a439e3ebba6") },
                    { new Guid("a15cc6d4-126d-4298-8d0c-3e5077afe8bb"), 4, new Guid("c0cacb6a-ce34-492b-aa44-388fc4107285") },
                    { new Guid("ca4ad2d8-11d1-40c1-8ebc-e6918d26d53b"), 5, new Guid("18137aa1-2a2a-4dc9-8a43-5f7bbded1584") },
                    { new Guid("e067bbfa-fd54-499d-9986-852848836183"), 3, new Guid("d1888053-30e5-440c-97cc-274295276422") },
                    { new Guid("f4b38b2c-44c9-494c-9f08-89b5f6f8c6cf"), 1, new Guid("3e8a031b-1b0b-4be8-8251-b935dc800a33") },
                    { new Guid("f9aa69ac-d79e-4c60-bb6e-4ea9b8621d88"), 3, new Guid("baa8114f-498e-4678-9163-ad1eb903c3ed") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_OrganizationId",
                table: "Users",
                column: "OrganizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Organizations_OrganizationId",
                table: "Users",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Organizations_OrganizationId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_OrganizationId",
                table: "Users");

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("3de05800-1edc-453b-a58d-043cd4305296"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("b17b7d15-a161-462d-b5c9-f482121d7403"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: new Guid("078242d0-d283-49d5-8c6e-7eaf778c8e66"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: new Guid("5cc016cc-f615-4be9-a609-b1dd35723bb7"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: new Guid("9b38b704-343e-457e-8d0a-bea98f23c4c5"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: new Guid("a15cc6d4-126d-4298-8d0c-3e5077afe8bb"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: new Guid("ca4ad2d8-11d1-40c1-8ebc-e6918d26d53b"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: new Guid("e067bbfa-fd54-499d-9986-852848836183"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: new Guid("f4b38b2c-44c9-494c-9f08-89b5f6f8c6cf"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: new Guid("f9aa69ac-d79e-4c60-bb6e-4ea9b8621d88"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00bac9d3-b015-4fb1-a856-ac970375062f"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("18137aa1-2a2a-4dc9-8a43-5f7bbded1584"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1e02d3aa-6c12-452a-b0c4-3a439e3ebba6"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3e8a031b-1b0b-4be8-8251-b935dc800a33"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("baa8114f-498e-4678-9163-ad1eb903c3ed"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c0cacb6a-ce34-492b-aa44-388fc4107285"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d1888053-30e5-440c-97cc-274295276422"));

            migrationBuilder.DropColumn(
                name: "OrganizationId",
                table: "Users");

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
    }
}
