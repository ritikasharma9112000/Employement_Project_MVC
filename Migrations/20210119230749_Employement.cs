using System;
using System.IO;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Employement_Project_MVC.Migrations
{
    public partial class Employement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Candidate_Detail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name_of_candidate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DOB_of_candidate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mobile_no_of_candidate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email_address_of_candidate = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidate_Detail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employer_Detail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Employer_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date_of_establishment = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address_of_employer = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employer_Detail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Job_Detail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Job_role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Job_type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Job_salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Job_description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Employer_DetailId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Job_Detail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Job_Detail_Employer_Detail_Employer_DetailId",
                        column: x => x.Employer_DetailId,
                        principalTable: "Employer_Detail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Apply_Job_Detail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Candidate_DetailId = table.Column<int>(type: "int", nullable: false),
                    Job_DetailId = table.Column<int>(type: "int", nullable: false),
                    Candidate_availabilities = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Candidate_notice_period = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apply_Job_Detail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Apply_Job_Detail_Candidate_Detail_Candidate_DetailId",
                        column: x => x.Candidate_DetailId,
                        principalTable: "Candidate_Detail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Apply_Job_Detail_Job_Detail_Job_DetailId",
                        column: x => x.Job_DetailId,
                        principalTable: "Job_Detail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Apply_Job_Detail_Candidate_DetailId",
                table: "Apply_Job_Detail",
                column: "Candidate_DetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Apply_Job_Detail_Job_DetailId",
                table: "Apply_Job_Detail",
                column: "Job_DetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Job_Detail_Employer_DetailId",
                table: "Job_Detail",
                column: "Employer_DetailId");

            var sqlFile = Path.Combine(".\\DatabaseScript", @"data.sql");
            migrationBuilder.Sql(File.ReadAllText(sqlFile));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Apply_Job_Detail");

            migrationBuilder.DropTable(
                name: "Candidate_Detail");

            migrationBuilder.DropTable(
                name: "Job_Detail");

            migrationBuilder.DropTable(
                name: "Employer_Detail");
        }
    }
}
