using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobApplication.API.Migrations
{
    /// <inheritdoc />
    public partial class AddedJobActivityStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ActiveStatus",
                table: "Vacancies",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActiveStatus",
                table: "Vacancies");
        }
    }
}
