using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SITechnicalTest.Migrations
{
    /// <inheritdoc />
    public partial class updateDbSupplierCol : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DbSuppliers",
                table: "DbSuppliers");

            migrationBuilder.DeleteData(
                table: "DbSuppliers",
                keyColumn: "Name",
                keyValue: "Supplier1");

            migrationBuilder.DeleteData(
                table: "DbSuppliers",
                keyColumn: "Name",
                keyValue: "Supplier2");

            migrationBuilder.DeleteData(
                table: "DbSuppliers",
                keyColumn: "Name",
                keyValue: "Supplier3");

            migrationBuilder.DeleteData(
                table: "DbSuppliers",
                keyColumn: "Name",
                keyValue: "Supplier4");

            migrationBuilder.DeleteData(
                table: "DbSuppliers",
                keyColumn: "Name",
                keyValue: "Supplier5");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "DbSuppliers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "DbSuppliers",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DbSuppliers",
                table: "DbSuppliers",
                column: "Id");

            migrationBuilder.InsertData(
                table: "DbSuppliers",
                columns: new[] { "Id", "CountryCode", "DateCreated", "Email", "Name" },
                values: new object[,]
                {
                    { 1, "GB", new DateTime(2021, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "supplier1@gmail.com", "Supplier1" },
                    { 2, "JP", new DateTime(2021, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "supplier2@gmail.com", "Supplier2" },
                    { 3, "GB", new DateTime(2021, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "supplier3@gmail.com", "Supplier3" },
                    { 4, "GB", new DateTime(2021, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "supplier4@gmail.com", "Supplier4" },
                    { 5, "JP", new DateTime(2021, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "supplier5@gmail.com", "Supplier5" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DbSuppliers",
                table: "DbSuppliers");

            migrationBuilder.DeleteData(
                table: "DbSuppliers",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DbSuppliers",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DbSuppliers",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "DbSuppliers",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "DbSuppliers",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "Id",
                table: "DbSuppliers");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "DbSuppliers",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DbSuppliers",
                table: "DbSuppliers",
                column: "Name");

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
    }
}
