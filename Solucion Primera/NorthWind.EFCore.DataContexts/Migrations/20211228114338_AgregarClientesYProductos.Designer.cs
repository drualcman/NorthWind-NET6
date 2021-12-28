﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NorthWind.EFCore.DataContexts;

#nullable disable

namespace NorthWind.EFCore.DataContexts.Migrations
{
    [DbContext(typeof(NorthWindContext))]
    [Migration("20211228114338_AgregarClientesYProductos")]
    partial class AgregarClientesYProductos
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("NorthWind.EFCore.DataContexts.POCOEntities.Customer", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(5)
                        .HasColumnType("nchar(5)")
                        .IsFixedLength();

                    b.Property<decimal>("CurrentBalance")
                        .HasPrecision(8, 2)
                        .HasColumnType("decimal(8,2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = "ALFKI",
                            CurrentBalance = 0m,
                            Name = "Alfreds Futterkiste"
                        },
                        new
                        {
                            Id = "ANATR",
                            CurrentBalance = 0m,
                            Name = "Ana Trujillo Emparedados y helados"
                        },
                        new
                        {
                            Id = "ANTON",
                            CurrentBalance = 100m,
                            Name = "Antonio Moreno Taquería"
                        });
                });

            modelBuilder.Entity("NorthWind.EFCore.DataContexts.POCOEntities.OrderDetail", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<short>("Quantity")
                        .HasColumnType("smallint");

                    b.Property<decimal>("UnitPrice")
                        .HasPrecision(8, 2)
                        .HasColumnType("decimal(8,2)");

                    b.HasKey("OrderId", "ProductId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("NorthWind.EFCore.DataContexts.POCOEntities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Discontinued")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<decimal>("UnitPrice")
                        .HasPrecision(8, 2)
                        .HasColumnType("decimal(8,2)");

                    b.Property<int>("UnitsInStock")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Discontinued = false,
                            Name = "Chai",
                            UnitPrice = 35m,
                            UnitsInStock = 20
                        },
                        new
                        {
                            Id = 2,
                            Discontinued = false,
                            Name = "Chang",
                            UnitPrice = 55m,
                            UnitsInStock = 0
                        },
                        new
                        {
                            Id = 3,
                            Discontinued = true,
                            Name = "Aniseed Syrup",
                            UnitPrice = 65m,
                            UnitsInStock = 20
                        },
                        new
                        {
                            Id = 4,
                            Discontinued = false,
                            Name = "Chef Anton's Cajun Seasoning",
                            UnitPrice = 75m,
                            UnitsInStock = 40
                        });
                });

            modelBuilder.Entity("NorthWind.Entities.POCOEntities.Log", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Logs");
                });

            modelBuilder.Entity("NorthWind.Sales.Entities.POCOEntities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CustomerId")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nchar(5)")
                        .IsFixedLength();

                    b.Property<double>("Discount")
                        .HasColumnType("float");

                    b.Property<int>("DiscountType")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ShipAddress")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("ShipCity")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("ShipCountry")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("ShipPostalCode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("ShippingType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("NorthWind.EFCore.DataContexts.POCOEntities.OrderDetail", b =>
                {
                    b.HasOne("NorthWind.Sales.Entities.POCOEntities.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });
#pragma warning restore 612, 618
        }
    }
}
