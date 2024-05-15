using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ElectronicGovernment.API.Migrations
{
    /// <inheritdoc />
    public partial class AddedAttachmentsToDocumentd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "SenderPhoneNumber",
                table: "Documents",
                type: "nvarchar(max)",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "SenderPhoneNumber",
                table: "Documents");

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
    }
}
