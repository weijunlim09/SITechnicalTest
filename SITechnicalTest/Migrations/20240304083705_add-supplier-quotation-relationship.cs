using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SITechnicalTest.Migrations
{
    /// <inheritdoc />
    public partial class addsupplierquotationrelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DbSuppliers",
                table: "DbSuppliers");

            migrationBuilder.RenameTable(
                name: "DbSuppliers",
                newName: "Suppliers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Suppliers",
                table: "Suppliers",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Quotations",
                columns: table => new
                {
                    QuotationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierId = table.Column<int>(type: "int", nullable: false),
                    Product = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CostPerUnit = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
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

            migrationBuilder.DropPrimaryKey(
                name: "PK_Suppliers",
                table: "Suppliers");

            migrationBuilder.RenameTable(
                name: "Suppliers",
                newName: "DbSuppliers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DbSuppliers",
                table: "DbSuppliers",
                column: "Id");
        }
    }
}
