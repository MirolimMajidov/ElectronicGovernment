using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ElectronicGovernment.API.Migrations
{
    /// <inheritdoc />
    public partial class AddedProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("27939632-d223-49ec-a9a5-86ccf04c9c54"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("a4a194cd-0c34-4d17-8403-4dc4195c3862"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: new Guid("26776e98-5fea-4acd-ad08-b4f90d5b6bb2"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: new Guid("2e7b5400-e775-47ff-a962-87cf89e6eb04"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: new Guid("638c17e4-3ae6-4927-af46-0b55a5f03778"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: new Guid("8ec4c680-9d8f-4648-8ac9-6306ddd8ad28"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: new Guid("a88b3a43-77fb-4181-aff8-986c65e2f7ea"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: new Guid("c0722c38-3fb8-468d-a669-385274746b53"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: new Guid("d376eea4-3e06-4213-a1ee-38838e772b9c"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: new Guid("e009c4fa-1c16-45dc-9eb0-187c71e93efc"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("24e6879f-8110-4624-af8c-325e4e100271"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("34488a0b-c00f-4974-8b43-37e805c6f714"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3cc698a7-91f1-4573-9de9-aef3c8da9c7d"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("92b7165e-c3b1-49f3-8ed2-bf79515fbbe2"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c3a21171-47b2-425d-a47b-a231345d6b4b"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c871c293-79e7-4cbb-a365-d194578475c3"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e641cee4-58ee-42b0-b155-f090b1130d13"));

            migrationBuilder.RenameColumn(
                name: "SenderPhoneNumber",
                table: "Documents",
                newName: "PhoneNumber");

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "Documents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Discriminator", "FirstName", "LastName", "OrganizationId", "Password", "RefreshToken", "Username" },
                values: new object[,]
                {
                    { new Guid("0d0c461a-6364-4fd6-ad98-97a8135f4d88"), "Employee", "Admin", null, new Guid("2a720891-3e68-4538-bf8f-51b6b5c2067c"), "Admin", null, "Admin" },
                    { new Guid("1cb7f75b-1cd7-481f-99cf-0a17b5ba7b44"), "Employee", "Operator", "Department1", new Guid("2a720891-3e68-4538-bf8f-51b6b5c2067c"), "Dep1", null, "OpeDep1" },
                    { new Guid("27e1062d-397c-4030-8de3-b3f4d6464c4f"), "Employee", "Global", "Operator", new Guid("2a720891-3e68-4538-bf8f-51b6b5c2067c"), "Operator", null, "GlobalOperator" },
                    { new Guid("446e2d90-95c8-4767-93a8-a0621de33437"), "Employee", "Leader", "Department2", new Guid("2a720891-3e68-4538-bf8f-51b6b5c2067c"), "Dep2", null, "LeadDep2" },
                    { new Guid("842bcc55-d686-43c5-a7c6-6371e6a8bdbe"), "Employee", "Leader", "Department1", new Guid("2a720891-3e68-4538-bf8f-51b6b5c2067c"), "Dep1", null, "LeadDep1" },
                    { new Guid("94bdfabe-e24f-4930-8d19-4c2c2c1cdfbb"), "Employee", "Leader", "Department2", new Guid("2a720891-3e68-4538-bf8f-51b6b5c2067c"), "Dep2", null, "OpeDep2" },
                    { new Guid("d0609810-1a2b-4630-8f53-282f690de8d5"), "Employee", "CEO", "Organization", new Guid("2a720891-3e68-4538-bf8f-51b6b5c2067c"), "Organization", null, "CEO" }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Description", "IsOnlyForWorkFlow", "LeaderId", "Name", "OperatorId", "OrganizationId" },
                values: new object[,]
                {
                    { new Guid("47d1d38f-bd46-4f28-9ef2-4e1e3ce957fd"), null, false, new Guid("842bcc55-d686-43c5-a7c6-6371e6a8bdbe"), "Department 1", new Guid("1cb7f75b-1cd7-481f-99cf-0a17b5ba7b44"), new Guid("2a720891-3e68-4538-bf8f-51b6b5c2067c") },
                    { new Guid("72091839-9349-4b98-a466-5b0fcd3ee286"), null, false, new Guid("446e2d90-95c8-4767-93a8-a0621de33437"), "Department 2", new Guid("94bdfabe-e24f-4930-8d19-4c2c2c1cdfbb"), new Guid("2a720891-3e68-4538-bf8f-51b6b5c2067c") }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "RoleType", "UserId" },
                values: new object[,]
                {
                    { new Guid("22b5a2f2-3a87-44b9-a265-d08a8f3bea4f"), 2, new Guid("d0609810-1a2b-4630-8f53-282f690de8d5") },
                    { new Guid("380a0bad-960d-40c8-818c-1963734dc0c6"), 3, new Guid("842bcc55-d686-43c5-a7c6-6371e6a8bdbe") },
                    { new Guid("3f5a1278-44d5-42ea-8287-9b0987137f6a"), 3, new Guid("446e2d90-95c8-4767-93a8-a0621de33437") },
                    { new Guid("6767a841-1677-4946-ac50-98badab9e1d0"), 3, new Guid("d0609810-1a2b-4630-8f53-282f690de8d5") },
                    { new Guid("7baec578-67ba-4dc5-9c78-ba5941ddb1d7"), 5, new Guid("1cb7f75b-1cd7-481f-99cf-0a17b5ba7b44") },
                    { new Guid("dec1ce28-d169-4095-903c-3dd5b5e68f62"), 4, new Guid("27e1062d-397c-4030-8de3-b3f4d6464c4f") },
                    { new Guid("f9e63a94-4679-484f-92b5-a6e0cbd53ef3"), 5, new Guid("94bdfabe-e24f-4930-8d19-4c2c2c1cdfbb") },
                    { new Guid("fdfc185c-baf7-4a85-a575-e0affe03a371"), 1, new Guid("0d0c461a-6364-4fd6-ad98-97a8135f4d88") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("47d1d38f-bd46-4f28-9ef2-4e1e3ce957fd"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("72091839-9349-4b98-a466-5b0fcd3ee286"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: new Guid("22b5a2f2-3a87-44b9-a265-d08a8f3bea4f"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: new Guid("380a0bad-960d-40c8-818c-1963734dc0c6"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: new Guid("3f5a1278-44d5-42ea-8287-9b0987137f6a"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: new Guid("6767a841-1677-4946-ac50-98badab9e1d0"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: new Guid("7baec578-67ba-4dc5-9c78-ba5941ddb1d7"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: new Guid("dec1ce28-d169-4095-903c-3dd5b5e68f62"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: new Guid("f9e63a94-4679-484f-92b5-a6e0cbd53ef3"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: new Guid("fdfc185c-baf7-4a85-a575-e0affe03a371"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0d0c461a-6364-4fd6-ad98-97a8135f4d88"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1cb7f75b-1cd7-481f-99cf-0a17b5ba7b44"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("27e1062d-397c-4030-8de3-b3f4d6464c4f"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("446e2d90-95c8-4767-93a8-a0621de33437"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("842bcc55-d686-43c5-a7c6-6371e6a8bdbe"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("94bdfabe-e24f-4930-8d19-4c2c2c1cdfbb"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d0609810-1a2b-4630-8f53-282f690de8d5"));

            migrationBuilder.DropColumn(
                name: "FileName",
                table: "Documents");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Documents",
                newName: "SenderPhoneNumber");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Discriminator", "FirstName", "LastName", "OrganizationId", "Password", "RefreshToken", "Username" },
                values: new object[,]
                {
                    { new Guid("24e6879f-8110-4624-af8c-325e4e100271"), "Employee", "Global", "Operator", new Guid("2a720891-3e68-4538-bf8f-51b6b5c2067c"), "Operator", null, "GlobalOperator" },
                    { new Guid("34488a0b-c00f-4974-8b43-37e805c6f714"), "Employee", "Leader", "Department2", new Guid("2a720891-3e68-4538-bf8f-51b6b5c2067c"), "Dep2", null, "LeadDep2" },
                    { new Guid("3cc698a7-91f1-4573-9de9-aef3c8da9c7d"), "Employee", "CEO", "Organization", new Guid("2a720891-3e68-4538-bf8f-51b6b5c2067c"), "Organization", null, "CEO" },
                    { new Guid("92b7165e-c3b1-49f3-8ed2-bf79515fbbe2"), "Employee", "Admin", null, new Guid("2a720891-3e68-4538-bf8f-51b6b5c2067c"), "Admin", null, "Admin" },
                    { new Guid("c3a21171-47b2-425d-a47b-a231345d6b4b"), "Employee", "Leader", "Department2", new Guid("2a720891-3e68-4538-bf8f-51b6b5c2067c"), "Dep2", null, "OpeDep2" },
                    { new Guid("c871c293-79e7-4cbb-a365-d194578475c3"), "Employee", "Leader", "Department1", new Guid("2a720891-3e68-4538-bf8f-51b6b5c2067c"), "Dep1", null, "LeadDep1" },
                    { new Guid("e641cee4-58ee-42b0-b155-f090b1130d13"), "Employee", "Operator", "Department1", new Guid("2a720891-3e68-4538-bf8f-51b6b5c2067c"), "Dep1", null, "OpeDep1" }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Description", "IsOnlyForWorkFlow", "LeaderId", "Name", "OperatorId", "OrganizationId" },
                values: new object[,]
                {
                    { new Guid("27939632-d223-49ec-a9a5-86ccf04c9c54"), null, false, new Guid("c871c293-79e7-4cbb-a365-d194578475c3"), "Department 1", new Guid("e641cee4-58ee-42b0-b155-f090b1130d13"), new Guid("2a720891-3e68-4538-bf8f-51b6b5c2067c") },
                    { new Guid("a4a194cd-0c34-4d17-8403-4dc4195c3862"), null, false, new Guid("34488a0b-c00f-4974-8b43-37e805c6f714"), "Department 2", new Guid("c3a21171-47b2-425d-a47b-a231345d6b4b"), new Guid("2a720891-3e68-4538-bf8f-51b6b5c2067c") }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "RoleType", "UserId" },
                values: new object[,]
                {
                    { new Guid("26776e98-5fea-4acd-ad08-b4f90d5b6bb2"), 5, new Guid("c3a21171-47b2-425d-a47b-a231345d6b4b") },
                    { new Guid("2e7b5400-e775-47ff-a962-87cf89e6eb04"), 2, new Guid("3cc698a7-91f1-4573-9de9-aef3c8da9c7d") },
                    { new Guid("638c17e4-3ae6-4927-af46-0b55a5f03778"), 4, new Guid("24e6879f-8110-4624-af8c-325e4e100271") },
                    { new Guid("8ec4c680-9d8f-4648-8ac9-6306ddd8ad28"), 3, new Guid("c871c293-79e7-4cbb-a365-d194578475c3") },
                    { new Guid("a88b3a43-77fb-4181-aff8-986c65e2f7ea"), 3, new Guid("3cc698a7-91f1-4573-9de9-aef3c8da9c7d") },
                    { new Guid("c0722c38-3fb8-468d-a669-385274746b53"), 3, new Guid("34488a0b-c00f-4974-8b43-37e805c6f714") },
                    { new Guid("d376eea4-3e06-4213-a1ee-38838e772b9c"), 1, new Guid("92b7165e-c3b1-49f3-8ed2-bf79515fbbe2") },
                    { new Guid("e009c4fa-1c16-45dc-9eb0-187c71e93efc"), 5, new Guid("e641cee4-58ee-42b0-b155-f090b1130d13") }
                });
        }
    }
}
