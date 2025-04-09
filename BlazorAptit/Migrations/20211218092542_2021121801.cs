using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorAptit.Migrations
{
    public partial class _2021121801 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AptitUserQue",
                columns: table => new
                {
                    AptitUserID = table.Column<int>(type: "int", nullable: false),
                    AptitQuestionID = table.Column<int>(type: "int", nullable: false),
                    AQ_1 = table.Column<int>(type: "int", nullable: false),
                    AQ_2 = table.Column<int>(type: "int", nullable: false),
                    AQ_3 = table.Column<int>(type: "int", nullable: false),
                    AQ_4 = table.Column<int>(type: "int", nullable: false),
                    AQ_5 = table.Column<int>(type: "int", nullable: false),
                    AQ_6 = table.Column<int>(type: "int", nullable: false),
                    AQ_7 = table.Column<int>(type: "int", nullable: false),
                    AQ_8 = table.Column<int>(type: "int", nullable: false),
                    AQ_9 = table.Column<int>(type: "int", nullable: false),
                    AQ_10 = table.Column<int>(type: "int", nullable: false),
                    AQ_11 = table.Column<int>(type: "int", nullable: false),
                    AQ_12 = table.Column<int>(type: "int", nullable: false),
                    AQ_13 = table.Column<int>(type: "int", nullable: false),
                    AQ_14 = table.Column<int>(type: "int", nullable: false),
                    AQ_15 = table.Column<int>(type: "int", nullable: false),
                    AQ_16 = table.Column<int>(type: "int", nullable: false),
                    AQ_17 = table.Column<int>(type: "int", nullable: false),
                    AQ_18 = table.Column<int>(type: "int", nullable: false),
                    AQ_19 = table.Column<int>(type: "int", nullable: false),
                    AQ_20 = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AptitUserQue", x => new { x.AptitUserID, x.AptitQuestionID });
                    table.ForeignKey(
                        name: "FK_AptitUserQue_AptitUser_AptitUserID",
                        column: x => x.AptitUserID,
                        principalTable: "AptitUser",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AptitUserQue");
        }
    }
}
