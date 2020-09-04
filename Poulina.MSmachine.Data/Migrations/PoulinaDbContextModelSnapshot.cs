﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Ms_Machine.Domain.Poulina.MSmachine.Domain.Data;

namespace Poulina.MSmachine.Data.Migrations
{
    [DbContext(typeof(PoulinaDbContext))]
    partial class PoulinaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Ms_Machine.Domain.Poulina.MSmachine.Domain.Models.Filiaire", b =>
                {
                    b.Property<Guid>("id_filiaire")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("label")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id_filiaire");

                    b.ToTable("Filiaire");
                });

            modelBuilder.Entity("Ms_Machine.Domain.Poulina.MSmachine.Domain.Models.Fournisseur", b =>
                {
                    b.Property<Guid>("id_fournisseur")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("adresse_fournisseur")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("label")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id_fournisseur");

                    b.ToTable("Frournisseur");
                });

            modelBuilder.Entity("Ms_Machine.Domain.Poulina.MSmachine.Domain.Models.Machine", b =>
                {
                    b.Property<Guid>("id_machine")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("etat_machine")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("id_fournisseur")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("label")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("type_machine")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id_machine");

                    b.HasIndex("id_fournisseur");

                    b.ToTable("Machine");
                });

            modelBuilder.Entity("Ms_Machine.Domain.Poulina.MSmachine.Domain.Models.Service", b =>
                {
                    b.Property<Guid>("id_service")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("id_filiaire")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("label")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id_service");

                    b.HasIndex("id_filiaire");

                    b.ToTable("Service");
                });

            modelBuilder.Entity("Ms_Machine.Domain.Poulina.MSmachine.Domain.Models.Machine", b =>
                {
                    b.HasOne("Ms_Machine.Domain.Poulina.MSmachine.Domain.Models.Fournisseur", "Fournisseur")
                        .WithMany("Machines")
                        .HasForeignKey("id_fournisseur")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Ms_Machine.Domain.Poulina.MSmachine.Domain.Models.Service", b =>
                {
                    b.HasOne("Ms_Machine.Domain.Poulina.MSmachine.Domain.Models.Filiaire", "Filiaire")
                        .WithMany("Services")
                        .HasForeignKey("id_filiaire")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
