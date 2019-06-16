using Microsoft.EntityFrameworkCore.Migrations;

namespace example_mvc.Migrations
{
    public partial class Tags : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Breakfast",
                table: "Recipe",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Dessert",
                table: "Recipe",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Dinner",
                table: "Recipe",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Drink",
                table: "Recipe",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Preserves",
                table: "Recipe",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Soup",
                table: "Recipe",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Breakfast",
                table: "Recipe");

            migrationBuilder.DropColumn(
                name: "Dessert",
                table: "Recipe");

            migrationBuilder.DropColumn(
                name: "Dinner",
                table: "Recipe");

            migrationBuilder.DropColumn(
                name: "Drink",
                table: "Recipe");

            migrationBuilder.DropColumn(
                name: "Preserves",
                table: "Recipe");

            migrationBuilder.DropColumn(
                name: "Soup",
                table: "Recipe");
        }
    }
}
