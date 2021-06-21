using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CompanyAPI.Data.Migrations
{
    public partial class IPOsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CEO",
                table: "Companies",
                newName: "Ceo");

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Line1 = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Line2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IPOs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    PricePerShare = table.Column<long>(type: "bigint", nullable: false),
                    TotalNumberOfShares = table.Column<long>(type: "bigint", nullable: false),
                    OpenDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IPOs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IPOs_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StockExchanges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StockExchangeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Brief = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactAddressId = table.Column<int>(type: "int", nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IPOsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockExchanges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StockExchanges_Address_ContactAddressId",
                        column: x => x.ContactAddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StockExchanges_IPOs_IPOsId",
                        column: x => x.IPOsId,
                        principalTable: "IPOs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IPOs_CompanyId",
                table: "IPOs",
                column: "CompanyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StockExchanges_ContactAddressId",
                table: "StockExchanges",
                column: "ContactAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_StockExchanges_IPOsId",
                table: "StockExchanges",
                column: "IPOsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StockExchanges");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "IPOs");

            migrationBuilder.RenameColumn(
                name: "Ceo",
                table: "Companies",
                newName: "CEO");
        }
    }
}
