using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class trackFileMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TrackFile",
                table: "Tracks",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TrackFile",
                table: "Tracks");
        }
    }
}
