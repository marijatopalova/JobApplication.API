using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobApplication.API.Migrations
{
    /// <inheritdoc />
    public partial class AddedJobApplicantsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRecommended",
                table: "Candidates");

            migrationBuilder.CreateTable(
                name: "JobApplicants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VacancyId = table.Column<int>(type: "int", nullable: false),
                    CandidateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobApplicants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobApplicants_Candidates_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobApplicants_Vacancies_VacancyId",
                        column: x => x.VacancyId,
                        principalTable: "Vacancies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobApplicants_CandidateId",
                table: "JobApplicants",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_JobApplicants_VacancyId",
                table: "JobApplicants",
                column: "VacancyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobApplicants");

            migrationBuilder.AddColumn<bool>(
                name: "IsRecommended",
                table: "Candidates",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
