using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FiscalLabService.Repository.PostgreSql.Migrations
{
    /// <inheritdoc />
    public partial class FixZ25 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "z25",
                table: "visits",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "z25",
                table: "visits");
        }
    }
}
