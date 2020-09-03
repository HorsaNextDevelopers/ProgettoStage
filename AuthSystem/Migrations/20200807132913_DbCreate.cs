using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AuthSystem.Migrations
{
    public partial class DbCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Articolis",
                columns: table => new
                {
                    Id_articolo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome_Articolo = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    Tempo_produzione = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articolis", x => x.Id_articolo);
                });

            migrationBuilder.CreateTable(
                name: "Versamentis",
                columns: table => new
                {
                    Id_versamento = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero_pezzi = table.Column<string>(type: "nchar(250)", nullable: false),
                    Data = table.Column<DateTime>(nullable: false),
                    Tempo_prod = table.Column<decimal>(type: "numeric", nullable: false),
                    Id_articolo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Versamentis", x => x.Id_versamento);
                    table.ForeignKey(
                        name: "FK_Versamentis_Articolis_Id_articolo",
                        column: x => x.Id_articolo,
                        principalTable: "Articolis",
                        principalColumn: "Id_articolo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Versamentis_Id_articolo",
                table: "Versamentis",
                column: "Id_articolo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Versamentis");

            migrationBuilder.DropTable(
                name: "Articolis");
        }
    }
}
