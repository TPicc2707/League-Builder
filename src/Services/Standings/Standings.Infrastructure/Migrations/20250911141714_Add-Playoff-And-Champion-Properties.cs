using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Standings.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddPlayoffAndChampionProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "StandingsDetail_Champion",
                table: "Standings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "StandingsDetail_PlayoffTeam",
                table: "Standings",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StandingsDetail_Champion",
                table: "Standings");

            migrationBuilder.DropColumn(
                name: "StandingsDetail_PlayoffTeam",
                table: "Standings");
        }
    }
}
