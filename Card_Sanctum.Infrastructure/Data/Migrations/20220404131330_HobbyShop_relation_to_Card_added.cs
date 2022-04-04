using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Card_Sanctum.Infrastructure.Data.Migrations
{
    public partial class HobbyShop_relation_to_Card_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "HobbyShopId",
                table: "Cards",
                type: "uniqueidentifier",
                maxLength: 450,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cards_HobbyShopId",
                table: "Cards",
                column: "HobbyShopId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_HobbyShops_HobbyShopId",
                table: "Cards",
                column: "HobbyShopId",
                principalTable: "HobbyShops",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_HobbyShops_HobbyShopId",
                table: "Cards");

            migrationBuilder.DropIndex(
                name: "IX_Cards_HobbyShopId",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "HobbyShopId",
                table: "Cards");
        }
    }
}
