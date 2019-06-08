using Microsoft.EntityFrameworkCore.Migrations;

namespace example_mvc.Migrations
{
    public partial class List : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RecipeId",
                table: "RecipeTag",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TagId1",
                table: "RecipeTag",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RecipeTag_RecipeId",
                table: "RecipeTag",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeTag_TagId1",
                table: "RecipeTag",
                column: "TagId1");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeTag_Recipe_RecipeId",
                table: "RecipeTag",
                column: "RecipeId",
                principalTable: "Recipe",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeTag_Tag_TagId1",
                table: "RecipeTag",
                column: "TagId1",
                principalTable: "Tag",
                principalColumn: "TagId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeTag_Recipe_RecipeId",
                table: "RecipeTag");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeTag_Tag_TagId1",
                table: "RecipeTag");

            migrationBuilder.DropIndex(
                name: "IX_RecipeTag_RecipeId",
                table: "RecipeTag");

            migrationBuilder.DropIndex(
                name: "IX_RecipeTag_TagId1",
                table: "RecipeTag");

            migrationBuilder.DropColumn(
                name: "RecipeId",
                table: "RecipeTag");

            migrationBuilder.DropColumn(
                name: "TagId1",
                table: "RecipeTag");
        }
    }
}
