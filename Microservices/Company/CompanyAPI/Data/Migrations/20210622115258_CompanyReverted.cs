using Microsoft.EntityFrameworkCore.Migrations;

namespace CompanyAPI.Data.Migrations
{
    public partial class CompanyReverted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_IPOs_CompanyId",
                table: "IPOs");

            migrationBuilder.CreateIndex(
                name: "IX_IPOs_CompanyId",
                table: "IPOs",
                column: "CompanyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_IPOs_CompanyId",
                table: "IPOs");

            migrationBuilder.CreateIndex(
                name: "IX_IPOs_CompanyId",
                table: "IPOs",
                column: "CompanyId",
                unique: true);
        }
    }
}
