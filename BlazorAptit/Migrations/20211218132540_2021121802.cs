using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorAptit.Migrations
{
    public partial class _2021121802 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Stage_Score",
                table: "AptitUserQue",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Stage_Score",
                table: "AptitUserQue");
        }
    }
}
