using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FiscalLabService.Repository.PostgreSql.Migrations
{
    /// <inheritdoc />
    public partial class RemovePressure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "clarification_saccharimeter_pressure",
                table: "visits");

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "visits",
                type: "timestamp with time zone",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "visits");

            migrationBuilder.AddColumn<string>(
                name: "clarification_saccharimeter_pressure",
                table: "visits",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
