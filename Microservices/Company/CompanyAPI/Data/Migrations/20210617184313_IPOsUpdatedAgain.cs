using Microsoft.EntityFrameworkCore.Migrations;

namespace CompanyAPI.Data.Migrations
{
    public partial class IPOsUpdatedAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockExchanges_IPOs_IPOsId",
                table: "StockExchanges");

            migrationBuilder.DropColumn(
                name: "StockExchangeId",
                table: "IPOs");

            migrationBuilder.AlterColumn<int>(
                name: "IPOsId",
                table: "StockExchanges",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_StockExchanges_IPOs_IPOsId",
                table: "StockExchanges",
                column: "IPOsId",
                principalTable: "IPOs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockExchanges_IPOs_IPOsId",
                table: "StockExchanges");

            migrationBuilder.AlterColumn<int>(
                name: "IPOsId",
                table: "StockExchanges",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "StockExchangeId",
                table: "IPOs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_StockExchanges_IPOs_IPOsId",
                table: "StockExchanges",
                column: "IPOsId",
                principalTable: "IPOs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
