using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FiscalLabService.Repository.PostgreSql.Migrations
{
    /// <inheritdoc />
    public partial class Sufix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_visits_associations_association_id",
                table: "visits");

            migrationBuilder.DropForeignKey(
                name: "FK_visits_plants_plant_id",
                table: "visits");

            migrationBuilder.RenameColumn(
                name: "z75",
                table: "visits",
                newName: "benchmarking_equipment_z75");

            migrationBuilder.RenameColumn(
                name: "z50",
                table: "visits",
                newName: "benchmarking_equipment_z50");

            migrationBuilder.RenameColumn(
                name: "z25",
                table: "visits",
                newName: "benchmarking_equipment_z25");

            migrationBuilder.RenameColumn(
                name: "z100",
                table: "visits",
                newName: "benchmarking_equipment_z100");

            migrationBuilder.RenameColumn(
                name: "visit_time",
                table: "visits",
                newName: "basic_information_visit_time");

            migrationBuilder.RenameColumn(
                name: "visit_date",
                table: "visits",
                newName: "basic_information_visit_date");

            migrationBuilder.RenameColumn(
                name: "variation_between_crops",
                table: "visits",
                newName: "benchmarking_equipment_variation_between_crops");

            migrationBuilder.RenameColumn(
                name: "tube_inserted",
                table: "visits",
                newName: "desintegrator_probe_tube_inserted");

            migrationBuilder.RenameColumn(
                name: "tube_discharged",
                table: "visits",
                newName: "desintegrator_probe_tube_discharged");

            migrationBuilder.RenameColumn(
                name: "tube_cleaning",
                table: "visits",
                newName: "clarification_saccharimeter_tube_cleaning");

            migrationBuilder.RenameColumn(
                name: "toothed_crown_type",
                table: "visits",
                newName: "desintegrator_probe_toothed_crown_type");

            migrationBuilder.RenameColumn(
                name: "toothed_crown",
                table: "visits",
                newName: "desintegrator_probe_toothed_crown");

            migrationBuilder.RenameColumn(
                name: "timer",
                table: "visits",
                newName: "press_refractometer_timer");

            migrationBuilder.RenameColumn(
                name: "thermometer",
                table: "visits",
                newName: "benchmarking_equipment_thermometer");

            migrationBuilder.RenameColumn(
                name: "tachometer",
                table: "visits",
                newName: "benchmarking_equipment_tachometer");

            migrationBuilder.RenameColumn(
                name: "sucrose_test",
                table: "visits",
                newName: "benchmarking_equipment_sucrose_test");

            migrationBuilder.RenameColumn(
                name: "stabilization",
                table: "visits",
                newName: "clarification_saccharimeter_stabilization");

            migrationBuilder.RenameColumn(
                name: "sharpened_or_replaced_knife_at",
                table: "visits",
                newName: "desintegrator_probe_sharpened_or_replaced_knife_at");

            migrationBuilder.RenameColumn(
                name: "scale_observations",
                table: "visits",
                newName: "sugarcane_balance_scale_observations");

            migrationBuilder.RenameColumn(
                name: "sample_amount",
                table: "visits",
                newName: "desintegrator_probe_sample_amount");

            migrationBuilder.RenameColumn(
                name: "responsible_body",
                table: "visits",
                newName: "sugarcane_balance_responsible_body");

            migrationBuilder.RenameColumn(
                name: "refractometer_cleaning",
                table: "visits",
                newName: "press_refractometer_refractometer_cleaning");

            migrationBuilder.RenameColumn(
                name: "refractometer_calibration_certificate",
                table: "visits",
                newName: "press_refractometer_refractometer_calibration_certificate");

            migrationBuilder.RenameColumn(
                name: "refractometer_benchmarking",
                table: "visits",
                newName: "press_refractometer_refractometer_benchmarking");

            migrationBuilder.RenameColumn(
                name: "range30",
                table: "visits",
                newName: "benchmarking_equipment_range30");

            migrationBuilder.RenameColumn(
                name: "range20",
                table: "visits",
                newName: "benchmarking_equipment_range20");

            migrationBuilder.RenameColumn(
                name: "range10",
                table: "visits",
                newName: "benchmarking_equipment_range10");

            migrationBuilder.RenameColumn(
                name: "quartz_result",
                table: "visits",
                newName: "clarification_saccharimeter_quartz_result");

            migrationBuilder.RenameColumn(
                name: "quartz_reading",
                table: "visits",
                newName: "clarification_saccharimeter_quartz_reading");

            migrationBuilder.RenameColumn(
                name: "quartz_pattern",
                table: "visits",
                newName: "clarification_saccharimeter_quartz_pattern");

            migrationBuilder.RenameColumn(
                name: "provider_percentage",
                table: "visits",
                newName: "sugarcane_balance_provider_percentage");

            migrationBuilder.RenameColumn(
                name: "probe_type",
                table: "visits",
                newName: "desintegrator_probe_probe_type");

            migrationBuilder.RenameColumn(
                name: "previous_fiber",
                table: "visits",
                newName: "benchmarking_equipment_previous_fiber");

            migrationBuilder.RenameColumn(
                name: "previous_crop",
                table: "visits",
                newName: "benchmarking_equipment_previous_crop");

            migrationBuilder.RenameColumn(
                name: "previous_atr",
                table: "visits",
                newName: "benchmarking_equipment_previous_atr");

            migrationBuilder.RenameColumn(
                name: "pressure_gauge_certificated",
                table: "visits",
                newName: "press_refractometer_pressure_gauge_certificated");

            migrationBuilder.RenameColumn(
                name: "pressure",
                table: "visits",
                newName: "press_refractometer_pressure");

            migrationBuilder.RenameColumn(
                name: "press_cleaning",
                table: "visits",
                newName: "press_refractometer_press_cleaning");

            migrationBuilder.RenameColumn(
                name: "preparation_index",
                table: "visits",
                newName: "desintegrator_probe_preparation_index");

            migrationBuilder.RenameColumn(
                name: "precision_reading",
                table: "visits",
                newName: "press_refractometer_precision_reading");

            migrationBuilder.RenameColumn(
                name: "plant_purity",
                table: "visits",
                newName: "system_consistency_plant_purity");

            migrationBuilder.RenameColumn(
                name: "plant_pol",
                table: "visits",
                newName: "system_consistency_plant_pol");

            migrationBuilder.RenameColumn(
                name: "plant_percentage",
                table: "visits",
                newName: "sugarcane_balance_plant_percentage");

            migrationBuilder.RenameColumn(
                name: "plant_pcc",
                table: "visits",
                newName: "system_consistency_plant_pcc");

            migrationBuilder.RenameColumn(
                name: "plant_pbu",
                table: "visits",
                newName: "system_consistency_plant_pbu");

            migrationBuilder.RenameColumn(
                name: "plant_ls",
                table: "visits",
                newName: "system_consistency_plant_ls");

            migrationBuilder.RenameColumn(
                name: "plant_id",
                table: "visits",
                newName: "basic_information_plant_id");

            migrationBuilder.RenameColumn(
                name: "plant_fiber",
                table: "visits",
                newName: "system_consistency_plant_fiber");

            migrationBuilder.RenameColumn(
                name: "plant_farm_percentage",
                table: "visits",
                newName: "sugarcane_balance_plant_farm_percentage");

            migrationBuilder.RenameColumn(
                name: "plant_brix",
                table: "visits",
                newName: "system_consistency_plant_brix");

            migrationBuilder.RenameColumn(
                name: "plant_atr",
                table: "visits",
                newName: "system_consistency_plant_atr");

            migrationBuilder.RenameColumn(
                name: "plant_ar",
                table: "visits",
                newName: "system_consistency_plant_ar");

            migrationBuilder.RenameColumn(
                name: "percentage_realized",
                table: "visits",
                newName: "benchmarking_equipment_percentage_realized");

            migrationBuilder.RenameColumn(
                name: "pendencies",
                table: "visits",
                newName: "conclusion_pendencies");

            migrationBuilder.RenameColumn(
                name: "pachymeter",
                table: "visits",
                newName: "benchmarking_equipment_pachymeter");

            migrationBuilder.RenameColumn(
                name: "owner",
                table: "visits",
                newName: "system_consistency_owner");

            migrationBuilder.RenameColumn(
                name: "out_scale",
                table: "visits",
                newName: "sugarcane_balance_out_scale");

            migrationBuilder.RenameColumn(
                name: "oc",
                table: "visits",
                newName: "system_consistency_oc");

            migrationBuilder.RenameColumn(
                name: "observations9",
                table: "visits",
                newName: "clarification_saccharimeter_observations9");

            migrationBuilder.RenameColumn(
                name: "observations8",
                table: "visits",
                newName: "press_refractometer_observations8");

            migrationBuilder.RenameColumn(
                name: "observations7",
                table: "visits",
                newName: "press_refractometer_observations7");

            migrationBuilder.RenameColumn(
                name: "observations6",
                table: "visits",
                newName: "analytical_balance_observations6");

            migrationBuilder.RenameColumn(
                name: "observations5",
                table: "visits",
                newName: "analytical_balance_observations5");

            migrationBuilder.RenameColumn(
                name: "observations4",
                table: "visits",
                newName: "desintegrator_probe_observations4");

            migrationBuilder.RenameColumn(
                name: "observations3",
                table: "visits",
                newName: "desintegrator_probe_observations3");

            migrationBuilder.RenameColumn(
                name: "observations2",
                table: "visits",
                newName: "sugarcane_balance_observations2");

            migrationBuilder.RenameColumn(
                name: "observations12",
                table: "visits",
                newName: "benchmarking_equipment_observations12");

            migrationBuilder.RenameColumn(
                name: "observations11",
                table: "visits",
                newName: "benchmarking_equipment_observations11");

            migrationBuilder.RenameColumn(
                name: "observations10",
                table: "visits",
                newName: "clarification_saccharimeter_observations10");

            migrationBuilder.RenameColumn(
                name: "observations1",
                table: "visits",
                newName: "sugarcane_balance_observations1");

            migrationBuilder.RenameColumn(
                name: "observations",
                table: "visits",
                newName: "system_consistency_observations");

            migrationBuilder.RenameColumn(
                name: "load_position",
                table: "visits",
                newName: "desintegrator_probe_load_position");

            migrationBuilder.RenameColumn(
                name: "load_cell",
                table: "visits",
                newName: "benchmarking_equipment_load_cell");

            migrationBuilder.RenameColumn(
                name: "leveled_balance",
                table: "visits",
                newName: "analytical_balance_leveled_balance");

            migrationBuilder.RenameColumn(
                name: "leader",
                table: "visits",
                newName: "basic_information_leader");

            migrationBuilder.RenameColumn(
                name: "last_crown_change",
                table: "visits",
                newName: "desintegrator_probe_last_crown_change");

            migrationBuilder.RenameColumn(
                name: "laboratory_receptivity",
                table: "visits",
                newName: "conclusion_laboratory_receptivity");

            migrationBuilder.RenameColumn(
                name: "laboratory_leader",
                table: "visits",
                newName: "basic_information_laboratory_leader");

            migrationBuilder.RenameColumn(
                name: "knife_conservation",
                table: "visits",
                newName: "desintegrator_probe_knife_conservation");

            migrationBuilder.RenameColumn(
                name: "knife_against_knife_distance",
                table: "visits",
                newName: "desintegrator_probe_knife_against_knife_distance");

            migrationBuilder.RenameColumn(
                name: "internal_temperature",
                table: "visits",
                newName: "press_refractometer_internal_temperature");

            migrationBuilder.RenameColumn(
                name: "inspector_performance",
                table: "visits",
                newName: "conclusion_inspector_performance");

            migrationBuilder.RenameColumn(
                name: "inspector",
                table: "visits",
                newName: "basic_information_inspector");

            migrationBuilder.RenameColumn(
                name: "in_scale",
                table: "visits",
                newName: "sugarcane_balance_in_scale");

            migrationBuilder.RenameColumn(
                name: "homogeneous_weight",
                table: "visits",
                newName: "analytical_balance_homogeneous_weight");

            migrationBuilder.RenameColumn(
                name: "homogeneous_samples",
                table: "visits",
                newName: "desintegrator_probe_homogeneous_samples");

            migrationBuilder.RenameColumn(
                name: "has_dilution",
                table: "visits",
                newName: "clarification_saccharimeter_has_dilution");

            migrationBuilder.RenameColumn(
                name: "hammer_conservation",
                table: "visits",
                newName: "desintegrator_probe_hammer_conservation");

            migrationBuilder.RenameColumn(
                name: "gm500",
                table: "visits",
                newName: "benchmarking_equipment_gm500");

            migrationBuilder.RenameColumn(
                name: "gm100",
                table: "visits",
                newName: "benchmarking_equipment_gm100");

            migrationBuilder.RenameColumn(
                name: "gm1",
                table: "visits",
                newName: "benchmarking_equipment_gm1");

            migrationBuilder.RenameColumn(
                name: "final_weight",
                table: "visits",
                newName: "analytical_balance_final_weight");

            migrationBuilder.RenameColumn(
                name: "fiber_variation",
                table: "visits",
                newName: "benchmarking_equipment_fiber_variation");

            migrationBuilder.RenameColumn(
                name: "farm_provider_percentage",
                table: "visits",
                newName: "sugarcane_balance_farm_provider_percentage");

            migrationBuilder.RenameColumn(
                name: "farm",
                table: "visits",
                newName: "system_consistency_farm");

            migrationBuilder.RenameColumn(
                name: "expected_crop",
                table: "visits",
                newName: "benchmarking_equipment_expected_crop");

            migrationBuilder.RenameColumn(
                name: "discard_cup",
                table: "visits",
                newName: "press_refractometer_discard_cup");

            migrationBuilder.RenameColumn(
                name: "difference_purity",
                table: "visits",
                newName: "system_consistency_difference_purity");

            migrationBuilder.RenameColumn(
                name: "difference_pol",
                table: "visits",
                newName: "system_consistency_difference_pol");

            migrationBuilder.RenameColumn(
                name: "difference_pcc",
                table: "visits",
                newName: "system_consistency_difference_pcc");

            migrationBuilder.RenameColumn(
                name: "difference_fiber",
                table: "visits",
                newName: "system_consistency_difference_fiber");

            migrationBuilder.RenameColumn(
                name: "difference_atr",
                table: "visits",
                newName: "system_consistency_difference_atr");

            migrationBuilder.RenameColumn(
                name: "difference_ar",
                table: "visits",
                newName: "system_consistency_difference_ar");

            migrationBuilder.RenameColumn(
                name: "desintegrator_rpm",
                table: "visits",
                newName: "desintegrator_probe_desintegrator_rpm");

            migrationBuilder.RenameColumn(
                name: "current_fiber",
                table: "visits",
                newName: "benchmarking_equipment_current_fiber");

            migrationBuilder.RenameColumn(
                name: "current_atr",
                table: "visits",
                newName: "benchmarking_equipment_current_atr");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "visits",
                newName: "basic_information_created_at");

            migrationBuilder.RenameColumn(
                name: "consultant",
                table: "visits",
                newName: "basic_information_consultant");

            migrationBuilder.RenameColumn(
                name: "consecana_purity",
                table: "visits",
                newName: "system_consistency_consecana_purity");

            migrationBuilder.RenameColumn(
                name: "consecana_pol",
                table: "visits",
                newName: "system_consistency_consecana_pol");

            migrationBuilder.RenameColumn(
                name: "consecana_pcc",
                table: "visits",
                newName: "system_consistency_consecana_pcc");

            migrationBuilder.RenameColumn(
                name: "consecana_pbu",
                table: "visits",
                newName: "system_consistency_consecana_pbu");

            migrationBuilder.RenameColumn(
                name: "consecana_ls",
                table: "visits",
                newName: "system_consistency_consecana_ls");

            migrationBuilder.RenameColumn(
                name: "consecana_fiber",
                table: "visits",
                newName: "system_consistency_consecana_fiber");

            migrationBuilder.RenameColumn(
                name: "consecana_brix",
                table: "visits",
                newName: "system_consistency_consecana_brix");

            migrationBuilder.RenameColumn(
                name: "consecana_atr",
                table: "visits",
                newName: "system_consistency_consecana_atr");

            migrationBuilder.RenameColumn(
                name: "consecana_ar",
                table: "visits",
                newName: "system_consistency_consecana_ar");

            migrationBuilder.RenameColumn(
                name: "collector_bottle",
                table: "visits",
                newName: "press_refractometer_collector_bottle");

            migrationBuilder.RenameColumn(
                name: "collect",
                table: "visits",
                newName: "desintegrator_probe_collect");

            migrationBuilder.RenameColumn(
                name: "clear_colling_cooler",
                table: "visits",
                newName: "clarification_saccharimeter_clear_colling_cooler");

            migrationBuilder.RenameColumn(
                name: "clean_mixer",
                table: "visits",
                newName: "desintegrator_probe_clean_mixer");

            migrationBuilder.RenameColumn(
                name: "clarifier_amount",
                table: "visits",
                newName: "clarification_saccharimeter_clarifier_amount");

            migrationBuilder.RenameColumn(
                name: "clarifier",
                table: "visits",
                newName: "system_consistency_clarifier");

            migrationBuilder.RenameColumn(
                name: "cargo_draw",
                table: "visits",
                newName: "sugarcane_balance_cargo_draw");

            migrationBuilder.RenameColumn(
                name: "calibration_certificate_balance",
                table: "visits",
                newName: "analytical_balance_calibration_certificate_balance");

            migrationBuilder.RenameColumn(
                name: "calibration_certificate",
                table: "visits",
                newName: "sugarcane_balance_calibration_certificate");

            migrationBuilder.RenameColumn(
                name: "calibration2",
                table: "visits",
                newName: "sugarcane_balance_calibration2");

            migrationBuilder.RenameColumn(
                name: "calibration1",
                table: "visits",
                newName: "sugarcane_balance_calibration1");

            migrationBuilder.RenameColumn(
                name: "calibrated_balance",
                table: "visits",
                newName: "analytical_balance_calibrated_balance");

            migrationBuilder.RenameColumn(
                name: "broth_homogenization",
                table: "visits",
                newName: "press_refractometer_broth_homogenization");

            migrationBuilder.RenameColumn(
                name: "broth_extraction",
                table: "visits",
                newName: "desintegrator_probe_broth_extraction");

            migrationBuilder.RenameColumn(
                name: "bottle_clarified_volume",
                table: "visits",
                newName: "clarification_saccharimeter_bottle_clarified_volume");

            migrationBuilder.RenameColumn(
                name: "bottle_after_clarified_volume",
                table: "visits",
                newName: "clarification_saccharimeter_bottle_after_clarified_volume");

            migrationBuilder.RenameColumn(
                name: "bottle",
                table: "visits",
                newName: "clarification_saccharimeter_bottle");

            migrationBuilder.RenameColumn(
                name: "benchmarking",
                table: "visits",
                newName: "clarification_saccharimeter_benchmarking");

            migrationBuilder.RenameColumn(
                name: "average_ambient_temperature",
                table: "visits",
                newName: "analytical_balance_average_ambient_temperature");

            migrationBuilder.RenameColumn(
                name: "atr_variation",
                table: "visits",
                newName: "benchmarking_equipment_atr_variation");

            migrationBuilder.RenameColumn(
                name: "association_id",
                table: "visits",
                newName: "basic_information_association_id");

            migrationBuilder.RenameColumn(
                name: "agitation",
                table: "visits",
                newName: "clarification_saccharimeter_agitation");

            migrationBuilder.RenameColumn(
                name: "against_knife_conservation",
                table: "visits",
                newName: "desintegrator_probe_against_knife_conservation");

            migrationBuilder.RenameColumn(
                name: "accomplished_crop",
                table: "visits",
                newName: "benchmarking_equipment_accomplished_crop");

            migrationBuilder.RenameIndex(
                name: "IX_visits_plant_id",
                table: "visits",
                newName: "IX_visits_basic_information_plant_id");

            migrationBuilder.RenameIndex(
                name: "IX_visits_association_id",
                table: "visits",
                newName: "IX_visits_basic_information_association_id");

            migrationBuilder.AddColumn<string>(
                name: "clarification_saccharimeter_calibration_certificate",
                table: "visits",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "clarification_saccharimeter_clarifier",
                table: "visits",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "conclusion_conclusion_observations",
                table: "visits",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_visits_associations_basic_information_association_id",
                table: "visits",
                column: "basic_information_association_id",
                principalTable: "associations",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_visits_plants_basic_information_plant_id",
                table: "visits",
                column: "basic_information_plant_id",
                principalTable: "plants",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_visits_associations_basic_information_association_id",
                table: "visits");

            migrationBuilder.DropForeignKey(
                name: "FK_visits_plants_basic_information_plant_id",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "clarification_saccharimeter_calibration_certificate",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "clarification_saccharimeter_clarifier",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "conclusion_conclusion_observations",
                table: "visits");

            migrationBuilder.RenameColumn(
                name: "system_consistency_plant_purity",
                table: "visits",
                newName: "plant_purity");

            migrationBuilder.RenameColumn(
                name: "system_consistency_plant_pol",
                table: "visits",
                newName: "plant_pol");

            migrationBuilder.RenameColumn(
                name: "system_consistency_plant_pcc",
                table: "visits",
                newName: "plant_pcc");

            migrationBuilder.RenameColumn(
                name: "system_consistency_plant_pbu",
                table: "visits",
                newName: "plant_pbu");

            migrationBuilder.RenameColumn(
                name: "system_consistency_plant_ls",
                table: "visits",
                newName: "plant_ls");

            migrationBuilder.RenameColumn(
                name: "system_consistency_plant_fiber",
                table: "visits",
                newName: "plant_fiber");

            migrationBuilder.RenameColumn(
                name: "system_consistency_plant_brix",
                table: "visits",
                newName: "plant_brix");

            migrationBuilder.RenameColumn(
                name: "system_consistency_plant_atr",
                table: "visits",
                newName: "plant_atr");

            migrationBuilder.RenameColumn(
                name: "system_consistency_plant_ar",
                table: "visits",
                newName: "plant_ar");

            migrationBuilder.RenameColumn(
                name: "system_consistency_owner",
                table: "visits",
                newName: "owner");

            migrationBuilder.RenameColumn(
                name: "system_consistency_oc",
                table: "visits",
                newName: "oc");

            migrationBuilder.RenameColumn(
                name: "system_consistency_observations",
                table: "visits",
                newName: "observations");

            migrationBuilder.RenameColumn(
                name: "system_consistency_farm",
                table: "visits",
                newName: "farm");

            migrationBuilder.RenameColumn(
                name: "system_consistency_difference_purity",
                table: "visits",
                newName: "difference_purity");

            migrationBuilder.RenameColumn(
                name: "system_consistency_difference_pol",
                table: "visits",
                newName: "difference_pol");

            migrationBuilder.RenameColumn(
                name: "system_consistency_difference_pcc",
                table: "visits",
                newName: "difference_pcc");

            migrationBuilder.RenameColumn(
                name: "system_consistency_difference_fiber",
                table: "visits",
                newName: "difference_fiber");

            migrationBuilder.RenameColumn(
                name: "system_consistency_difference_atr",
                table: "visits",
                newName: "difference_atr");

            migrationBuilder.RenameColumn(
                name: "system_consistency_difference_ar",
                table: "visits",
                newName: "difference_ar");

            migrationBuilder.RenameColumn(
                name: "system_consistency_consecana_purity",
                table: "visits",
                newName: "consecana_purity");

            migrationBuilder.RenameColumn(
                name: "system_consistency_consecana_pol",
                table: "visits",
                newName: "consecana_pol");

            migrationBuilder.RenameColumn(
                name: "system_consistency_consecana_pcc",
                table: "visits",
                newName: "consecana_pcc");

            migrationBuilder.RenameColumn(
                name: "system_consistency_consecana_pbu",
                table: "visits",
                newName: "consecana_pbu");

            migrationBuilder.RenameColumn(
                name: "system_consistency_consecana_ls",
                table: "visits",
                newName: "consecana_ls");

            migrationBuilder.RenameColumn(
                name: "system_consistency_consecana_fiber",
                table: "visits",
                newName: "consecana_fiber");

            migrationBuilder.RenameColumn(
                name: "system_consistency_consecana_brix",
                table: "visits",
                newName: "consecana_brix");

            migrationBuilder.RenameColumn(
                name: "system_consistency_consecana_atr",
                table: "visits",
                newName: "consecana_atr");

            migrationBuilder.RenameColumn(
                name: "system_consistency_consecana_ar",
                table: "visits",
                newName: "consecana_ar");

            migrationBuilder.RenameColumn(
                name: "system_consistency_clarifier",
                table: "visits",
                newName: "clarifier");

            migrationBuilder.RenameColumn(
                name: "sugarcane_balance_scale_observations",
                table: "visits",
                newName: "scale_observations");

            migrationBuilder.RenameColumn(
                name: "sugarcane_balance_responsible_body",
                table: "visits",
                newName: "responsible_body");

            migrationBuilder.RenameColumn(
                name: "sugarcane_balance_provider_percentage",
                table: "visits",
                newName: "provider_percentage");

            migrationBuilder.RenameColumn(
                name: "sugarcane_balance_plant_percentage",
                table: "visits",
                newName: "plant_percentage");

            migrationBuilder.RenameColumn(
                name: "sugarcane_balance_plant_farm_percentage",
                table: "visits",
                newName: "plant_farm_percentage");

            migrationBuilder.RenameColumn(
                name: "sugarcane_balance_out_scale",
                table: "visits",
                newName: "out_scale");

            migrationBuilder.RenameColumn(
                name: "sugarcane_balance_observations2",
                table: "visits",
                newName: "observations2");

            migrationBuilder.RenameColumn(
                name: "sugarcane_balance_observations1",
                table: "visits",
                newName: "observations1");

            migrationBuilder.RenameColumn(
                name: "sugarcane_balance_in_scale",
                table: "visits",
                newName: "in_scale");

            migrationBuilder.RenameColumn(
                name: "sugarcane_balance_farm_provider_percentage",
                table: "visits",
                newName: "farm_provider_percentage");

            migrationBuilder.RenameColumn(
                name: "sugarcane_balance_cargo_draw",
                table: "visits",
                newName: "cargo_draw");

            migrationBuilder.RenameColumn(
                name: "sugarcane_balance_calibration_certificate",
                table: "visits",
                newName: "calibration_certificate");

            migrationBuilder.RenameColumn(
                name: "sugarcane_balance_calibration2",
                table: "visits",
                newName: "calibration2");

            migrationBuilder.RenameColumn(
                name: "sugarcane_balance_calibration1",
                table: "visits",
                newName: "calibration1");

            migrationBuilder.RenameColumn(
                name: "press_refractometer_timer",
                table: "visits",
                newName: "timer");

            migrationBuilder.RenameColumn(
                name: "press_refractometer_refractometer_cleaning",
                table: "visits",
                newName: "refractometer_cleaning");

            migrationBuilder.RenameColumn(
                name: "press_refractometer_refractometer_calibration_certificate",
                table: "visits",
                newName: "refractometer_calibration_certificate");

            migrationBuilder.RenameColumn(
                name: "press_refractometer_refractometer_benchmarking",
                table: "visits",
                newName: "refractometer_benchmarking");

            migrationBuilder.RenameColumn(
                name: "press_refractometer_pressure_gauge_certificated",
                table: "visits",
                newName: "pressure_gauge_certificated");

            migrationBuilder.RenameColumn(
                name: "press_refractometer_pressure",
                table: "visits",
                newName: "pressure");

            migrationBuilder.RenameColumn(
                name: "press_refractometer_press_cleaning",
                table: "visits",
                newName: "press_cleaning");

            migrationBuilder.RenameColumn(
                name: "press_refractometer_precision_reading",
                table: "visits",
                newName: "precision_reading");

            migrationBuilder.RenameColumn(
                name: "press_refractometer_observations8",
                table: "visits",
                newName: "observations8");

            migrationBuilder.RenameColumn(
                name: "press_refractometer_observations7",
                table: "visits",
                newName: "observations7");

            migrationBuilder.RenameColumn(
                name: "press_refractometer_internal_temperature",
                table: "visits",
                newName: "internal_temperature");

            migrationBuilder.RenameColumn(
                name: "press_refractometer_discard_cup",
                table: "visits",
                newName: "discard_cup");

            migrationBuilder.RenameColumn(
                name: "press_refractometer_collector_bottle",
                table: "visits",
                newName: "collector_bottle");

            migrationBuilder.RenameColumn(
                name: "press_refractometer_broth_homogenization",
                table: "visits",
                newName: "broth_homogenization");

            migrationBuilder.RenameColumn(
                name: "desintegrator_probe_tube_inserted",
                table: "visits",
                newName: "tube_inserted");

            migrationBuilder.RenameColumn(
                name: "desintegrator_probe_tube_discharged",
                table: "visits",
                newName: "tube_discharged");

            migrationBuilder.RenameColumn(
                name: "desintegrator_probe_toothed_crown_type",
                table: "visits",
                newName: "toothed_crown_type");

            migrationBuilder.RenameColumn(
                name: "desintegrator_probe_toothed_crown",
                table: "visits",
                newName: "toothed_crown");

            migrationBuilder.RenameColumn(
                name: "desintegrator_probe_sharpened_or_replaced_knife_at",
                table: "visits",
                newName: "sharpened_or_replaced_knife_at");

            migrationBuilder.RenameColumn(
                name: "desintegrator_probe_sample_amount",
                table: "visits",
                newName: "sample_amount");

            migrationBuilder.RenameColumn(
                name: "desintegrator_probe_probe_type",
                table: "visits",
                newName: "probe_type");

            migrationBuilder.RenameColumn(
                name: "desintegrator_probe_preparation_index",
                table: "visits",
                newName: "preparation_index");

            migrationBuilder.RenameColumn(
                name: "desintegrator_probe_observations4",
                table: "visits",
                newName: "observations4");

            migrationBuilder.RenameColumn(
                name: "desintegrator_probe_observations3",
                table: "visits",
                newName: "observations3");

            migrationBuilder.RenameColumn(
                name: "desintegrator_probe_load_position",
                table: "visits",
                newName: "load_position");

            migrationBuilder.RenameColumn(
                name: "desintegrator_probe_last_crown_change",
                table: "visits",
                newName: "last_crown_change");

            migrationBuilder.RenameColumn(
                name: "desintegrator_probe_knife_conservation",
                table: "visits",
                newName: "knife_conservation");

            migrationBuilder.RenameColumn(
                name: "desintegrator_probe_knife_against_knife_distance",
                table: "visits",
                newName: "knife_against_knife_distance");

            migrationBuilder.RenameColumn(
                name: "desintegrator_probe_homogeneous_samples",
                table: "visits",
                newName: "homogeneous_samples");

            migrationBuilder.RenameColumn(
                name: "desintegrator_probe_hammer_conservation",
                table: "visits",
                newName: "hammer_conservation");

            migrationBuilder.RenameColumn(
                name: "desintegrator_probe_desintegrator_rpm",
                table: "visits",
                newName: "desintegrator_rpm");

            migrationBuilder.RenameColumn(
                name: "desintegrator_probe_collect",
                table: "visits",
                newName: "collect");

            migrationBuilder.RenameColumn(
                name: "desintegrator_probe_clean_mixer",
                table: "visits",
                newName: "clean_mixer");

            migrationBuilder.RenameColumn(
                name: "desintegrator_probe_broth_extraction",
                table: "visits",
                newName: "broth_extraction");

            migrationBuilder.RenameColumn(
                name: "desintegrator_probe_against_knife_conservation",
                table: "visits",
                newName: "against_knife_conservation");

            migrationBuilder.RenameColumn(
                name: "conclusion_pendencies",
                table: "visits",
                newName: "pendencies");

            migrationBuilder.RenameColumn(
                name: "conclusion_laboratory_receptivity",
                table: "visits",
                newName: "laboratory_receptivity");

            migrationBuilder.RenameColumn(
                name: "conclusion_inspector_performance",
                table: "visits",
                newName: "inspector_performance");

            migrationBuilder.RenameColumn(
                name: "clarification_saccharimeter_tube_cleaning",
                table: "visits",
                newName: "tube_cleaning");

            migrationBuilder.RenameColumn(
                name: "clarification_saccharimeter_stabilization",
                table: "visits",
                newName: "stabilization");

            migrationBuilder.RenameColumn(
                name: "clarification_saccharimeter_quartz_result",
                table: "visits",
                newName: "quartz_result");

            migrationBuilder.RenameColumn(
                name: "clarification_saccharimeter_quartz_reading",
                table: "visits",
                newName: "quartz_reading");

            migrationBuilder.RenameColumn(
                name: "clarification_saccharimeter_quartz_pattern",
                table: "visits",
                newName: "quartz_pattern");

            migrationBuilder.RenameColumn(
                name: "clarification_saccharimeter_observations9",
                table: "visits",
                newName: "observations9");

            migrationBuilder.RenameColumn(
                name: "clarification_saccharimeter_observations10",
                table: "visits",
                newName: "observations10");

            migrationBuilder.RenameColumn(
                name: "clarification_saccharimeter_has_dilution",
                table: "visits",
                newName: "has_dilution");

            migrationBuilder.RenameColumn(
                name: "clarification_saccharimeter_clear_colling_cooler",
                table: "visits",
                newName: "clear_colling_cooler");

            migrationBuilder.RenameColumn(
                name: "clarification_saccharimeter_clarifier_amount",
                table: "visits",
                newName: "clarifier_amount");

            migrationBuilder.RenameColumn(
                name: "clarification_saccharimeter_bottle_clarified_volume",
                table: "visits",
                newName: "bottle_clarified_volume");

            migrationBuilder.RenameColumn(
                name: "clarification_saccharimeter_bottle_after_clarified_volume",
                table: "visits",
                newName: "bottle_after_clarified_volume");

            migrationBuilder.RenameColumn(
                name: "clarification_saccharimeter_bottle",
                table: "visits",
                newName: "bottle");

            migrationBuilder.RenameColumn(
                name: "clarification_saccharimeter_benchmarking",
                table: "visits",
                newName: "benchmarking");

            migrationBuilder.RenameColumn(
                name: "clarification_saccharimeter_agitation",
                table: "visits",
                newName: "agitation");

            migrationBuilder.RenameColumn(
                name: "benchmarking_equipment_z75",
                table: "visits",
                newName: "z75");

            migrationBuilder.RenameColumn(
                name: "benchmarking_equipment_z50",
                table: "visits",
                newName: "z50");

            migrationBuilder.RenameColumn(
                name: "benchmarking_equipment_z25",
                table: "visits",
                newName: "z25");

            migrationBuilder.RenameColumn(
                name: "benchmarking_equipment_z100",
                table: "visits",
                newName: "z100");

            migrationBuilder.RenameColumn(
                name: "benchmarking_equipment_variation_between_crops",
                table: "visits",
                newName: "variation_between_crops");

            migrationBuilder.RenameColumn(
                name: "benchmarking_equipment_thermometer",
                table: "visits",
                newName: "thermometer");

            migrationBuilder.RenameColumn(
                name: "benchmarking_equipment_tachometer",
                table: "visits",
                newName: "tachometer");

            migrationBuilder.RenameColumn(
                name: "benchmarking_equipment_sucrose_test",
                table: "visits",
                newName: "sucrose_test");

            migrationBuilder.RenameColumn(
                name: "benchmarking_equipment_range30",
                table: "visits",
                newName: "range30");

            migrationBuilder.RenameColumn(
                name: "benchmarking_equipment_range20",
                table: "visits",
                newName: "range20");

            migrationBuilder.RenameColumn(
                name: "benchmarking_equipment_range10",
                table: "visits",
                newName: "range10");

            migrationBuilder.RenameColumn(
                name: "benchmarking_equipment_previous_fiber",
                table: "visits",
                newName: "previous_fiber");

            migrationBuilder.RenameColumn(
                name: "benchmarking_equipment_previous_crop",
                table: "visits",
                newName: "previous_crop");

            migrationBuilder.RenameColumn(
                name: "benchmarking_equipment_previous_atr",
                table: "visits",
                newName: "previous_atr");

            migrationBuilder.RenameColumn(
                name: "benchmarking_equipment_percentage_realized",
                table: "visits",
                newName: "percentage_realized");

            migrationBuilder.RenameColumn(
                name: "benchmarking_equipment_pachymeter",
                table: "visits",
                newName: "pachymeter");

            migrationBuilder.RenameColumn(
                name: "benchmarking_equipment_observations12",
                table: "visits",
                newName: "observations12");

            migrationBuilder.RenameColumn(
                name: "benchmarking_equipment_observations11",
                table: "visits",
                newName: "observations11");

            migrationBuilder.RenameColumn(
                name: "benchmarking_equipment_load_cell",
                table: "visits",
                newName: "load_cell");

            migrationBuilder.RenameColumn(
                name: "benchmarking_equipment_gm500",
                table: "visits",
                newName: "gm500");

            migrationBuilder.RenameColumn(
                name: "benchmarking_equipment_gm100",
                table: "visits",
                newName: "gm100");

            migrationBuilder.RenameColumn(
                name: "benchmarking_equipment_gm1",
                table: "visits",
                newName: "gm1");

            migrationBuilder.RenameColumn(
                name: "benchmarking_equipment_fiber_variation",
                table: "visits",
                newName: "fiber_variation");

            migrationBuilder.RenameColumn(
                name: "benchmarking_equipment_expected_crop",
                table: "visits",
                newName: "expected_crop");

            migrationBuilder.RenameColumn(
                name: "benchmarking_equipment_current_fiber",
                table: "visits",
                newName: "current_fiber");

            migrationBuilder.RenameColumn(
                name: "benchmarking_equipment_current_atr",
                table: "visits",
                newName: "current_atr");

            migrationBuilder.RenameColumn(
                name: "benchmarking_equipment_atr_variation",
                table: "visits",
                newName: "atr_variation");

            migrationBuilder.RenameColumn(
                name: "benchmarking_equipment_accomplished_crop",
                table: "visits",
                newName: "accomplished_crop");

            migrationBuilder.RenameColumn(
                name: "basic_information_visit_time",
                table: "visits",
                newName: "visit_time");

            migrationBuilder.RenameColumn(
                name: "basic_information_visit_date",
                table: "visits",
                newName: "visit_date");

            migrationBuilder.RenameColumn(
                name: "basic_information_plant_id",
                table: "visits",
                newName: "plant_id");

            migrationBuilder.RenameColumn(
                name: "basic_information_leader",
                table: "visits",
                newName: "leader");

            migrationBuilder.RenameColumn(
                name: "basic_information_laboratory_leader",
                table: "visits",
                newName: "laboratory_leader");

            migrationBuilder.RenameColumn(
                name: "basic_information_inspector",
                table: "visits",
                newName: "inspector");

            migrationBuilder.RenameColumn(
                name: "basic_information_created_at",
                table: "visits",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "basic_information_consultant",
                table: "visits",
                newName: "consultant");

            migrationBuilder.RenameColumn(
                name: "basic_information_association_id",
                table: "visits",
                newName: "association_id");

            migrationBuilder.RenameColumn(
                name: "analytical_balance_observations6",
                table: "visits",
                newName: "observations6");

            migrationBuilder.RenameColumn(
                name: "analytical_balance_observations5",
                table: "visits",
                newName: "observations5");

            migrationBuilder.RenameColumn(
                name: "analytical_balance_leveled_balance",
                table: "visits",
                newName: "leveled_balance");

            migrationBuilder.RenameColumn(
                name: "analytical_balance_homogeneous_weight",
                table: "visits",
                newName: "homogeneous_weight");

            migrationBuilder.RenameColumn(
                name: "analytical_balance_final_weight",
                table: "visits",
                newName: "final_weight");

            migrationBuilder.RenameColumn(
                name: "analytical_balance_calibration_certificate_balance",
                table: "visits",
                newName: "calibration_certificate_balance");

            migrationBuilder.RenameColumn(
                name: "analytical_balance_calibrated_balance",
                table: "visits",
                newName: "calibrated_balance");

            migrationBuilder.RenameColumn(
                name: "analytical_balance_average_ambient_temperature",
                table: "visits",
                newName: "average_ambient_temperature");

            migrationBuilder.RenameIndex(
                name: "IX_visits_basic_information_plant_id",
                table: "visits",
                newName: "IX_visits_plant_id");

            migrationBuilder.RenameIndex(
                name: "IX_visits_basic_information_association_id",
                table: "visits",
                newName: "IX_visits_association_id");

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
    }
}
