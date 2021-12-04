using Microsoft.EntityFrameworkCore.Migrations;

namespace LightsOut_Api_Mustafa_Aktas.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GameSetups",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RowCount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ColCount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameSetups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DefaultTiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TileId = table.Column<int>(type: "int", nullable: false),
                    GameSetupId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DefaultTiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DefaultTiles_GameSetups_GameSetupId",
                        column: x => x.GameSetupId,
                        principalTable: "GameSetups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DefaultTiles_GameSetupId",
                table: "DefaultTiles",
                column: "GameSetupId");

            migrationBuilder.CreateIndex(
                name: "IX_DefaultTiles_Id",
                table: "DefaultTiles",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_GameSetups_Id",
                table: "GameSetups",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DefaultTiles");

            migrationBuilder.DropTable(
                name: "GameSetups");
        }
    }
}