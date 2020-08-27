﻿// <auto-generated />
using System;
using DBProjekat.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DBProjekat.Migrations
{
    [DbContext(typeof(AgencyContext))]
    [Migration("20200827191116_ACM")]
    partial class ACM
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DBProjekat.Models.AirCompany", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("About")
                        .IsRequired();

                    b.Property<string>("Address")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Prices")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("AirCompanies");
                });

            modelBuilder.Entity("DBProjekat.Models.Destination", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AirCompanyId");

                    b.Property<string>("Destination1")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("AirCompanyId");

                    b.ToTable("Destination");
                });

            modelBuilder.Entity("DBProjekat.Models.Flight", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AirCompanyId");

                    b.Property<double>("FlightLength");

                    b.Property<DateTime>("LandingDate");

                    b.Property<DateTime>("TakeoffDate");

                    b.Property<DateTime>("TakeoffTime");

                    b.Property<double>("TicketPrice");

                    b.HasKey("Id");

                    b.HasIndex("AirCompanyId");

                    b.ToTable("Flight");
                });

            modelBuilder.Entity("DBProjekat.Models.Rating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AirCompanyId");

                    b.Property<int?>("FlightId");

                    b.HasKey("Id");

                    b.HasIndex("AirCompanyId");

                    b.HasIndex("FlightId");

                    b.ToTable("Rating");
                });

            modelBuilder.Entity("DBProjekat.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DBProjekat.Models.Destination", b =>
                {
                    b.HasOne("DBProjekat.Models.AirCompany", "AirCompany")
                        .WithMany("Destionations")
                        .HasForeignKey("AirCompanyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DBProjekat.Models.Flight", b =>
                {
                    b.HasOne("DBProjekat.Models.AirCompany", "AirCompany")
                        .WithMany("Flights")
                        .HasForeignKey("AirCompanyId");
                });

            modelBuilder.Entity("DBProjekat.Models.Rating", b =>
                {
                    b.HasOne("DBProjekat.Models.AirCompany", "AirCompany")
                        .WithMany("Ratings")
                        .HasForeignKey("AirCompanyId");

                    b.HasOne("DBProjekat.Models.Flight")
                        .WithMany("Ratings")
                        .HasForeignKey("FlightId");
                });
#pragma warning restore 612, 618
        }
    }
}
