using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Stats.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Leagues",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leagues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Seasons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seasons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TeamName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BaseballStats",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LeagueId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SeasonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HittingStats_AtBats = table.Column<int>(type: "int", nullable: false),
                    HittingStats_Average = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HittingStats_Doubles = table.Column<int>(type: "int", nullable: false),
                    HittingStats_Hits = table.Column<int>(type: "int", nullable: false),
                    HittingStats_HomeRuns = table.Column<int>(type: "int", nullable: false),
                    HittingStats_OnBasePercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HittingStats_OnBasePlusSlugging = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HittingStats_Runs = table.Column<int>(type: "int", nullable: false),
                    HittingStats_RunsBattedIn = table.Column<int>(type: "int", nullable: false),
                    HittingStats_Slugging = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HittingStats_StolenBases = table.Column<int>(type: "int", nullable: false),
                    HittingStats_Strikeouts = table.Column<int>(type: "int", nullable: false),
                    HittingStats_TotalBases = table.Column<int>(type: "int", nullable: false),
                    HittingStats_Triples = table.Column<int>(type: "int", nullable: false),
                    HittingStats_Walks = table.Column<int>(type: "int", nullable: false),
                    PitchingStats_HitsAllowed = table.Column<int>(type: "int", nullable: false),
                    PitchingStats_Innings = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PitchingStats_Losses = table.Column<int>(type: "int", nullable: false),
                    PitchingStats_PitchingStrikeouts = table.Column<int>(type: "int", nullable: false),
                    PitchingStats_Saves = table.Column<int>(type: "int", nullable: false),
                    PitchingStats_Start = table.Column<bool>(type: "bit", nullable: false),
                    PitchingStats_WalksAllowed = table.Column<int>(type: "int", nullable: false),
                    PitchingStats_WalksHitsPerInning = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PitchingStats_Wins = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseballStats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BaseballStats_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BaseballStats_Leagues_LeagueId",
                        column: x => x.LeagueId,
                        principalTable: "Leagues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BaseballStats_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BaseballStats_Seasons_SeasonId",
                        column: x => x.SeasonId,
                        principalTable: "Seasons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BaseballStats_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BasketballStats",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LeagueId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SeasonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Stats_Assists = table.Column<int>(type: "int", nullable: false),
                    Stats_Blocks = table.Column<int>(type: "int", nullable: false),
                    Stats_FieldGoalPercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Stats_FieldGoalsAttempted = table.Column<int>(type: "int", nullable: false),
                    Stats_FieldGoalsMade = table.Column<int>(type: "int", nullable: false),
                    Stats_FreeThrowPercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Stats_FreeThrowsAttempted = table.Column<int>(type: "int", nullable: false),
                    Stats_FreeThrowsMade = table.Column<int>(type: "int", nullable: false),
                    Stats_Minutes = table.Column<int>(type: "int", nullable: false),
                    Stats_Points = table.Column<int>(type: "int", nullable: false),
                    Stats_Rebounds = table.Column<int>(type: "int", nullable: false),
                    Stats_Start = table.Column<bool>(type: "bit", nullable: false),
                    Stats_Steals = table.Column<int>(type: "int", nullable: false),
                    Stats_ThreePointPercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Stats_ThreePointersAttempted = table.Column<int>(type: "int", nullable: false),
                    Stats_ThreePointersMade = table.Column<int>(type: "int", nullable: false),
                    Stats_Turnovers = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasketballStats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BasketballStats_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BasketballStats_Leagues_LeagueId",
                        column: x => x.LeagueId,
                        principalTable: "Leagues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BasketballStats_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BasketballStats_Seasons_SeasonId",
                        column: x => x.SeasonId,
                        principalTable: "Seasons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BasketballStats_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FootballStats",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LeagueId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SeasonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DefensiveStats_DefensiveInterceptionYards = table.Column<int>(type: "int", nullable: false),
                    DefensiveStats_DefensiveInterceptions = table.Column<int>(type: "int", nullable: false),
                    DefensiveStats_DefensiveTouchdowns = table.Column<int>(type: "int", nullable: false),
                    DefensiveStats_ForcedFumbles = table.Column<int>(type: "int", nullable: false),
                    DefensiveStats_LongestDefensiveInterceptionPlay = table.Column<int>(type: "int", nullable: false),
                    DefensiveStats_PassesDefended = table.Column<int>(type: "int", nullable: false),
                    DefensiveStats_RecoveredFumbles = table.Column<int>(type: "int", nullable: false),
                    DefensiveStats_Sacks = table.Column<int>(type: "int", nullable: false),
                    DefensiveStats_Tackles = table.Column<int>(type: "int", nullable: false),
                    DefensiveStats_TacklesForLoss = table.Column<int>(type: "int", nullable: false),
                    KickingStats_ExtraPointPercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    KickingStats_ExtraPointsAttempted = table.Column<int>(type: "int", nullable: false),
                    KickingStats_ExtraPointsMade = table.Column<int>(type: "int", nullable: false),
                    KickingStats_FieldGoalPercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    KickingStats_FieldGoalsAttempted = table.Column<int>(type: "int", nullable: false),
                    KickingStats_FieldGoalsMade = table.Column<int>(type: "int", nullable: false),
                    KickingStats_LongestPunt = table.Column<int>(type: "int", nullable: false),
                    KickingStats_PuntingYards = table.Column<int>(type: "int", nullable: false),
                    KickingStats_Punts = table.Column<int>(type: "int", nullable: false),
                    OffensiveStats_LongestPassingPlay = table.Column<int>(type: "int", nullable: false),
                    OffensiveStats_LongestRushingPlay = table.Column<int>(type: "int", nullable: false),
                    OffensiveStats_PasserRating = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OffensiveStats_PassingAttempts = table.Column<int>(type: "int", nullable: false),
                    OffensiveStats_PassingCompletionPercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OffensiveStats_PassingCompletions = table.Column<int>(type: "int", nullable: false),
                    OffensiveStats_PassingInterceptions = table.Column<int>(type: "int", nullable: false),
                    OffensiveStats_PassingTouchdowns = table.Column<int>(type: "int", nullable: false),
                    OffensiveStats_PassingYards = table.Column<int>(type: "int", nullable: false),
                    OffensiveStats_PassingYardsPerPlay = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OffensiveStats_ReceivingFumbles = table.Column<int>(type: "int", nullable: false),
                    OffensiveStats_ReceivingFumblesLost = table.Column<int>(type: "int", nullable: false),
                    OffensiveStats_ReceivingTouchdowns = table.Column<int>(type: "int", nullable: false),
                    OffensiveStats_ReceivingYards = table.Column<int>(type: "int", nullable: false),
                    OffensiveStats_ReceivingYardsPerPlay = table.Column<int>(type: "int", nullable: false),
                    OffensiveStats_Receptions = table.Column<int>(type: "int", nullable: false),
                    OffensiveStats_RushingAttempts = table.Column<int>(type: "int", nullable: false),
                    OffensiveStats_RushingFumbles = table.Column<int>(type: "int", nullable: false),
                    OffensiveStats_RushingFumblesLost = table.Column<int>(type: "int", nullable: false),
                    OffensiveStats_RushingTouchdowns = table.Column<int>(type: "int", nullable: false),
                    OffensiveStats_RushingYards = table.Column<int>(type: "int", nullable: false),
                    OffensiveStats_RushingYardsAverage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OffensiveStats_Sacks = table.Column<int>(type: "int", nullable: false),
                    OffensiveStats_Targets = table.Column<int>(type: "int", nullable: false),
                    OffensiveStats_YardsAfterCatch = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FootballStats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FootballStats_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FootballStats_Leagues_LeagueId",
                        column: x => x.LeagueId,
                        principalTable: "Leagues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FootballStats_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FootballStats_Seasons_SeasonId",
                        column: x => x.SeasonId,
                        principalTable: "Seasons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FootballStats_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BaseballStats_GameId",
                table: "BaseballStats",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseballStats_LeagueId",
                table: "BaseballStats",
                column: "LeagueId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseballStats_PlayerId",
                table: "BaseballStats",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseballStats_SeasonId",
                table: "BaseballStats",
                column: "SeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseballStats_TeamId",
                table: "BaseballStats",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_BasketballStats_GameId",
                table: "BasketballStats",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_BasketballStats_LeagueId",
                table: "BasketballStats",
                column: "LeagueId");

            migrationBuilder.CreateIndex(
                name: "IX_BasketballStats_PlayerId",
                table: "BasketballStats",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_BasketballStats_SeasonId",
                table: "BasketballStats",
                column: "SeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_BasketballStats_TeamId",
                table: "BasketballStats",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_FootballStats_GameId",
                table: "FootballStats",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_FootballStats_LeagueId",
                table: "FootballStats",
                column: "LeagueId");

            migrationBuilder.CreateIndex(
                name: "IX_FootballStats_PlayerId",
                table: "FootballStats",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_FootballStats_SeasonId",
                table: "FootballStats",
                column: "SeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_FootballStats_TeamId",
                table: "FootballStats",
                column: "TeamId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BaseballStats");

            migrationBuilder.DropTable(
                name: "BasketballStats");

            migrationBuilder.DropTable(
                name: "FootballStats");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Leagues");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Seasons");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
