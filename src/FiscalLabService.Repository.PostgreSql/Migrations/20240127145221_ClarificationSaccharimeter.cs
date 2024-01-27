using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FiscalLabService.Repository.PostgreSql.Migrations
{
    /// <inheritdoc />
    public partial class ClarificationSaccharimeter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "clarification_saccharimeter_pressure",
                table: "visits",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "clarification_saccharimeter_pressure",
                table: "visits");
        }
    }
}
