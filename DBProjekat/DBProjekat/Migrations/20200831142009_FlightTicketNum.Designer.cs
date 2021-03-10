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
    [Migration("20200831142009_FlightTicketNum")]
    partial class FlightTicketNum
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

            modelBuilder.Entity("DBProjekat.Models.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Car1")
                        .IsRequired();

                    b.Property<int>("RentCompanyId");

                    b.HasKey("Id");

                    b.HasIndex("RentCompanyId");

                    b.ToTable("Car");
                });

            modelBuilder.Entity("DBProjekat.Models.Destination", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AirCompanyId");

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

                    b.Property<string>("DestinationFrom")
                        .IsRequired();

                    b.Property<string>("DestinationTo")
                        .IsRequired();

                    b.Property<double>("FlightLength");

                    b.Property<DateTime>("LandingDate");

                    b.Property<int>("NumberOfTickets");

                    b.Property<DateTime>("TakeoffDate");

                    b.Property<DateTime>("TakeoffTime");

                    b.Property<double>("TicketPrice");

                    b.HasKey("Id");

                    b.HasIndex("AirCompanyId");

                    b.ToTable("Flight");
                });

            modelBuilder.Entity("DBProjekat.Models.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Location1")
                        .IsRequired();

                    b.Property<int>("RentCompanyId");

                    b.HasKey("Id");

                    b.HasIndex("RentCompanyId");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("DBProjekat.Models.Rating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AirCompanyId");

                    b.Property<int?>("CarId");

                    b.Property<int?>("FlightId");

                    b.Property<string>("Rating1")
                        .IsRequired();

                    b.Property<int?>("RentCompanyId");

                    b.Property<int?>("TicketId");

                    b.HasKey("Id");

                    b.HasIndex("AirCompanyId");

                    b.HasIndex("CarId");

                    b.HasIndex("FlightId");

                    b.HasIndex("RentCompanyId");

                    b.HasIndex("TicketId");

                    b.ToTable("Rating");
                });

            modelBuilder.Entity("DBProjekat.Models.RentCompany", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired();

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Prices")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("RentCompanies");
                });

            modelBuilder.Entity("DBProjekat.Models.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DestinationFrom")
                        .IsRequired();

                    b.Property<string>("DestinationTo")
                        .IsRequired();

                    b.Property<int?>("FlightId");

                    b.Property<double>("FlightLength");

                    b.Property<DateTime>("LandingDate");

                    b.Property<string>("PassportNum");

                    b.Property<DateTime>("TakeoffDate");

                    b.Property<DateTime>("TakeoffTime");

                    b.Property<double>("TicketPrice");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.HasIndex("FlightId");

                    b.ToTable("Ticket");
                });

            modelBuilder.Entity("DBProjekat.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .IsRequired();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("PassportNumber")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<string>("PhoneNumber")
                        .IsRequired();

                    b.Property<string>("Role")
                        .IsRequired();

                    b.Property<string>("Username")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DBProjekat.Models.Car", b =>
                {
                    b.HasOne("DBProjekat.Models.RentCompany", "RentCompany")
                        .WithMany("Cars")
                        .HasForeignKey("RentCompanyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DBProjekat.Models.Destination", b =>
                {
                    b.HasOne("DBProjekat.Models.AirCompany", "AirCompany")
                        .WithMany("Destinations")
                        .HasForeignKey("AirCompanyId");
                });

            modelBuilder.Entity("DBProjekat.Models.Flight", b =>
                {
                    b.HasOne("DBProjekat.Models.AirCompany", "AirCompany")
                        .WithMany("Flights")
                        .HasForeignKey("AirCompanyId");
                });

            modelBuilder.Entity("DBProjekat.Models.Location", b =>
                {
                    b.HasOne("DBProjekat.Models.RentCompany", "RentCompany")
                        .WithMany("Locations")
                        .HasForeignKey("RentCompanyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DBProjekat.Models.Rating", b =>
                {
                    b.HasOne("DBProjekat.Models.AirCompany", "AirCompany")
                        .WithMany("Ratings")
                        .HasForeignKey("AirCompanyId");

                    b.HasOne("DBProjekat.Models.Car", "Car")
                        .WithMany("Ratings")
                        .HasForeignKey("CarId");

                    b.HasOne("DBProjekat.Models.Flight")
                        .WithMany("Ratings")
                        .HasForeignKey("FlightId");

                    b.HasOne("DBProjekat.Models.RentCompany", "RentCompany")
                        .WithMany()
                        .HasForeignKey("RentCompanyId");

                    b.HasOne("DBProjekat.Models.Ticket")
                        .WithMany("Ratings")
                        .HasForeignKey("TicketId");
                });

            modelBuilder.Entity("DBProjekat.Models.Ticket", b =>
                {
                    b.HasOne("DBProjekat.Models.Flight", "Flight")
                        .WithMany("Tickets")
                        .HasForeignKey("FlightId");
                });
#pragma warning restore 612, 618
        }
    }
}