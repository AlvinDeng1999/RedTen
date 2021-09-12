using Microsoft.EntityFrameworkCore.Migrations;

namespace RedTen.Data.Migrations
{
    public partial class palyergame : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Player_Game_Gameid",
                table: "Player");

            migrationBuilder.DropForeignKey(
                name: "FK_Player_Game_Gameid1",
                table: "Player");

            migrationBuilder.DropForeignKey(
                name: "FK_Player_Game_Gameid2",
                table: "Player");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Player",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Player",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "Gameid2",
                table: "Player",
                newName: "GameId2");

            migrationBuilder.RenameColumn(
                name: "Gameid1",
                table: "Player",
                newName: "GameId1");

            migrationBuilder.RenameColumn(
                name: "Gameid",
                table: "Player",
                newName: "GameId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Player",
                newName: "PlayerId");

            migrationBuilder.RenameIndex(
                name: "IX_Player_Gameid2",
                table: "Player",
                newName: "IX_Player_GameId2");

            migrationBuilder.RenameIndex(
                name: "IX_Player_Gameid1",
                table: "Player",
                newName: "IX_Player_GameId1");

            migrationBuilder.RenameIndex(
                name: "IX_Player_Gameid",
                table: "Player",
                newName: "IX_Player_GameId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Game",
                newName: "GameId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Player",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "GameId2",
                table: "Player",
                newName: "Gameid2");

            migrationBuilder.RenameColumn(
                name: "GameId1",
                table: "Player",
                newName: "Gameid1");

            migrationBuilder.RenameColumn(
                name: "GameId",
                table: "Player",
                newName: "Gameid");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Player",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "PlayerId",
                table: "Player",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Player_GameId2",
                table: "Player",
                newName: "IX_Player_Gameid2");

            migrationBuilder.RenameIndex(
                name: "IX_Player_GameId1",
                table: "Player",
                newName: "IX_Player_Gameid1");

            migrationBuilder.RenameIndex(
                name: "IX_Player_GameId",
                table: "Player",
                newName: "IX_Player_Gameid");

            migrationBuilder.RenameColumn(
                name: "GameId",
                table: "Game",
                newName: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Player_Game_Gameid",
                table: "Player",
                column: "Gameid",
                principalTable: "Game",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Player_Game_Gameid1",
                table: "Player",
                column: "Gameid1",
                principalTable: "Game",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Player_Game_Gameid2",
                table: "Player",
                column: "Gameid2",
                principalTable: "Game",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
