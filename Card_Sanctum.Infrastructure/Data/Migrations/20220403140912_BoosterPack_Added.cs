using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Card_Sanctum.Infrastructure.Data.Migrations
{
    public partial class BoosterPack_Added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "BoosterPackId",
                table: "Cards",
                type: "uniqueidentifier",
                maxLength: 450,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BoosterPack",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Edition = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CardCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoosterPack", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cards_BoosterPackId",
                table: "Cards",
                column: "BoosterPackId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_BoosterPack_BoosterPackId",
                table: "Cards",
                column: "BoosterPackId",
                principalTable: "BoosterPack",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_BoosterPack_BoosterPackId",
                table: "Cards");

            migrationBuilder.DropTable(
                name: "BoosterPack");

            migrationBuilder.DropIndex(
                name: "IX_Cards_BoosterPackId",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "BoosterPackId",
                table: "Cards");
        }
    }
}
