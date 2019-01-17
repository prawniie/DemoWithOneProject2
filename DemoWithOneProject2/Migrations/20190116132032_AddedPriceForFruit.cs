using Microsoft.EntityFrameworkCore.Migrations;

namespace DemoWithOneProject2.Migrations
{
    public partial class AddedPriceForFruit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Fruits",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Fruits");
        }
    }
}
