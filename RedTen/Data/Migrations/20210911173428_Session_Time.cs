using Microsoft.EntityFrameworkCore.Migrations;

namespace RedTen.Data.Migrations
{
    public partial class Session_Time : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "playedAt",
                table: "Game",
                newName: "Session_Time");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Session_Time",
                table: "Game",
                newName: "playedAt");
        }
    }
}
