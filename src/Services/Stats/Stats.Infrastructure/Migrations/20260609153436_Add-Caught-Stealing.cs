using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Stats.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddCaughtStealing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HittingStats_CaughtStealing",
                table: "BaseballStats",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HittingStats_CaughtStealing",
                table: "BaseballStats");
        }
    }
}
