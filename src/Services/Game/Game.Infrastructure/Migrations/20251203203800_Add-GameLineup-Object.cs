using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Game.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddGameLineupObject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GameLineups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BaseballLineup_Eighth = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BaseballLineup_Fifth = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BaseballLineup_First = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BaseballLineup_Fourth = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BaseballLineup_Ninth = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BaseballLineup_Second = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BaseballLineup_Seventh = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BaseballLineup_Sixth = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BaseballLineup_StartingPitcher = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BaseballLineup_Third = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameLineups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameLineups_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameLineups_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameLineups_GameId",
                table: "GameLineups",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_GameLineups_TeamId",
                table: "GameLineups",
                column: "TeamId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameLineups");
        }
    }
}
