using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FiscalLabService.Repository.PostgreSql.Migrations
{
    /// <inheritdoc />
    public partial class FixCalibratedBalance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "calibrated_balance",
                table: "visits",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "calibrated_balance",
                table: "visits");
        }
    }
}
