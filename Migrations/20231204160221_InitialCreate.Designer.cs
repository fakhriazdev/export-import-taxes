﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using taxex_api.context;

#nullable disable

namespace taxex_api.Migrations
{
    [DbContext(typeof(MainContext))]
    [Migration("20231204160221_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("taxex_api.model.Country", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("kd_country")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("m_country");

                    b.HasData(
                        new
                        {
                            id = 1,
                            kd_country = "ID",
                            name = "Indonesia"
                        },
                        new
                        {
                            id = 2,
                            kd_country = "SG",
                            name = "Singapore"
                        },
                        new
                        {
                            id = 3,
                            kd_country = "IR",
                            name = "Iraq"
                        },
                        new
                        {
                            id = 4,
                            kd_country = "MY",
                            name = "Malaysia"
                        },
                        new
                        {
                            id = 5,
                            kd_country = "PH",
                            name = "Philippines"
                        });
                });

            modelBuilder.Entity("taxex_api.model.Harbour", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<int>("id_country")
                        .HasColumnType("integer");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.HasIndex("id_country");

                    b.ToTable("m_harbour");

                    b.HasData(
                        new
                        {
                            id = 111,
                            id_country = 2,
                            name = "Jurong"
                        },
                        new
                        {
                            id = 112,
                            id_country = 2,
                            name = "Marina"
                        },
                        new
                        {
                            id = 113,
                            id_country = 2,
                            name = "Keppel"
                        },
                        new
                        {
                            id = 114,
                            id_country = 1,
                            name = "Merak"
                        },
                        new
                        {
                            id = 115,
                            id_country = 1,
                            name = "Batam"
                        },
                        new
                        {
                            id = 116,
                            id_country = 3,
                            name = "Klang"
                        },
                        new
                        {
                            id = 117,
                            id_country = 4,
                            name = "Flous"
                        },
                        new
                        {
                            id = 118,
                            id_country = 5,
                            name = "Rafles"
                        });
                });

            modelBuilder.Entity("taxex_api.model.Harbour", b =>
                {
                    b.HasOne("taxex_api.model.Country", "Country")
                        .WithMany("Harbours")
                        .HasForeignKey("id_country")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("taxex_api.model.Country", b =>
                {
                    b.Navigation("Harbours");
                });
#pragma warning restore 612, 618
        }
    }
}
