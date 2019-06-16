using Microsoft.EntityFrameworkCore.Migrations;

namespace example_mvc.Migrations
{
    public partial class cleanUp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Breakfast",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "Dessert",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "Dinner",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "Drink",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "Preserves",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "Soup",
                table: "Recipes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Breakfast",
                table: "Recipes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Dessert",
                table: "Recipes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Dinner",
                table: "Recipes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Drink",
                table: "Recipes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Preserves",
                table: "Recipes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Soup",
                table: "Recipes",
                nullable: false,
                defaultValue: false);
        }
    }
}
