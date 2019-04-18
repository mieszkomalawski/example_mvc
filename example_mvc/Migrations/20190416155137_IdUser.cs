﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace example_mvc.Migrations
{
    public partial class IdUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Recipe",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "IdentityUser",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUser", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recipe_UserId",
                table: "Recipe",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipe_IdentityUser_UserId",
                table: "Recipe",
                column: "UserId",
                principalTable: "IdentityUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipe_IdentityUser_UserId",
                table: "Recipe");

            migrationBuilder.DropTable(
                name: "IdentityUser");

            migrationBuilder.DropIndex(
                name: "IX_Recipe_UserId",
                table: "Recipe");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Recipe");
        }
    }
}
