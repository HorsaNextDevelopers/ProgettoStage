using Microsoft.EntityFrameworkCore.Migrations;

namespace AuthSystem.Migrations
{
    public partial class prova : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "37c42e1d - 92e5 - 4216 - a308 - 2fa43d187bf1",
                column: "ConcurrencyStamp",
                value: "0d19ea4b-311f-4f2b-b215-1324988393c4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                column: "ConcurrencyStamp",
                value: "bc74e453-ea34-4353-9096-7b8bb44cdfa6");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b52b67f5-1266-486d-bba6-0695342d8020", "AQAAAAEAACcQAAAAEHuWdjciuPqXKwaR7ELePJTI6tCXZgxYNf+GhC/+8DN69cAvxcTB900i+Q8HUA+CFg==" });
        }
    }
}
