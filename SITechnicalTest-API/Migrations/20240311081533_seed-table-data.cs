﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SITechnicalTest_API.Migrations
{
    /// <inheritdoc />
    public partial class seedtabledata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryCode = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    DateCreated = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Quotations",
                columns: table => new
                {
                    QuotationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierId = table.Column<int>(type: "int", nullable: false),
                    Product = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CostPerUnit = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quotations", x => x.QuotationId);
                    table.ForeignKey(
                        name: "FK_Quotations_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "Id", "CountryCode", "DateCreated", "Email", "Name" },
                values: new object[,]
                {
                    { 1, "GB", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "supplier1@gmail.com", "Supplier1" },
                    { 2, "JP", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "supplier2@gmail.com", "Supplier2" },
                    { 3, "GB", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "supplier3@gmail.com", "Supplier3" },
                    { 4, "GB", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "supplier4@gmail.com", "Supplier4" },
                    { 5, "JP", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "supplier5@gmail.com", "Supplier5" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Quotations_SupplierId",
                table: "Quotations",
                column: "SupplierId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Quotations");

            migrationBuilder.DropTable(
                name: "Suppliers");
        }
    }
}
