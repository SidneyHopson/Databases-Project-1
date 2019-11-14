using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TeamProject1.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ingredient",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Calories = table.Column<decimal>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredient", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MyRecipe",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyRecipe", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Meat",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Protein = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Meat_Ingredient_Id",
                        column: x => x.Id,
                        principalTable: "Ingredient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MyRecipe_Ingredient",
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
                    table.PrimaryKey("PK_MyRecipe_Ingredient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MyRecipe_Ingredient_Ingredient_I_id",
                        column: x => x.I_id,
                        principalTable: "Ingredient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MyRecipe_Ingredient_MyRecipe_R_id",
                        column: x => x.R_id,
                        principalTable: "MyRecipe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MyRecipe_Ingredient_I_id",
                table: "MyRecipe_Ingredient",
                column: "I_id");

            migrationBuilder.CreateIndex(
                name: "IX_MyRecipe_Ingredient_R_id_I_id",
                table: "MyRecipe_Ingredient",
                columns: new[] { "R_id", "I_id" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Meat");

            migrationBuilder.DropTable(
                name: "MyRecipe_Ingredient");

            migrationBuilder.DropTable(
                name: "Ingredient");

            migrationBuilder.DropTable(
                name: "MyRecipe");
        }
    }
}
