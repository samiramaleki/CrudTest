using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mc2.CrudTest.Persistence.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IndependentCreditNote",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreditNumber = table.Column<int>(type: "int", nullable: false),
                    ExternalCreditNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceStatus = table.Column<int>(type: "int", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndependentCreditNote", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InvoiceNumber = table.Column<int>(type: "int", nullable: false),
                    ExternalInvoiceNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceStatus = table.Column<int>(type: "int", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DependentCreditNotes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreditNumber = table.Column<int>(type: "int", nullable: false),
                    ExternalCreditNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreditStatus = table.Column<int>(type: "int", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InvoiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DependentCreditNotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DependentCreditNotes_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DependentCreditNotes_InvoiceId",
                table: "DependentCreditNotes",
                column: "InvoiceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DependentCreditNotes");

            migrationBuilder.DropTable(
                name: "IndependentCreditNote");

            migrationBuilder.DropTable(
                name: "Invoices");
        }
    }
}
