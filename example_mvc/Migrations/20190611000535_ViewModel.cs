using Microsoft.EntityFrameworkCore.Migrations;

namespace example_mvc.Migrations
{
    public partial class ViewModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeTag_Recipe_Id",
                table: "RecipeTag");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeTag_Tag_TagId",
                table: "RecipeTag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tag",
                table: "Tag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecipeTag",
                table: "RecipeTag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Recipe",
                table: "Recipe");

            migrationBuilder.RenameTable(
                name: "Tag",
                newName: "Tags");

            migrationBuilder.RenameTable(
                name: "RecipeTag",
                newName: "RecipeTags");

            migrationBuilder.RenameTable(
                name: "Recipe",
                newName: "Recipes");

            migrationBuilder.RenameIndex(
                name: "IX_RecipeTag_TagId",
                table: "RecipeTags",
                newName: "IX_RecipeTags_TagId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tags",
                table: "Tags",
                column: "TagId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecipeTags",
                table: "RecipeTags",
                columns: new[] { "Id", "TagId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Recipes",
                table: "Recipes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeTags_Recipes_Id",
                table: "RecipeTags",
                column: "Id",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeTags_Tags_TagId",
                table: "RecipeTags",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "TagId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeTags_Recipes_Id",
                table: "RecipeTags");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeTags_Tags_TagId",
                table: "RecipeTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tags",
                table: "Tags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecipeTags",
                table: "RecipeTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Recipes",
                table: "Recipes");

            migrationBuilder.RenameTable(
                name: "Tags",
                newName: "Tag");

            migrationBuilder.RenameTable(
                name: "RecipeTags",
                newName: "RecipeTag");

            migrationBuilder.RenameTable(
                name: "Recipes",
                newName: "Recipe");

            migrationBuilder.RenameIndex(
                name: "IX_RecipeTags_TagId",
                table: "RecipeTag",
                newName: "IX_RecipeTag_TagId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tag",
                table: "Tag",
                column: "TagId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecipeTag",
                table: "RecipeTag",
                columns: new[] { "Id", "TagId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Recipe",
                table: "Recipe",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeTag_Recipe_Id",
                table: "RecipeTag",
                column: "Id",
                principalTable: "Recipe",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeTag_Tag_TagId",
                table: "RecipeTag",
                column: "TagId",
                principalTable: "Tag",
                principalColumn: "TagId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
