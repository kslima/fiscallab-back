using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FiscalLabService.Repository.PostgreSql.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "associations",
                columns: table => new
                {
                    id = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: false),
                    name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    Emails = table.Column<string>(type: "text", nullable: false),
                    city = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    state = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_associations", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "menus",
                columns: table => new
                {
                    id = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: false),
                    code = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    display_name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    page = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    has_percentage_options = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_menus", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "plants",
                columns: table => new
                {
                    id = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: false),
                    name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    cnpj = table.Column<string>(type: "character varying(14)", maxLength: 14, nullable: false),
                    address = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    state = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_plants", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "visit_pages",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", maxLength: 36, nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    display_name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_visit_pages", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "options",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    description = table.Column<string>(type: "text", nullable: false),
                    menu_id = table.Column<string>(type: "character varying(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_options", x => x.id);
                    table.ForeignKey(
                        name: "FK_options_menus_menu_id",
                        column: x => x.menu_id,
                        principalTable: "menus",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "visits",
                columns: table => new
                {
                    id = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: false),
                    basic_information_plant_id = table.Column<string>(type: "character varying(36)", nullable: false),
                    basic_information_association_id = table.Column<string>(type: "character varying(36)", nullable: false),
                    basic_information_consultant = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    basic_information_inspector = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    basic_information_leader = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    basic_information_laboratory_leader = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    basic_information_visit_date = table.Column<DateOnly>(type: "date", nullable: false),
                    basic_information_visit_time = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    sugarcane_balance_in_scale = table.Column<string>(type: "text", nullable: false),
                    sugarcane_balance_out_scale = table.Column<string>(type: "text", nullable: false),
                    sugarcane_balance_cargo_draw = table.Column<string>(type: "text", nullable: false),
                    sugarcane_balance_scale_observations = table.Column<string>(type: "text", nullable: false),
                    sugarcane_balance_calibration1 = table.Column<string>(type: "text", nullable: false),
                    sugarcane_balance_calibration2 = table.Column<string>(type: "text", nullable: false),
                    sugarcane_balance_responsible_body = table.Column<string>(type: "text", nullable: false),
                    sugarcane_balance_calibration_certificate = table.Column<string>(type: "text", nullable: false),
                    sugarcane_balance_observations1 = table.Column<string>(type: "text", nullable: false),
                    sugarcane_balance_plant_percentage = table.Column<string>(type: "text", nullable: false),
                    sugarcane_balance_provider_percentage = table.Column<string>(type: "text", nullable: false),
                    sugarcane_balance_plant_farm_percentage = table.Column<string>(type: "text", nullable: false),
                    sugarcane_balance_farm_provider_percentage = table.Column<string>(type: "text", nullable: false),
                    sugarcane_balance_observations2 = table.Column<string>(type: "text", nullable: false),
                    desintegrator_probe_probe_type = table.Column<string>(type: "text", nullable: false),
                    desintegrator_probe_tube_inserted = table.Column<string>(type: "text", nullable: false),
                    desintegrator_probe_tube_discharged = table.Column<string>(type: "text", nullable: false),
                    desintegrator_probe_collect = table.Column<string>(type: "text", nullable: false),
                    desintegrator_probe_sample_amount = table.Column<string>(type: "text", nullable: false),
                    desintegrator_probe_broth_extraction = table.Column<string>(type: "text", nullable: false),
                    desintegrator_probe_load_position = table.Column<string>(type: "text", nullable: false),
                    desintegrator_probe_toothed_crown = table.Column<string>(type: "text", nullable: false),
                    desintegrator_probe_toothed_crown_type = table.Column<string>(type: "text", nullable: false),
                    desintegrator_probe_last_crown_change = table.Column<string>(type: "text", nullable: false),
                    desintegrator_probe_observations3 = table.Column<string>(type: "text", nullable: false),
                    desintegrator_probe_homogeneous_samples = table.Column<string>(type: "text", nullable: false),
                    desintegrator_probe_knife_conservation = table.Column<string>(type: "text", nullable: false),
                    desintegrator_probe_against_knife_conservation = table.Column<string>(type: "text", nullable: false),
                    desintegrator_probe_knife_against_knife_distance = table.Column<string>(type: "text", nullable: false),
                    desintegrator_probe_hammer_conservation = table.Column<string>(type: "text", nullable: false),
                    desintegrator_probe_clean_mixer = table.Column<string>(type: "text", nullable: false),
                    desintegrator_probe_desintegrator_rpm = table.Column<string>(type: "text", nullable: false),
                    desintegrator_probe_preparation_index = table.Column<string>(type: "text", nullable: false),
                    desintegrator_probe_sharpened_or_replaced_knife_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    desintegrator_probe_observations4 = table.Column<string>(type: "text", nullable: false),
                    analytical_balance_homogeneous_weight = table.Column<string>(type: "text", nullable: false),
                    analytical_balance_final_weight = table.Column<string>(type: "text", nullable: false),
                    analytical_balance_calibrated_balance = table.Column<string>(type: "text", nullable: false),
                    analytical_balance_leveled_balance = table.Column<string>(type: "text", nullable: false),
                    analytical_balance_calibration_certificate_balance = table.Column<string>(type: "text", nullable: false),
                    analytical_balance_observations5 = table.Column<string>(type: "text", nullable: false),
                    analytical_balance_average_ambient_temperature = table.Column<string>(type: "text", nullable: false),
                    analytical_balance_observations6 = table.Column<string>(type: "text", nullable: false),
                    press_refractometer_pressure_gauge_certificated = table.Column<string>(type: "text", nullable: false),
                    press_refractometer_discard_cup = table.Column<string>(type: "text", nullable: false),
                    press_refractometer_collector_bottle = table.Column<string>(type: "text", nullable: false),
                    press_refractometer_pressure = table.Column<string>(type: "text", nullable: false),
                    press_refractometer_timer = table.Column<string>(type: "text", nullable: false),
                    press_refractometer_press_cleaning = table.Column<string>(type: "text", nullable: false),
                    press_refractometer_observations7 = table.Column<string>(type: "text", nullable: false),
                    press_refractometer_broth_homogenization = table.Column<string>(type: "text", nullable: false),
                    press_refractometer_refractometer_calibration_certificate = table.Column<string>(type: "text", nullable: false),
                    press_refractometer_precision_reading = table.Column<string>(type: "text", nullable: false),
                    press_refractometer_refractometer_benchmarking = table.Column<string>(type: "text", nullable: false),
                    press_refractometer_refractometer_cleaning = table.Column<string>(type: "text", nullable: false),
                    press_refractometer_internal_temperature = table.Column<string>(type: "text", nullable: false),
                    press_refractometer_observations8 = table.Column<string>(type: "text", nullable: false),
                    clarification_saccharimeter_bottle = table.Column<string>(type: "text", nullable: false),
                    clarification_saccharimeter_agitation = table.Column<string>(type: "text", nullable: false),
                    clarification_saccharimeter_has_dilution = table.Column<string>(type: "text", nullable: false),
                    clarification_saccharimeter_clarifier = table.Column<string>(type: "text", nullable: false),
                    clarification_saccharimeter_pressure = table.Column<string>(type: "text", nullable: false),
                    clarification_saccharimeter_clarifier_amount = table.Column<string>(type: "text", nullable: false),
                    clarification_saccharimeter_bottle_clarified_volume = table.Column<string>(type: "text", nullable: false),
                    clarification_saccharimeter_bottle_after_clarified_volume = table.Column<string>(type: "text", nullable: false),
                    clarification_saccharimeter_observations9 = table.Column<string>(type: "text", nullable: false),
                    clarification_saccharimeter_stabilization = table.Column<string>(type: "text", nullable: false),
                    clarification_saccharimeter_benchmarking = table.Column<string>(type: "text", nullable: false),
                    clarification_saccharimeter_quartz_pattern = table.Column<string>(type: "text", nullable: false),
                    clarification_saccharimeter_quartz_result = table.Column<string>(type: "text", nullable: false),
                    clarification_saccharimeter_quartz_reading = table.Column<string>(type: "text", nullable: false),
                    clarification_saccharimeter_calibration_certificate = table.Column<string>(type: "text", nullable: false),
                    clarification_saccharimeter_tube_cleaning = table.Column<string>(type: "text", nullable: false),
                    clarification_saccharimeter_clear_colling_cooler = table.Column<string>(type: "text", nullable: false),
                    clarification_saccharimeter_observations10 = table.Column<string>(type: "text", nullable: false),
                    benchmarking_equipment_load_cell = table.Column<string>(type: "text", nullable: false),
                    benchmarking_equipment_thermometer = table.Column<string>(type: "text", nullable: false),
                    benchmarking_equipment_tachometer = table.Column<string>(type: "text", nullable: false),
                    benchmarking_equipment_pachymeter = table.Column<string>(type: "text", nullable: false),
                    benchmarking_equipment_gm500 = table.Column<string>(type: "text", nullable: false),
                    benchmarking_equipment_gm100 = table.Column<string>(type: "text", nullable: false),
                    benchmarking_equipment_gm1 = table.Column<string>(type: "text", nullable: false),
                    benchmarking_equipment_sucrose_test = table.Column<string>(type: "text", nullable: false),
                    benchmarking_equipment_range10 = table.Column<string>(type: "text", nullable: false),
                    benchmarking_equipment_range20 = table.Column<string>(type: "text", nullable: false),
                    benchmarking_equipment_range30 = table.Column<string>(type: "text", nullable: false),
                    benchmarking_equipment_z25 = table.Column<string>(type: "text", nullable: false),
                    benchmarking_equipment_z50 = table.Column<string>(type: "text", nullable: false),
                    benchmarking_equipment_z75 = table.Column<string>(type: "text", nullable: false),
                    benchmarking_equipment_z100 = table.Column<string>(type: "text", nullable: false),
                    benchmarking_equipment_observations11 = table.Column<string>(type: "text", nullable: false),
                    benchmarking_equipment_expected_crop = table.Column<decimal>(type: "numeric", nullable: false),
                    benchmarking_equipment_accomplished_crop = table.Column<decimal>(type: "numeric", nullable: false),
                    benchmarking_equipment_previous_crop = table.Column<decimal>(type: "numeric", nullable: false),
                    benchmarking_equipment_percentage_realized = table.Column<decimal>(type: "numeric", nullable: false),
                    benchmarking_equipment_variation_between_crops = table.Column<decimal>(type: "numeric", nullable: false),
                    benchmarking_equipment_current_fiber = table.Column<decimal>(type: "numeric", nullable: false),
                    benchmarking_equipment_previous_fiber = table.Column<decimal>(type: "numeric", nullable: false),
                    benchmarking_equipment_fiber_variation = table.Column<decimal>(type: "numeric", nullable: false),
                    benchmarking_equipment_current_atr = table.Column<decimal>(type: "numeric", nullable: false),
                    benchmarking_equipment_previous_atr = table.Column<decimal>(type: "numeric", nullable: false),
                    benchmarking_equipment_atr_variation = table.Column<decimal>(type: "numeric", nullable: false),
                    benchmarking_equipment_observations12 = table.Column<string>(type: "text", nullable: false),
                    system_consistency_oc = table.Column<string>(type: "text", nullable: false),
                    system_consistency_farm = table.Column<string>(type: "text", nullable: false),
                    system_consistency_owner = table.Column<string>(type: "text", nullable: false),
                    system_consistency_clarifier = table.Column<string>(type: "text", nullable: true),
                    system_consistency_plant_pbu = table.Column<decimal>(type: "numeric", nullable: false),
                    system_consistency_plant_brix = table.Column<decimal>(type: "numeric", nullable: false),
                    system_consistency_plant_ls = table.Column<decimal>(type: "numeric", nullable: false),
                    system_consistency_plant_purity = table.Column<decimal>(type: "numeric", nullable: false),
                    system_consistency_plant_pol = table.Column<decimal>(type: "numeric", nullable: false),
                    system_consistency_plant_fiber = table.Column<decimal>(type: "numeric", nullable: false),
                    system_consistency_plant_pcc = table.Column<decimal>(type: "numeric", nullable: false),
                    system_consistency_plant_ar = table.Column<decimal>(type: "numeric", nullable: false),
                    system_consistency_plant_atr = table.Column<decimal>(type: "numeric", nullable: false),
                    system_consistency_consecana_pbu = table.Column<decimal>(type: "numeric", nullable: false),
                    system_consistency_consecana_brix = table.Column<decimal>(type: "numeric", nullable: false),
                    system_consistency_consecana_ls = table.Column<decimal>(type: "numeric", nullable: false),
                    system_consistency_consecana_purity = table.Column<decimal>(type: "numeric", nullable: false),
                    system_consistency_consecana_pol = table.Column<decimal>(type: "numeric", nullable: false),
                    system_consistency_consecana_fiber = table.Column<decimal>(type: "numeric", nullable: false),
                    system_consistency_consecana_pcc = table.Column<decimal>(type: "numeric", nullable: false),
                    system_consistency_consecana_ar = table.Column<decimal>(type: "numeric", nullable: false),
                    system_consistency_consecana_atr = table.Column<decimal>(type: "numeric", nullable: false),
                    system_consistency_difference_purity = table.Column<decimal>(type: "numeric", nullable: false),
                    system_consistency_difference_pol = table.Column<decimal>(type: "numeric", nullable: false),
                    system_consistency_difference_fiber = table.Column<decimal>(type: "numeric", nullable: false),
                    system_consistency_difference_pcc = table.Column<decimal>(type: "numeric", nullable: false),
                    system_consistency_difference_ar = table.Column<decimal>(type: "numeric", nullable: false),
                    system_consistency_difference_atr = table.Column<decimal>(type: "numeric", nullable: false),
                    system_consistency_observations = table.Column<string>(type: "text", nullable: false),
                    conclusion_inspector_performance = table.Column<string>(type: "text", nullable: false),
                    conclusion_laboratory_receptivity = table.Column<string>(type: "text", nullable: false),
                    conclusion_pendencies = table.Column<string>(type: "text", nullable: false),
                    conclusion_conclusion_observations = table.Column<string>(type: "text", nullable: false),
                    is_finished = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    finished_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    synced_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    sent_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_visits", x => x.id);
                    table.ForeignKey(
                        name: "FK_visits_associations_basic_information_association_id",
                        column: x => x.basic_information_association_id,
                        principalTable: "associations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_visits_plants_basic_information_plant_id",
                        column: x => x.basic_information_plant_id,
                        principalTable: "plants",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "visit_images",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    url = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    visit_id = table.Column<string>(type: "character varying(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_visit_images", x => x.id);
                    table.ForeignKey(
                        name: "FK_visit_images_visits_visit_id",
                        column: x => x.visit_id,
                        principalTable: "visits",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "visit_pages",
                columns: new[] { "id", "display_name", "name" },
                values: new object[,]
                {
                    { 1, "Principal", "Main" },
                    { 2, "Balança de Cana", "SugarcaneBalance" },
                    { 3, "Sonda/Desintegrador", "DesintegratorProbe" },
                    { 4, "Balança Analítica/Temperatura", "AnalyticalBalance" },
                    { 5, "Prensa/Refratômetro", "PressRefractometer" },
                    { 6, "Clarificação/Sacarímetro", "ClarificationSaccharimeter" },
                    { 7, "Equipamentos de Aferição/Medias", "BenchmarkingEquipment" },
                    { 8, "Consistência do Sistema", "SystemConsistency" },
                    { 9, "Conclusão", "Conclusion" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_options_menu_id",
                table: "options",
                column: "menu_id");

            migrationBuilder.CreateIndex(
                name: "IX_visit_images_visit_id",
                table: "visit_images",
                column: "visit_id");

            migrationBuilder.CreateIndex(
                name: "IX_visits_basic_information_association_id",
                table: "visits",
                column: "basic_information_association_id");

            migrationBuilder.CreateIndex(
                name: "IX_visits_basic_information_plant_id",
                table: "visits",
                column: "basic_information_plant_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "options");

            migrationBuilder.DropTable(
                name: "visit_images");

            migrationBuilder.DropTable(
                name: "visit_pages");

            migrationBuilder.DropTable(
                name: "menus");

            migrationBuilder.DropTable(
                name: "visits");

            migrationBuilder.DropTable(
                name: "associations");

            migrationBuilder.DropTable(
                name: "plants");
        }
    }
}
