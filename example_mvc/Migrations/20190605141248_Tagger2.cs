using Microsoft.EntityFrameworkCore.Migrations;

namespace example_mvc.Migrations
{
    public partial class Tagger2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeTag_Recipe_RecipeId",
                table: "RecipeTag");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Tag",
                newName: "TagId");

            migrationBuilder.RenameColumn(
                name: "RecipeId",
                table: "RecipeTag",
                newName: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeTag_Recipe_Id",
                table: "RecipeTag",
                column: "Id",
                principalTable: "Recipe",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeTag_Recipe_Id",
                table: "RecipeTag");

            migrationBuilder.RenameColumn(
                name: "TagId",
                table: "Tag",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "RecipeTag",
                newName: "RecipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeTag_Recipe_RecipeId",
                table: "RecipeTag",
                column: "RecipeId",
                principalTable: "Recipe",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
