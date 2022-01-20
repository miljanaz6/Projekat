﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Models;

namespace Projekat.Migrations
{
    [DbContext(typeof(GameContext))]
    [Migration("20220107224742_V1")]
    partial class V1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Models.Casa", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("GameID")
                        .HasColumnType("int");

                    b.Property<int>("Kapacitet")
                        .HasColumnType("int");

                    b.Property<int>("Napunjenost")
                        .HasColumnType("int");

                    b.Property<string>("Oznaka")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID");

                    b.HasIndex("GameID");

                    b.ToTable("Case");
                });

            modelBuilder.Entity("Models.Game", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID");

                    b.ToTable("Igrica");
                });

            modelBuilder.Entity("Models.TecnostBoje", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("CasaId")
                        .HasColumnType("int");

                    b.Property<string>("red1")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("red2")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("red3")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("red4")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID");

                    b.HasIndex("CasaId")
                        .IsUnique();

                    b.ToTable("Boje");
                });

            modelBuilder.Entity("Models.Casa", b =>
                {
                    b.HasOne("Models.Game", "Game")
                        .WithMany("Case")
                        .HasForeignKey("GameID");

                    b.Navigation("Game");
                });

            modelBuilder.Entity("Models.TecnostBoje", b =>
                {
                    b.HasOne("Models.Casa", "Casa")
                        .WithOne("TecnostBoje")
                        .HasForeignKey("Models.TecnostBoje", "CasaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Casa");
                });

            modelBuilder.Entity("Models.Casa", b =>
                {
                    b.Navigation("TecnostBoje");
                });

            modelBuilder.Entity("Models.Game", b =>
                {
                    b.Navigation("Case");
                });
#pragma warning restore 612, 618
        }
    }
}