using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Card_Sanctum.Infrastructure.Data.Migrations
{
    public partial class Add_BoosterPack : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_BoosterPack_BoosterPackId",
                table: "Cards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BoosterPack",
                table: "BoosterPack");

            migrationBuilder.RenameTable(
                name: "BoosterPack",
                newName: "BoosterPacks");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BoosterPacks",
                table: "BoosterPacks",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_BoosterPacks_BoosterPackId",
                table: "Cards",
                column: "BoosterPackId",
                principalTable: "BoosterPacks",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_BoosterPacks_BoosterPackId",
                table: "Cards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BoosterPacks",
                table: "BoosterPacks");

            migrationBuilder.RenameTable(
                name: "BoosterPacks",
                newName: "BoosterPack");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BoosterPack",
                table: "BoosterPack",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_BoosterPack_BoosterPackId",
                table: "Cards",
                column: "BoosterPackId",
                principalTable: "BoosterPack",
                principalColumn: "Id");
        }
    }
}
