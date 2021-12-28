﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NorthWind.EFCore.DataContexts.Migrations
{
    public partial class AgregarClientesYProductos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nchar(5)", fixedLength: true, maxLength: 5, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    CurrentBalance = table.Column<decimal>(type: "decimal(8,2)", precision: 8, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    UnitsInStock = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(8,2)", precision: 8, scale: 2, nullable: false),
                    Discontinued = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "CurrentBalance", "Name" },
                values: new object[,]
                {
                    { "ALFKI", 0m, "Alfreds Futterkiste" },
                    { "ANATR", 0m, "Ana Trujillo Emparedados y helados" },
                    { "ANTON", 100m, "Antonio Moreno Taquería" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Discontinued", "Name", "UnitPrice", "UnitsInStock" },
                values: new object[,]
                {
                    { 1, false, "Chai", 35m, 20 },
                    { 2, false, "Chang", 55m, 0 },
                    { 3, true, "Aniseed Syrup", 65m, 20 },
                    { 4, false, "Chef Anton's Cajun Seasoning", 75m, 40 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
