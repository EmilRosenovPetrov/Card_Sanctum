using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Card_Sanctum.Infrastructure.Data.Migrations
{
    public partial class CardQuantity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Cards",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Cards");
        }
    }
}
