using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Stats.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class deletecalculatedproperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KickingStats_ExtraPointPercentage",
                table: "FootballStats");

            migrationBuilder.DropColumn(
                name: "KickingStats_FieldGoalPercentage",
                table: "FootballStats");

            migrationBuilder.DropColumn(
                name: "OffensiveStats_PasserRating",
                table: "FootballStats");

            migrationBuilder.DropColumn(
                name: "OffensiveStats_PassingCompletionPercentage",
                table: "FootballStats");

            migrationBuilder.DropColumn(
                name: "OffensiveStats_PassingYardsPerPlay",
                table: "FootballStats");

            migrationBuilder.DropColumn(
                name: "OffensiveStats_ReceivingYardsPerPlay",
                table: "FootballStats");

            migrationBuilder.DropColumn(
                name: "OffensiveStats_RushingYardsAverage",
                table: "FootballStats");

            migrationBuilder.DropColumn(
                name: "Stats_FieldGoalPercentage",
                table: "BasketballStats");

            migrationBuilder.DropColumn(
                name: "Stats_FreeThrowPercentage",
                table: "BasketballStats");

            migrationBuilder.DropColumn(
                name: "Stats_ThreePointPercentage",
                table: "BasketballStats");

            migrationBuilder.DropColumn(
                name: "HittingStats_Average",
                table: "BaseballStats");

            migrationBuilder.DropColumn(
                name: "HittingStats_OnBasePercentage",
                table: "BaseballStats");

            migrationBuilder.DropColumn(
                name: "HittingStats_OnBasePlusSlugging",
                table: "BaseballStats");

            migrationBuilder.DropColumn(
                name: "HittingStats_Slugging",
                table: "BaseballStats");

            migrationBuilder.DropColumn(
                name: "PitchingStats_EarnedRunAverage",
                table: "BaseballStats");

            migrationBuilder.DropColumn(
                name: "PitchingStats_WalksHitsPerInning",
                table: "BaseballStats");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "KickingStats_ExtraPointPercentage",
                table: "FootballStats",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "KickingStats_FieldGoalPercentage",
                table: "FootballStats",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "OffensiveStats_PasserRating",
                table: "FootballStats",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "OffensiveStats_PassingCompletionPercentage",
                table: "FootballStats",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "OffensiveStats_PassingYardsPerPlay",
                table: "FootballStats",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "OffensiveStats_ReceivingYardsPerPlay",
                table: "FootballStats",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "OffensiveStats_RushingYardsAverage",
                table: "FootballStats",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Stats_FieldGoalPercentage",
                table: "BasketballStats",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Stats_FreeThrowPercentage",
                table: "BasketballStats",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Stats_ThreePointPercentage",
                table: "BasketballStats",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "HittingStats_Average",
                table: "BaseballStats",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "HittingStats_OnBasePercentage",
                table: "BaseballStats",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "HittingStats_OnBasePlusSlugging",
                table: "BaseballStats",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "HittingStats_Slugging",
                table: "BaseballStats",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PitchingStats_EarnedRunAverage",
                table: "BaseballStats",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PitchingStats_WalksHitsPerInning",
                table: "BaseballStats",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
