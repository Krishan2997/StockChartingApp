using Microsoft.EntityFrameworkCore.Migrations;

namespace CompanyAPI.Data.Migrations
{
    public partial class IPOsUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StockExchangeId",
                table: "IPOs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StockExchangeId",
                table: "IPOs");
        }
    }
}
