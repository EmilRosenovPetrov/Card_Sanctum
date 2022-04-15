using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Card_Sanctum.Infrastructure.Data.Migrations
{
    public partial class BoosterCard_mapping_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_BoosterPacks_BoosterPackId",
                table: "Cards");

            migrationBuilder.DropIndex(
                name: "IX_Cards_BoosterPackId",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "BoosterPackId",
                table: "Cards");

            migrationBuilder.AlterColumn<decimal>(
                name: "BoosterPrice",
                table: "BoosterPacks",
                type: "decimal(5,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,2)");

            migrationBuilder.CreateTable(
                name: "BoosterPackCards",
                columns: table => new
                {
                    CardId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BoosterPackId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoosterPackCards", x => new { x.BoosterPackId, x.CardId });
                    table.ForeignKey(
                        name: "FK_BoosterPackCards_BoosterPacks_BoosterPackId",
                        column: x => x.BoosterPackId,
                        principalTable: "BoosterPacks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BoosterPackCards_Cards_CardId",
                        column: x => x.CardId,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BoosterPackCards_CardId",
                table: "BoosterPackCards",
                column: "CardId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BoosterPackCards");

            migrationBuilder.AddColumn<Guid>(
                name: "BoosterPackId",
                table: "Cards",
                type: "uniqueidentifier",
                maxLength: 450,
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "BoosterPrice",
                table: "BoosterPacks",
                type: "decimal(5,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,2)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cards_BoosterPackId",
                table: "Cards",
                column: "BoosterPackId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_BoosterPacks_BoosterPackId",
                table: "Cards",
                column: "BoosterPackId",
                principalTable: "BoosterPacks",
                principalColumn: "Id");
        }
    }
}
