using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TeamProject1.Migrations
{
    public partial class fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MyRecipe_Seasoning_Ingredient_I_id",
                table: "MyRecipe_Seasoning");

            migrationBuilder.RenameColumn(
                name: "I_id",
                table: "MyRecipe_Seasoning",
                newName: "S_id");

            migrationBuilder.RenameIndex(
                name: "IX_MyRecipe_Seasoning_I_id",
                table: "MyRecipe_Seasoning",
                newName: "IX_MyRecipe_Seasoning_S_id");

            migrationBuilder.AddForeignKey(
                name: "FK_MyRecipe_Seasoning_Seasoning_S_id",
                table: "MyRecipe_Seasoning",
                column: "S_id",
                principalTable: "Seasoning",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MyRecipe_Seasoning_Seasoning_S_id",
                table: "MyRecipe_Seasoning");

            migrationBuilder.RenameColumn(
                name: "S_id",
                table: "MyRecipe_Seasoning",
                newName: "I_id");

            migrationBuilder.RenameIndex(
                name: "IX_MyRecipe_Seasoning_S_id",
                table: "MyRecipe_Seasoning",
                newName: "IX_MyRecipe_Seasoning_I_id");

            migrationBuilder.AddForeignKey(
                name: "FK_MyRecipe_Seasoning_Ingredient_I_id",
                table: "MyRecipe_Seasoning",
                column: "I_id",
                principalTable: "Ingredient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
