using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SITechnicalTest.Migrations
{
    /// <inheritdoc />
    public partial class create : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DbSuppliers",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryCode = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    DateCreated = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbSuppliers", x => x.Name);
                });

            migrationBuilder.InsertData(
                table: "DbSuppliers",
                columns: new[] { "Name", "CountryCode", "DateCreated", "Email" },
                values: new object[,]
                {
                    { "Supplier1", "GB", new DateTime(2021, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "supplier1@gmail.com" },
                    { "Supplier2", "JP", new DateTime(2021, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "supplier2@gmail.com" },
                    { "Supplier3", "GB", new DateTime(2021, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "supplier3@gmail.com" },
                    { "Supplier4", "GB", new DateTime(2021, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "supplier4@gmail.com" },
                    { "Supplier5", "JP", new DateTime(2021, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "supplier5@gmail.com" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DbSuppliers");
        }
    }
}
