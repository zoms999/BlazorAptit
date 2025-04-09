using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorAptit.Migrations
{
    public partial class _20210418 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AptitGroup",
                columns: table => new
                {
                    Group_ID = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Group_Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Group_City = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CheckType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    RegCount = table.Column<int>(type: "int", nullable: false),
                    CompletCount = table.Column<int>(type: "int", nullable: false),
                    PaymentCount = table.Column<int>(type: "int", nullable: false),
                    Manage_Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Manage_Tel1 = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Manage_Tel2 = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Payment = table.Column<int>(type: "int", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PaymentComplet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AptitGroup", x => x.Group_ID);
                });

            migrationBuilder.CreateTable(
                name: "AptitQuestion",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QUE_1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QUE_2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QUE_3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QUE_4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QUE_5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QUE_6 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QUE_7 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QUE_8 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QUE_9 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QUE_10 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QUE_11 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QUE_12 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QUE_13 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QUE_14 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QUE_15 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QUE_16 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QUE_17 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QUE_18 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QUE_19 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QUE_20 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AptitQuestion", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AptitReply",
                columns: table => new
                {
                    AptitReplyID = table.Column<int>(type: "int", nullable: false),
                    Point = table.Column<int>(type: "int", nullable: false),
                    TITLE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TITLE_ENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TAG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CONTENT_MAIN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DEPART1_L = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DEPART1_R = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DEPART2_L = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DEPART2_R = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DEPART3_L = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DEPART3_R = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DEPART4_L = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DEPART4_R = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DEPART5_L = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DEPART5_R = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DEPART6_L = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DEPART6_R = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DEPART7_L = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DEPART7_R = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JOB1_L = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JOB1_R = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JOB2_L = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JOB2_R = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JOB3_L = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JOB3_R = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JOB4_L = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JOB4_R = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JOB5_L = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JOB5_R = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JOB6_L = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JOB6_R = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JOB7_L = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JOB7_R = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JOB8_L = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JOB8_R = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    POSITION1_L = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    POSITION1_C = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    POSITION1_R = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    POSITION2_L = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    POSITION2_C = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    POSITION2_R = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    POSITION3_L = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    POSITION3_C = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    POSITION3_R = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    POSITION4_L = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    POSITION4_C = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    POSITION4_R = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    POSITION5_L = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    POSITION5_C = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    POSITION5_R = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    POSITION6_L = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    POSITION6_C = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    POSITION6_R = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    STUDY_STYLE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    STUDY_WAY = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "AptitResult",
                columns: table => new
                {
                    AptitResultID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Point = table.Column<int>(type: "int", nullable: false),
                    TITLE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CONTENT_MAIN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CONTENT_1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CONTENT_1_1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CONTENT_2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CONTENT_2_1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CONTENT_3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CONTENT_3_1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CONTENT_4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CONTENT_4_1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CONTENT_5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CONTENT_5_1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CONTENT_6 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CONTENT_6_1 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AptitResult", x => x.AptitResultID);
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    CourseID = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Credits = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.CourseID);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstMidName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnrollmentDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AptitUser",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Group_ID = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    Group_City = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Group_Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    User_Password = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    User_Password2 = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    User_Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    User_Age = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    User_Gender = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    User_Edu = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    User_Grade = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    User_Finish = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AptitUser", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AptitUser_AptitGroup_Group_ID",
                        column: x => x.Group_ID,
                        principalTable: "AptitGroup",
                        principalColumn: "Group_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Enrollment",
                columns: table => new
                {
                    EnrollmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseID = table.Column<int>(type: "int", nullable: false),
                    StudentID = table.Column<int>(type: "int", nullable: false),
                    Grade = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollment", x => x.EnrollmentID);
                    table.ForeignKey(
                        name: "FK_Enrollment_Course_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Course",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrollment_Student_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Student",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AptitAnswer",
                columns: table => new
                {
                    AptitAnswerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AptitUserID = table.Column<int>(type: "int", nullable: false),
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
                    Stage = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AptitUserID1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AptitAnswer", x => x.AptitAnswerID);
                    table.ForeignKey(
                        name: "FK_AptitAnswer_AptitUser_AptitUserID",
                        column: x => x.AptitUserID,
                        principalTable: "AptitUser",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AptitAnswer_AptitUser_AptitUserID1",
                        column: x => x.AptitUserID1,
                        principalTable: "AptitUser",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AptitAnswer_AptitUserID",
                table: "AptitAnswer",
                column: "AptitUserID");

            migrationBuilder.CreateIndex(
                name: "IX_AptitAnswer_AptitUserID1",
                table: "AptitAnswer",
                column: "AptitUserID1",
                unique: true,
                filter: "[AptitUserID1] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AptitUser_Group_ID",
                table: "AptitUser",
                column: "Group_ID");

            migrationBuilder.CreateIndex(
                name: "IX_AptitUser_User_Email",
                table: "AptitUser",
                column: "User_Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Enrollment_CourseID",
                table: "Enrollment",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollment_StudentID",
                table: "Enrollment",
                column: "StudentID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AptitAnswer");

            migrationBuilder.DropTable(
                name: "AptitQuestion");

            migrationBuilder.DropTable(
                name: "AptitReply");

            migrationBuilder.DropTable(
                name: "AptitResult");

            migrationBuilder.DropTable(
                name: "Enrollment");

            migrationBuilder.DropTable(
                name: "AptitUser");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "AptitGroup");
        }
    }
}
