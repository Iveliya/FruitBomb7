using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FruityBombData.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PayoutRuless",
                columns: table => new
                {
                    RuleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Combination = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PayoutAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayoutRuless", x => x.RuleId);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Symbols",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Payout = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Symbols", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GameResultss",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SymbolId1 = table.Column<int>(type: "int", nullable: false),
                    SymbolId2 = table.Column<int>(type: "int", nullable: false),
                    SymbolId3 = table.Column<int>(type: "int", nullable: false),
                    SymbolId4 = table.Column<int>(type: "int", nullable: false),
                    BetAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WinAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PlayerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameResultss", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameResultss_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GameResultss_Symbols_SymbolId1",
                        column: x => x.SymbolId1,
                        principalTable: "Symbols",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GameResultss_Symbols_SymbolId2",
                        column: x => x.SymbolId2,
                        principalTable: "Symbols",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GameResultss_Symbols_SymbolId3",
                        column: x => x.SymbolId3,
                        principalTable: "Symbols",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GameResultss_Symbols_SymbolId4",
                        column: x => x.SymbolId4,
                        principalTable: "Symbols",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameResultss_PlayerId",
                table: "GameResultss",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_GameResultss_SymbolId1",
                table: "GameResultss",
                column: "SymbolId1");

            migrationBuilder.CreateIndex(
                name: "IX_GameResultss_SymbolId2",
                table: "GameResultss",
                column: "SymbolId2");

            migrationBuilder.CreateIndex(
                name: "IX_GameResultss_SymbolId3",
                table: "GameResultss",
                column: "SymbolId3");

            migrationBuilder.CreateIndex(
                name: "IX_GameResultss_SymbolId4",
                table: "GameResultss",
                column: "SymbolId4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameResultss");

            migrationBuilder.DropTable(
                name: "PayoutRuless");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Symbols");
        }
    }
}
