using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Standings.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddTies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StandingsDetail_Ties",
                table: "Standings",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StandingsDetail_Ties",
                table: "Standings");
        }
    }
}
