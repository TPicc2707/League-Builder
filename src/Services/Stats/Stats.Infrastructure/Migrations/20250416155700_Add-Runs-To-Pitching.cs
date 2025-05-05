using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Stats.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddRunsToPitching : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "PitchingStats_EarnedRunAverage",
                table: "BaseballStats",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "PitchingStats_Runs",
                table: "BaseballStats",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PitchingStats_EarnedRunAverage",
                table: "BaseballStats");

            migrationBuilder.DropColumn(
                name: "PitchingStats_Runs",
                table: "BaseballStats");
        }
    }
}
