using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RedTen.Data.Migrations
{
    public partial class Game : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Game",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    playedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Game", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Player",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gameid = table.Column<int>(type: "int", nullable: true),
                    Gameid1 = table.Column<int>(type: "int", nullable: true),
                    Gameid2 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.id);
                    table.ForeignKey(
                        name: "FK_Player_Game_Gameid",
                        column: x => x.Gameid,
                        principalTable: "Game",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Player_Game_Gameid1",
                        column: x => x.Gameid1,
                        principalTable: "Game",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Player_Game_Gameid2",
                        column: x => x.Gameid2,
                        principalTable: "Game",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Player_Gameid",
                table: "Player",
                column: "Gameid");

            migrationBuilder.CreateIndex(
                name: "IX_Player_Gameid1",
                table: "Player",
                column: "Gameid1");

            migrationBuilder.CreateIndex(
                name: "IX_Player_Gameid2",
                table: "Player",
                column: "Gameid2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Player");

            migrationBuilder.DropTable(
                name: "Game");
        }
    }
}
