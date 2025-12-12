using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Team.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddTeamManager : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TeamManager_EmailAddress",
                table: "Teams",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TeamManager_FirstName",
                table: "Teams",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TeamManager_LastName",
                table: "Teams",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TeamManager_EmailAddress",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "TeamManager_FirstName",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "TeamManager_LastName",
                table: "Teams");
        }
    }
}
