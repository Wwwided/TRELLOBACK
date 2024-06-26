﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TRELLOBACK.Context;

#nullable disable

namespace TRELLOBACK.Migrations
{
    [DbContext(typeof(TrellowiContext))]
    partial class TrellowiContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TRELLOBACK.Models.Carte", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("DescriptionCarte")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ListeId")
                        .HasColumnType("int");

                    b.Property<int>("StatutCarte")
                        .HasColumnType("int");

                    b.Property<string>("TitreCarte")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ListeId");

                    b.ToTable("Cartes");
                });

            modelBuilder.Entity("TRELLOBACK.Models.Liste", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ProjetId")
                        .HasColumnType("int");

                    b.Property<string>("TitreListe")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProjetId");

                    b.ToTable("Listes");
                });

            modelBuilder.Entity("TRELLOBACK.Models.Projet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("TitreProjet")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Projets");
                });

            modelBuilder.Entity("TRELLOBACK.Models.Carte", b =>
                {
                    b.HasOne("TRELLOBACK.Models.Liste", "Liste")
                        .WithMany()
                        .HasForeignKey("ListeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Liste");
                });

            modelBuilder.Entity("TRELLOBACK.Models.Liste", b =>
                {
                    b.HasOne("TRELLOBACK.Models.Projet", "Projet")
                        .WithMany("Listes")
                        .HasForeignKey("ProjetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Projet");
                });

            modelBuilder.Entity("TRELLOBACK.Models.Projet", b =>
                {
                    b.Navigation("Listes");
                });
#pragma warning restore 612, 618
        }
    }
}
