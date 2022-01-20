using Microsoft.EntityFrameworkCore.Migrations;

namespace Projekat.Migrations
{
    public partial class V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Igrica",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Igrica", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Case",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Oznaka = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Kapacitet = table.Column<int>(type: "int", nullable: false),
                    Napunjenost = table.Column<int>(type: "int", nullable: false),
                    GameID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Case", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Case_Igrica_GameID",
                        column: x => x.GameID,
                        principalTable: "Igrica",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Boje",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    red1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    red2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    red3 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    red4 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CasaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boje", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Boje_Case_CasaId",
                        column: x => x.CasaId,
                        principalTable: "Case",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Boje_CasaId",
                table: "Boje",
                column: "CasaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Case_GameID",
                table: "Case",
                column: "GameID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Boje");

            migrationBuilder.DropTable(
                name: "Case");

            migrationBuilder.DropTable(
                name: "Igrica");
        }
    }
}
