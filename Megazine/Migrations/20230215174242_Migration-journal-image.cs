using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Megazine.Migrations
{
    public partial class Migrationjournalimage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "JournalImage",
                table: "Journals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JournalImage",
                table: "Journals");
        }
    }
}
