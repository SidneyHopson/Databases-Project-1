using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TeamProject1.Migrations
{
    public partial class Secondary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Grain",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Carbs = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grain", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Grain_Ingredient_Id",
                        column: x => x.Id,
                        principalTable: "Ingredient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Seasoning",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Calories = table.Column<decimal>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Origin = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seasoning", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vegetable",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Fiber = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vegetable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vegetable_Ingredient_Id",
                        column: x => x.Id,
                        principalTable: "Ingredient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Herbs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Hotness = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Herbs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Herbs_Seasoning_Id",
                        column: x => x.Id,
                        principalTable: "Seasoning",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Spices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Hotness = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Spices_Seasoning_Id",
                        column: x => x.Id,
                        principalTable: "Seasoning",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Grain");

            migrationBuilder.DropTable(
                name: "Herbs");

            migrationBuilder.DropTable(
                name: "Spices");

            migrationBuilder.DropTable(
                name: "Vegetable");

            migrationBuilder.DropTable(
                name: "Seasoning");
        }
    }
}
