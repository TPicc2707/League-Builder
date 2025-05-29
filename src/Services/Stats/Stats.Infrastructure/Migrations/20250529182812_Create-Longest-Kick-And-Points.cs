using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Stats.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateLongestKickAndPoints : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KickingStats_LongestKick",
                table: "FootballStats",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "KickingStats_Points",
                table: "FootballStats",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KickingStats_LongestKick",
                table: "FootballStats");

            migrationBuilder.DropColumn(
                name: "KickingStats_Points",
                table: "FootballStats");
        }
    }
}
