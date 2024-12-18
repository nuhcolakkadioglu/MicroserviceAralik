﻿// <auto-generated />
using System;
using MicroserviceAralik.Services.Cargo.DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MicroserviceAralik.Services.Cargo.DataAccessLayer.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241212110417_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MicroserviceAralik.Services.Cargo.EntityLayer.Concrete.CargoDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Barcode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<int>("ReceiverCustomerId")
                        .HasColumnType("int");

                    b.Property<int>("SenderCustomerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("ReceiverCustomerId");

                    b.HasIndex("SenderCustomerId");

                    b.ToTable("CargoDetails");
                });

            modelBuilder.Entity("MicroserviceAralik.Services.Cargo.EntityLayer.Concrete.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("MicroserviceAralik.Services.Cargo.EntityLayer.Concrete.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("District")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserCostomerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("MicroserviceAralik.Services.Cargo.EntityLayer.Concrete.Operation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Barcode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("OperationTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Operations");
                });

            modelBuilder.Entity("MicroserviceAralik.Services.Cargo.EntityLayer.Concrete.CargoDetail", b =>
                {
                    b.HasOne("MicroserviceAralik.Services.Cargo.EntityLayer.Concrete.Company", "Company")
                        .WithMany("CargoDetails")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MicroserviceAralik.Services.Cargo.EntityLayer.Concrete.Customer", "ReceiverCustomer")
                        .WithMany("ReceivedCargoDetails")
                        .HasForeignKey("ReceiverCustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MicroserviceAralik.Services.Cargo.EntityLayer.Concrete.Customer", "SenderCustomer")
                        .WithMany("SentCargoDetails")
                        .HasForeignKey("SenderCustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("ReceiverCustomer");

                    b.Navigation("SenderCustomer");
                });

            modelBuilder.Entity("MicroserviceAralik.Services.Cargo.EntityLayer.Concrete.Company", b =>
                {
                    b.Navigation("CargoDetails");
                });

            modelBuilder.Entity("MicroserviceAralik.Services.Cargo.EntityLayer.Concrete.Customer", b =>
                {
                    b.Navigation("ReceivedCargoDetails");

                    b.Navigation("SentCargoDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
