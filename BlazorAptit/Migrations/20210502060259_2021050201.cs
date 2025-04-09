using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorAptit.Migrations
{
    public partial class _2021050201 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "agree11",
                table: "AptitUser",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "agree11",
                table: "AptitUser");
        }
    }
}
