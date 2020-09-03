﻿// <auto-generated />
using System;
using AuthSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AuthSystem.Migrations
{
    [DbContext(typeof(NContext))]
    [Migration("20200807132913_DbCreate")]
    partial class DbCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AuthSystem.Models.Articoli", b =>
                {
                    b.Property<int>("Id_articolo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descrizione")
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Nome_Articolo")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)");

                    b.Property<decimal>("Tempo_produzione")
                        .HasColumnType("numeric");

                    b.HasKey("Id_articolo");

                    b.ToTable("Articolis");
                });

            modelBuilder.Entity("AuthSystem.Models.Versamenti", b =>
                {
                    b.Property<int>("Id_versamento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<int>("Id_articolo")
                        .HasColumnType("int");

                    b.Property<string>("Numero_pezzi")
                        .IsRequired()
                        .HasColumnType("nchar(250)");

                    b.Property<decimal>("Tempo_prod")
                        .HasColumnType("numeric");

                    b.HasKey("Id_versamento");

                    b.HasIndex("Id_articolo");

                    b.ToTable("Versamentis");
                });

            modelBuilder.Entity("AuthSystem.Models.Versamenti", b =>
                {
                    b.HasOne("AuthSystem.Models.Articoli", "Articoli")
                        .WithMany("Versamentis")
                        .HasForeignKey("Id_articolo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
