using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Card_Sanctum.Infrastructure.Data.Migrations
{
    public partial class HobbyShop_and_Trade_Added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "BoosterPrice",
                table: "BoosterPacks",
                type: "decimal(5,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "HobbyShops",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Addres = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Budget = table.Column<decimal>(type: "decimal(5,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HobbyShops", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trades",
                columns: table => new
                {
                    HobbyShopId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BoosterPackId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trades", x => new { x.BoosterPackId, x.HobbyShopId });
                    table.ForeignKey(
                        name: "FK_Trades_BoosterPacks_BoosterPackId",
                        column: x => x.BoosterPackId,
                        principalTable: "BoosterPacks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trades_HobbyShops_HobbyShopId",
                        column: x => x.HobbyShopId,
                        principalTable: "HobbyShops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Trades_HobbyShopId",
                table: "Trades",
                column: "HobbyShopId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trades");

            migrationBuilder.DropTable(
                name: "HobbyShops");

            migrationBuilder.DropColumn(
                name: "BoosterPrice",
                table: "BoosterPacks");
        }
    }
}
