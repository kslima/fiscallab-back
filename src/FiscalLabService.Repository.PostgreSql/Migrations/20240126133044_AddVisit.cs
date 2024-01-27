using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FiscalLabService.Repository.PostgreSql.Migrations
{
    /// <inheritdoc />
    public partial class AddVisit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "visits",
                columns: table => new
                {
                    id = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: false),
                    PlantId = table.Column<string>(type: "character varying(36)", nullable: false),
                    AssociationId = table.Column<string>(type: "character varying(36)", nullable: false),
                    consultant = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    inspector = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    leader = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    laboratory_leader = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    visit_date = table.Column<DateOnly>(type: "date", nullable: false),
                    visit_time = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_visits", x => x.id);
                    table.ForeignKey(
                        name: "FK_visits_associations_AssociationId",
                        column: x => x.AssociationId,
                        principalTable: "associations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_visits_plants_PlantId",
                        column: x => x.PlantId,
                        principalTable: "plants",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_visits_AssociationId",
                table: "visits",
                column: "AssociationId");

            migrationBuilder.CreateIndex(
                name: "IX_visits_PlantId",
                table: "visits",
                column: "PlantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "visits");
        }
    }
}
