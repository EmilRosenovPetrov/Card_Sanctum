using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Card_Sanctum.Infrastructure.Data.Migrations
{
    public partial class BoosterToCardRelationAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_AspNetUsers_ApplicationUserId",
                table: "Cards");

            migrationBuilder.DropTable(
                name: "BoosterPackCards");

            migrationBuilder.DropIndex(
                name: "IX_Cards_ApplicationUserId",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Cards");

            migrationBuilder.CreateTable(
                name: "ApplicationUserCard",
                columns: table => new
                {
                    CardsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsersId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserCard", x => new { x.CardsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_ApplicationUserCard_AspNetUsers_UsersId",
                        column: x => x.UsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUserCard_Cards_CardsId",
                        column: x => x.CardsId,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BoosterPackCard",
                columns: table => new
                {
                    BoosterPackCardsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CardsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoosterPackCard", x => new { x.BoosterPackCardsId, x.CardsId });
                    table.ForeignKey(
                        name: "FK_BoosterPackCard_BoosterPacks_BoosterPackCardsId",
                        column: x => x.BoosterPackCardsId,
                        principalTable: "BoosterPacks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BoosterPackCard_Cards_CardsId",
                        column: x => x.CardsId,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserCard_UsersId",
                table: "ApplicationUserCard",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_BoosterPackCard_CardsId",
                table: "BoosterPackCard",
                column: "CardsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUserCard");

            migrationBuilder.DropTable(
                name: "BoosterPackCard");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Cards",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BoosterPackCards",
                columns: table => new
                {
                    BoosterPackId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CardId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                name: "IX_Cards_ApplicationUserId",
                table: "Cards",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BoosterPackCards_CardId",
                table: "BoosterPackCards",
                column: "CardId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_AspNetUsers_ApplicationUserId",
                table: "Cards",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
