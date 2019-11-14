﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using TeamProject1.Models;

namespace TeamProject1.Migrations
{
    [DbContext(typeof(TeamProject1Context))]
    [Migration("20191113235759_Secondary")]
    partial class Secondary
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TeamProject1.Models.Grain", b =>
                {
                    b.Property<int>("Id");

                    b.Property<decimal>("Carbs");

                    b.HasKey("Id");

                    b.ToTable("Grain");
                });

            modelBuilder.Entity("TeamProject1.Models.Herbs", b =>
                {
                    b.Property<int>("Id");

                    b.Property<int>("Hotness");

                    b.HasKey("Id");

                    b.ToTable("Herbs");
                });

            modelBuilder.Entity("TeamProject1.Models.Ingredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Calories");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Ingredient");
                });

            modelBuilder.Entity("TeamProject1.Models.Meat", b =>
                {
                    b.Property<int>("Id");

                    b.Property<decimal>("Protein");

                    b.HasKey("Id");

                    b.ToTable("Meat");
                });

            modelBuilder.Entity("TeamProject1.Models.MyRecipe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("MyRecipe");
                });

            modelBuilder.Entity("TeamProject1.Models.MyRecipe_Ingredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("I_id");

                    b.Property<int>("R_id");

                    b.Property<decimal>("Weight");

                    b.HasKey("Id");

                    b.HasIndex("I_id");

                    b.HasIndex("R_id", "I_id")
                        .IsUnique();

                    b.ToTable("MyRecipe_Ingredient");
                });

            modelBuilder.Entity("TeamProject1.Models.Seasoning", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Calories");

                    b.Property<string>("Name");

                    b.Property<string>("Origin");

                    b.HasKey("Id");

                    b.ToTable("Seasoning");
                });

            modelBuilder.Entity("TeamProject1.Models.Spices", b =>
                {
                    b.Property<int>("Id");

                    b.Property<int>("Hotness");

                    b.HasKey("Id");

                    b.ToTable("Spices");
                });

            modelBuilder.Entity("TeamProject1.Models.Vegetable", b =>
                {
                    b.Property<int>("Id");

                    b.Property<decimal>("Fiber");

                    b.HasKey("Id");

                    b.ToTable("Vegetable");
                });

            modelBuilder.Entity("TeamProject1.Models.Grain", b =>
                {
                    b.HasOne("TeamProject1.Models.Ingredient", "Ingredient")
                        .WithMany()
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TeamProject1.Models.Herbs", b =>
                {
                    b.HasOne("TeamProject1.Models.Seasoning", "Seasoning")
                        .WithMany()
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TeamProject1.Models.Meat", b =>
                {
                    b.HasOne("TeamProject1.Models.Ingredient", "Ingredient")
                        .WithMany()
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TeamProject1.Models.MyRecipe_Ingredient", b =>
                {
                    b.HasOne("TeamProject1.Models.Ingredient", "Ingredient")
                        .WithMany()
                        .HasForeignKey("I_id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TeamProject1.Models.MyRecipe", "MyRecipe")
                        .WithMany()
                        .HasForeignKey("R_id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TeamProject1.Models.Spices", b =>
                {
                    b.HasOne("TeamProject1.Models.Seasoning", "Seasoning")
                        .WithMany()
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TeamProject1.Models.Vegetable", b =>
                {
                    b.HasOne("TeamProject1.Models.Ingredient", "Ingredient")
                        .WithMany()
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
