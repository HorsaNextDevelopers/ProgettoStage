using Microsoft.EntityFrameworkCore.Migrations;

namespace AuthSystem.Migrations
{
    public partial class prova12 : Migration
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
                value: "ac22351c-0105-4963-a8ed-6443c599a31d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                column: "ConcurrencyStamp",
                value: "aa17a7bd-526a-416d-89dd-ca52840a59c4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "325116c2-2d31-4213-93d2-05e07148abbe", "AQAAAAEAACcQAAAAEBsqMQ1jVBC3XKjEQ2hsU5jT2SFY+ZfwSEa6Qm4YKqfGRQAIJMchFVuQK3J+9RzdvA==" });
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
