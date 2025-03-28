using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Stats.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class IncludeNewStatsProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "OffensiveStats_ReceivingYardsPerPlay",
                table: "FootballStats",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "HittingStats_HitByPitch",
                table: "BaseballStats",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HittingStats_SacrificeFly",
                table: "BaseballStats",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HittingStats_HitByPitch",
                table: "BaseballStats");

            migrationBuilder.DropColumn(
                name: "HittingStats_SacrificeFly",
                table: "BaseballStats");

            migrationBuilder.AlterColumn<int>(
                name: "OffensiveStats_ReceivingYardsPerPlay",
                table: "FootballStats",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }
    }
}
