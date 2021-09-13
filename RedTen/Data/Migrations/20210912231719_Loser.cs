using Microsoft.EntityFrameworkCore.Migrations;

namespace RedTen.Data.Migrations
{
    public partial class Loser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Player_Game_GameId",
                table: "Player");

            migrationBuilder.DropForeignKey(
                name: "FK_Player_Game_GameId1",
                table: "Player");

            migrationBuilder.DropForeignKey(
                name: "FK_Player_Game_GameId2",
                table: "Player");

            migrationBuilder.DropIndex(
                name: "IX_Player_GameId",
                table: "Player");

            migrationBuilder.DropIndex(
                name: "IX_Player_GameId1",
                table: "Player");

            migrationBuilder.DropIndex(
                name: "IX_Player_GameId2",
                table: "Player");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "Player");

            migrationBuilder.DropColumn(
                name: "GameId1",
                table: "Player");

            migrationBuilder.DropColumn(
                name: "GameId2",
                table: "Player");

            migrationBuilder.CreateTable(
                name: "PlayerGame",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    GameId = table.Column<int>(type: "int", nullable: false),
                    Loser = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerGame", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerGame");

            migrationBuilder.AddColumn<int>(
                name: "GameId",
                table: "Player",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GameId1",
                table: "Player",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GameId2",
                table: "Player",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Player_GameId",
                table: "Player",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Player_GameId1",
                table: "Player",
                column: "GameId1");

            migrationBuilder.CreateIndex(
                name: "IX_Player_GameId2",
                table: "Player",
                column: "GameId2");

            migrationBuilder.AddForeignKey(
                name: "FK_Player_Game_GameId",
                table: "Player",
                column: "GameId",
                principalTable: "Game",
                principalColumn: "GameId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Player_Game_GameId1",
                table: "Player",
                column: "GameId1",
                principalTable: "Game",
                principalColumn: "GameId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Player_Game_GameId2",
                table: "Player",
                column: "GameId2",
                principalTable: "Game",
                principalColumn: "GameId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
