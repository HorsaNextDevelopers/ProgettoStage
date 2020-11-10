using Microsoft.EntityFrameworkCore.Migrations;

namespace AuthSystem.Migrations
{
    public partial class Prova12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Descrizione",
                table: "Postazioni",
                type: "nvarchar(250)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "37c42e1d - 92e5 - 4216 - a308 - 2fa43d187bf1",
                column: "ConcurrencyStamp",
                value: "f43f18b0-0a9d-4aff-900f-bb0b48bf17f1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                column: "ConcurrencyStamp",
                value: "2886b2ba-44f0-46c1-babf-d22127cd7dce");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0f145021-3b79-47c5-bd3e-ebf70e946bf9", "AQAAAAEAACcQAAAAEPTOw17GMNzcdnt5mfigBRMTfNqZN7+yGDWXnLBfB7jxWUStqLREXDYRMhX918cmJg==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descrizione",
                table: "Postazioni");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "37c42e1d - 92e5 - 4216 - a308 - 2fa43d187bf1",
                column: "ConcurrencyStamp",
                value: "92a67af1-eb91-4499-9f52-8dc0ee24e3c8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                column: "ConcurrencyStamp",
                value: "76102d66-aa1c-4b98-9f96-26ab58543354");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "aab9af04-1ca9-44bf-9746-781e62aac12c", "AQAAAAEAACcQAAAAEEAm5zJ6CeFHlzaZELGiOgD+Uh1L64wqsUlRVCi5GdiuBioYDu7e23h/aHyPKFktcA==" });
        }
    }
}
