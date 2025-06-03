using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Stats.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddFoulsBasketballStats : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Stats_Fouls",
                table: "BasketballStats",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Stats_Fouls",
                table: "BasketballStats");
        }
    }
}
