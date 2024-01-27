using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FiscalLabService.Repository.PostgreSql.Migrations
{
    /// <inheritdoc />
    public partial class VisitRefactor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_visits_associations_AssociationId",
                table: "visits");

            migrationBuilder.DropForeignKey(
                name: "FK_visits_plants_PlantId",
                table: "visits");

            migrationBuilder.RenameColumn(
                name: "PlantId",
                table: "visits",
                newName: "plant_id");

            migrationBuilder.RenameColumn(
                name: "AssociationId",
                table: "visits",
                newName: "association_id");

            migrationBuilder.RenameIndex(
                name: "IX_visits_PlantId",
                table: "visits",
                newName: "IX_visits_plant_id");

            migrationBuilder.RenameIndex(
                name: "IX_visits_AssociationId",
                table: "visits",
                newName: "IX_visits_association_id");

            migrationBuilder.AddColumn<decimal>(
                name: "accomplished_crop",
                table: "visits",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "against_knife_conservation",
                table: "visits",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "agitation",
                table: "visits",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "atr_variation",
                table: "visits",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "average_ambient_temperature",
                table: "visits",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "benchmarking",
                table: "visits",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "bottle",
                table: "visits",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "bottle_after_clarified_volume",
                table: "visits",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "bottle_clarified_volume",
                table: "visits",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "broth_extraction",
                table: "visits",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "broth_homogenization",
                table: "visits",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "calibration1",
                table: "visits",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "calibration2",
                table: "visits",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "calibration_certificate",
                table: "visits",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "calibration_certificate_balance",
                table: "visits",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "cargo_draw",
                table: "visits",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "clarifier",
                table: "visits",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "clarifier_amount",
                table: "visits",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "clean_mixer",
                table: "visits",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "clear_colling_cooler",
                table: "visits",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "collect",
                table: "visits",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "collector_bottle",
                table: "visits",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "consecana_ar",
                table: "visits",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "consecana_atr",
                table: "visits",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "consecana_brix",
                table: "visits",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "consecana_fiber",
                table: "visits",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "consecana_ls",
                table: "visits",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "consecana_pbu",
                table: "visits",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "consecana_pcc",
                table: "visits",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "consecana_pol",
                table: "visits",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "consecana_purity",
                table: "visits",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "current_atr",
                table: "visits",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "current_fiber",
                table: "visits",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "desintegrator_rpm",
                table: "visits",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "difference_ar",
                table: "visits",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "difference_atr",
                table: "visits",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "difference_fiber",
                table: "visits",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "difference_pcc",
                table: "visits",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "difference_pol",
                table: "visits",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "difference_purity",
                table: "visits",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "discard_cup",
                table: "visits",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "expected_crop",
                table: "visits",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "farm",
                table: "visits",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "farm_provider_percentage",
                table: "visits",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "fiber_variation",
                table: "visits",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "final_weight",
                table: "visits",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "gm1",
                table: "visits",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "gm100",
                table: "visits",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "gm500",
                table: "visits",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "hammer_conservation",
                table: "visits",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "has_dilution",
                table: "visits",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "homogeneous_samples",
                table: "visits",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "homogeneous_weight",
                table: "visits",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "in_scale",
                table: "visits",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "inspector_performance",
                table: "visits",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "internal_temperature",
                table: "visits",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "knife_against_knife_distance",
                table: "visits",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "knife_conservation",
                table: "visits",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "laboratory_receptivity",
                table: "visits",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "last_crown_change",
                table: "visits",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "leveled_balance",
                table: "visits",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "load_cell",
                table: "visits",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "load_position",
                table: "visits",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "observations",
                table: "visits",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "observations1",
                table: "visits",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "observations10",
                table: "visits",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "observations11",
                table: "visits",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "observations12",
                table: "visits",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "observations2",
                table: "visits",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "observations3",
                table: "visits",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "observations4",
                table: "visits",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "observations5",
                table: "visits",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "observations6",
                table: "visits",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "observations7",
                table: "visits",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "observations8",
                table: "visits",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "observations9",
                table: "visits",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "oc",
                table: "visits",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "out_scale",
                table: "visits",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "owner",
                table: "visits",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "pachymeter",
                table: "visits",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "pendencies",
                table: "visits",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "percentage_realized",
                table: "visits",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "plant_ar",
                table: "visits",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "plant_atr",
                table: "visits",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "plant_brix",
                table: "visits",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "plant_farm_percentage",
                table: "visits",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "plant_fiber",
                table: "visits",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "plant_ls",
                table: "visits",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "plant_pbu",
                table: "visits",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "plant_pcc",
                table: "visits",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "plant_percentage",
                table: "visits",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "plant_pol",
                table: "visits",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "plant_purity",
                table: "visits",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "precision_reading",
                table: "visits",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "preparation_index",
                table: "visits",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "press_cleaning",
                table: "visits",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "pressure",
                table: "visits",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "pressure_gauge_certificated",
                table: "visits",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "previous_atr",
                table: "visits",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "previous_crop",
                table: "visits",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "previous_fiber",
                table: "visits",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "probe_type",
                table: "visits",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "provider_percentage",
                table: "visits",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "quartz_pattern",
                table: "visits",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "quartz_reading",
                table: "visits",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "quartz_result",
                table: "visits",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "range10",
                table: "visits",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "range20",
                table: "visits",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "range30",
                table: "visits",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "refractometer_benchmarking",
                table: "visits",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "refractometer_calibration_certificate",
                table: "visits",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "refractometer_cleaning",
                table: "visits",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "responsible_body",
                table: "visits",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "sample_amount",
                table: "visits",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "scale_observations",
                table: "visits",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "sharpened_or_replaced_knife_at",
                table: "visits",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "stabilization",
                table: "visits",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "sucrose_test",
                table: "visits",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "tachometer",
                table: "visits",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "thermometer",
                table: "visits",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "timer",
                table: "visits",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "toothed_crown",
                table: "visits",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "toothed_crown_type",
                table: "visits",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "tube_cleaning",
                table: "visits",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "tube_discharged",
                table: "visits",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "tube_inserted",
                table: "visits",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "variation_between_crops",
                table: "visits",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "z100",
                table: "visits",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "z50",
                table: "visits",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "z75",
                table: "visits",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_visits_associations_association_id",
                table: "visits",
                column: "association_id",
                principalTable: "associations",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_visits_plants_plant_id",
                table: "visits",
                column: "plant_id",
                principalTable: "plants",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_visits_associations_association_id",
                table: "visits");

            migrationBuilder.DropForeignKey(
                name: "FK_visits_plants_plant_id",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "accomplished_crop",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "against_knife_conservation",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "agitation",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "atr_variation",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "average_ambient_temperature",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "benchmarking",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "bottle",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "bottle_after_clarified_volume",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "bottle_clarified_volume",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "broth_extraction",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "broth_homogenization",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "calibration1",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "calibration2",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "calibration_certificate",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "calibration_certificate_balance",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "cargo_draw",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "clarifier",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "clarifier_amount",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "clean_mixer",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "clear_colling_cooler",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "collect",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "collector_bottle",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "consecana_ar",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "consecana_atr",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "consecana_brix",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "consecana_fiber",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "consecana_ls",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "consecana_pbu",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "consecana_pcc",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "consecana_pol",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "consecana_purity",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "current_atr",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "current_fiber",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "desintegrator_rpm",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "difference_ar",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "difference_atr",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "difference_fiber",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "difference_pcc",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "difference_pol",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "difference_purity",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "discard_cup",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "expected_crop",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "farm",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "farm_provider_percentage",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "fiber_variation",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "final_weight",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "gm1",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "gm100",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "gm500",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "hammer_conservation",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "has_dilution",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "homogeneous_samples",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "homogeneous_weight",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "in_scale",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "inspector_performance",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "internal_temperature",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "knife_against_knife_distance",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "knife_conservation",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "laboratory_receptivity",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "last_crown_change",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "leveled_balance",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "load_cell",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "load_position",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "observations",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "observations1",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "observations10",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "observations11",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "observations12",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "observations2",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "observations3",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "observations4",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "observations5",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "observations6",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "observations7",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "observations8",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "observations9",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "oc",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "out_scale",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "owner",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "pachymeter",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "pendencies",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "percentage_realized",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "plant_ar",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "plant_atr",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "plant_brix",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "plant_farm_percentage",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "plant_fiber",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "plant_ls",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "plant_pbu",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "plant_pcc",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "plant_percentage",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "plant_pol",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "plant_purity",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "precision_reading",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "preparation_index",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "press_cleaning",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "pressure",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "pressure_gauge_certificated",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "previous_atr",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "previous_crop",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "previous_fiber",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "probe_type",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "provider_percentage",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "quartz_pattern",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "quartz_reading",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "quartz_result",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "range10",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "range20",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "range30",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "refractometer_benchmarking",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "refractometer_calibration_certificate",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "refractometer_cleaning",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "responsible_body",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "sample_amount",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "scale_observations",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "sharpened_or_replaced_knife_at",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "stabilization",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "sucrose_test",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "tachometer",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "thermometer",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "timer",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "toothed_crown",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "toothed_crown_type",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "tube_cleaning",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "tube_discharged",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "tube_inserted",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "variation_between_crops",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "z100",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "z50",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "z75",
                table: "visits");

            migrationBuilder.RenameColumn(
                name: "plant_id",
                table: "visits",
                newName: "PlantId");

            migrationBuilder.RenameColumn(
                name: "association_id",
                table: "visits",
                newName: "AssociationId");

            migrationBuilder.RenameIndex(
                name: "IX_visits_plant_id",
                table: "visits",
                newName: "IX_visits_PlantId");

            migrationBuilder.RenameIndex(
                name: "IX_visits_association_id",
                table: "visits",
                newName: "IX_visits_AssociationId");

            migrationBuilder.AddForeignKey(
                name: "FK_visits_associations_AssociationId",
                table: "visits",
                column: "AssociationId",
                principalTable: "associations",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_visits_plants_PlantId",
                table: "visits",
                column: "PlantId",
                principalTable: "plants",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
