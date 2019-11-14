using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TeamProject1.Migrations
{
    public partial class MyRecipe_Seasoning : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MyRecipe_Seasoning",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    I_id = table.Column<int>(nullable: false),
                    R_id = table.Column<int>(nullable: false),
                    Weight = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyRecipe_Seasoning", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MyRecipe_Seasoning_Ingredient_I_id",
                        column: x => x.I_id,
                        principalTable: "Ingredient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MyRecipe_Seasoning_MyRecipe_R_id",
                        column: x => x.R_id,
                        principalTable: "MyRecipe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MyRecipe_Seasoning_I_id",
                table: "MyRecipe_Seasoning",
                column: "I_id");

            migrationBuilder.CreateIndex(
                name: "IX_MyRecipe_Seasoning_R_id",
                table: "MyRecipe_Seasoning",
                column: "R_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MyRecipe_Seasoning");
        }
    }
}
