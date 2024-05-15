using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ElectronicGovernment.API.Migrations
{
    /// <inheritdoc />
    public partial class AddedAttachmentsToDocument : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<string>(
                name: "Attachments",
                table: "Documents",
                type: "varchar(max)",
                unicode: false,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AttachmentsJson",
                table: "Documents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sender",
                table: "Documents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Discriminator", "FirstName", "LastName", "OrganizationId", "Password", "RefreshToken", "Username" },
                values: new object[,]
                {
                    { new Guid("15963c23-d361-4cfe-9e50-4305c5bfd055"), "Employee", "Leader", "Department1", new Guid("2a720891-3e68-4538-bf8f-51b6b5c2067c"), "Dep1", null, "LeadDep1" },
                    { new Guid("4ea8002a-18fb-4c5b-a9f6-dfe9f5ed9e66"), "Employee", "Leader", "Department2", new Guid("2a720891-3e68-4538-bf8f-51b6b5c2067c"), "Dep2", null, "OpeDep2" },
                    { new Guid("5a6a9e54-8599-4ecc-a968-6d82568b91bf"), "Employee", "Operator", "Department1", new Guid("2a720891-3e68-4538-bf8f-51b6b5c2067c"), "Dep1", null, "OpeDep1" },
                    { new Guid("5d79c398-a9ff-4ee5-a14e-4606440f6cf8"), "Employee", "Admin", null, new Guid("2a720891-3e68-4538-bf8f-51b6b5c2067c"), "Admin", null, "Admin" },
                    { new Guid("75093a84-1d44-4077-abf2-aa2051147b9a"), "Employee", "Leader", "Department2", new Guid("2a720891-3e68-4538-bf8f-51b6b5c2067c"), "Dep2", null, "LeadDep2" },
                    { new Guid("77ae3e74-18f1-4727-8422-a56ee9fba9c3"), "Employee", "CEO", "Organization", new Guid("2a720891-3e68-4538-bf8f-51b6b5c2067c"), "Organization", null, "CEO" },
                    { new Guid("aa913809-d93e-4226-bec8-837ad3e8c6fb"), "Employee", "Global", "Operator", new Guid("2a720891-3e68-4538-bf8f-51b6b5c2067c"), "Operator", null, "GlobalOperator" }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Description", "IsOnlyForWorkFlow", "LeaderId", "Name", "OperatorId", "OrganizationId" },
                values: new object[,]
                {
                    { new Guid("2923bdf8-f599-4779-9c7c-4f08a1769200"), null, false, new Guid("15963c23-d361-4cfe-9e50-4305c5bfd055"), "Department 1", new Guid("5a6a9e54-8599-4ecc-a968-6d82568b91bf"), new Guid("2a720891-3e68-4538-bf8f-51b6b5c2067c") },
                    { new Guid("401f69d9-d0f3-450f-bba6-c1158d459c21"), null, false, new Guid("75093a84-1d44-4077-abf2-aa2051147b9a"), "Department 2", new Guid("4ea8002a-18fb-4c5b-a9f6-dfe9f5ed9e66"), new Guid("2a720891-3e68-4538-bf8f-51b6b5c2067c") }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "RoleType", "UserId" },
                values: new object[,]
                {
                    { new Guid("2b13244c-6866-4e97-9de7-789bc58738cc"), 4, new Guid("aa913809-d93e-4226-bec8-837ad3e8c6fb") },
                    { new Guid("2dbc42b1-6150-4b0b-81b4-cfba9fec2e56"), 5, new Guid("5a6a9e54-8599-4ecc-a968-6d82568b91bf") },
                    { new Guid("38192567-b0f2-452b-a9ee-9d4589851c3d"), 3, new Guid("77ae3e74-18f1-4727-8422-a56ee9fba9c3") },
                    { new Guid("c03c5102-9a1a-4213-acf4-063548834d5b"), 2, new Guid("77ae3e74-18f1-4727-8422-a56ee9fba9c3") },
                    { new Guid("d3eb7fa9-dfd2-4f5b-82bf-daffb43e6318"), 3, new Guid("75093a84-1d44-4077-abf2-aa2051147b9a") },
                    { new Guid("d7a6ec1f-2be3-4034-9d58-5e9155b3b6d5"), 3, new Guid("15963c23-d361-4cfe-9e50-4305c5bfd055") },
                    { new Guid("d87df871-0ca6-4c1e-b77b-7b845a74b7e4"), 1, new Guid("5d79c398-a9ff-4ee5-a14e-4606440f6cf8") },
                    { new Guid("f296cfa5-abe0-4568-88b3-8be2cf4d647b"), 5, new Guid("4ea8002a-18fb-4c5b-a9f6-dfe9f5ed9e66") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("2923bdf8-f599-4779-9c7c-4f08a1769200"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("401f69d9-d0f3-450f-bba6-c1158d459c21"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: new Guid("2b13244c-6866-4e97-9de7-789bc58738cc"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: new Guid("2dbc42b1-6150-4b0b-81b4-cfba9fec2e56"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: new Guid("38192567-b0f2-452b-a9ee-9d4589851c3d"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: new Guid("c03c5102-9a1a-4213-acf4-063548834d5b"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: new Guid("d3eb7fa9-dfd2-4f5b-82bf-daffb43e6318"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: new Guid("d7a6ec1f-2be3-4034-9d58-5e9155b3b6d5"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: new Guid("d87df871-0ca6-4c1e-b77b-7b845a74b7e4"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: new Guid("f296cfa5-abe0-4568-88b3-8be2cf4d647b"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("15963c23-d361-4cfe-9e50-4305c5bfd055"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("4ea8002a-18fb-4c5b-a9f6-dfe9f5ed9e66"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5a6a9e54-8599-4ecc-a968-6d82568b91bf"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5d79c398-a9ff-4ee5-a14e-4606440f6cf8"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("75093a84-1d44-4077-abf2-aa2051147b9a"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("77ae3e74-18f1-4727-8422-a56ee9fba9c3"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("aa913809-d93e-4226-bec8-837ad3e8c6fb"));

            migrationBuilder.DropColumn(
                name: "Attachments",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "AttachmentsJson",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "Sender",
                table: "Documents");

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
        }
    }
}
