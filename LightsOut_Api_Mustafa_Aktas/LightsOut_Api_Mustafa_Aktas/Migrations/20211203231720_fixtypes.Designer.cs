﻿// <auto-generated />
using LightsOut_Api_Mustafa_Aktas.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LightsOut_Api_Mustafa_Aktas.Migrations
{
    [DbContext(typeof(GameDbContext))]
    [Migration("20211203231720_fixtypes")]
    partial class fixtypes
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LightsOut_Api_Mustafa_Aktas.DataAccess.Models.DefaultTile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("GameSetupId")
                        .HasColumnType("bigint");

                    b.Property<int>("TileId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GameSetupId");

                    b.HasIndex("Id");

                    b.ToTable("DefaultTiles");
                });

            modelBuilder.Entity("LightsOut_Api_Mustafa_Aktas.DataAccess.Models.GameSetup", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ColCount")
                        .HasColumnType("int");

                    b.Property<int>("RowCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.ToTable("GameSetups");
                });

            modelBuilder.Entity("LightsOut_Api_Mustafa_Aktas.DataAccess.Models.DefaultTile", b =>
                {
                    b.HasOne("LightsOut_Api_Mustafa_Aktas.DataAccess.Models.GameSetup", "GameSetup")
                        .WithMany("DefaultTiles")
                        .HasForeignKey("GameSetupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GameSetup");
                });

            modelBuilder.Entity("LightsOut_Api_Mustafa_Aktas.DataAccess.Models.GameSetup", b =>
                {
                    b.Navigation("DefaultTiles");
                });
#pragma warning restore 612, 618
        }
    }
}
