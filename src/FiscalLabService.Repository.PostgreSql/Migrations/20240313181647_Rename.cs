using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FiscalLabService.Repository.PostgreSql.Migrations
{
    /// <inheritdoc />
    public partial class Rename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "sent_at",
                table: "visits",
                newName: "notified_by_email_at");

            migrationBuilder.RenameColumn(
                name: "is_finished",
                table: "visits",
                newName: "notify_by_email");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "notify_by_email",
                table: "visits",
                newName: "is_finished");

            migrationBuilder.RenameColumn(
                name: "notified_by_email_at",
                table: "visits",
                newName: "sent_at");
        }
    }
}
