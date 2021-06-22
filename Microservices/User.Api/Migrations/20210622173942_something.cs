using Microsoft.EntityFrameworkCore.Migrations;

namespace User.Api.Migrations
{
    public partial class something : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "LoggedInUsers",
                newName: "UserName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "LoggedInUsers",
                newName: "UserID");
        }
    }
}
