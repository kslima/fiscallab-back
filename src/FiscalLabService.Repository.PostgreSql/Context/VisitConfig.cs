using FiscalLabService.Domain.Entities;
using FiscalLabService.Repository.PostgreSql.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FiscalLabService.Repository.PostgreSql.Context;

public class VisitConfig : IEntityTypeConfiguration<Visit>
{
    public void Configure(EntityTypeBuilder<Visit> builder)
    {
        builder.ToTable("visits"); 
        
        builder.HasKey(p => p.Id);
        
        builder.Property(p => p.Id)
            .IsRequired()
            .HasColumnName("id")
            .HasMaxLength(36);
        
        builder.Property(p => p.Status)
            .HasColumnName("status")
            .HasConversion<string>()
            .HasMaxLength(16);
        
        builder.Property(p => p.CreatedAt)
            .IsRequired()
            .HasColumnName("created_at");
        
        builder.Property(p => p.FinishedAt)
            .HasColumnName("finished_at")
            .HasConversion(PostgresHelper.DateTimeToUtcConverter());
        
        builder.Property(p => p.SyncedAt)
            .HasColumnName("synced_at")
            .HasConversion(PostgresHelper.DateTimeToUtcConverter());
        
        builder.Property(p => p.NotifiedByEmailAt)
            .HasColumnName("notified_by_email_at")
            .HasConversion(PostgresHelper.DateTimeToUtcConverter());
        
        builder.Property(p => p.NotifyByEmail)
            .IsRequired()
            .HasColumnName("notify_by_email");
        
        builder
            .OwnsMany(a => a.Images, image =>
            {
                image.ToTable("visit_images");
                
                image
                    .WithOwner()
                    .HasForeignKey("visit_id");
                
                image.Property<int>("id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("integer")
                    .UseIdentityByDefaultColumn();
                
                image.HasKey("id");
                
                image.Property(e => e.Name)
                    .HasColumnName("name")
                    .IsRequired();
                
                image.Property(e => e.Url)
                    .HasColumnName("url")
                    .IsRequired();
                
                image.Property(e => e.Description)
                    .HasColumnName("description")
                    .IsRequired();
            });

        builder
            .OwnsMany(a => a.BalanceTests, balanceTest =>
            {
                balanceTest.ToTable("visit_balance_tests");
                
                balanceTest
                    .WithOwner()
                    .HasForeignKey("visit_id");
                
                balanceTest.Property<int>("id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("integer")
                    .UseIdentityByDefaultColumn();
                
                balanceTest.HasKey("id");
                
                balanceTest.Property(e => e.Identification)
                    .HasColumnName("identification")
                    .IsRequired();
                
                balanceTest.Property(e => e.InputBalanceWeight)
                    .HasColumnName("input_balance_weight")
                    .IsRequired();
                
                balanceTest.Property(e => e.OutputBalanceWeight)
                    .HasColumnName("output_balance_weight")
                    .IsRequired();
            });
        
        builder.OwnsOne(v => v.BasicInformation,
            navigationBuilder =>
            {
                navigationBuilder
                    .Property(x => x.PlantId)
                    .HasColumnName("basic_information_plant_id");

                navigationBuilder
                    .HasOne(v => v.Plant)
                    .WithMany()
                    .HasForeignKey(v => v.PlantId);

                navigationBuilder
                    .Property(x => x.AssociationId)
                    .HasColumnName("basic_information_association_id");

                navigationBuilder
                    .HasOne(v => v.Association)
                    .WithMany()
                    .HasForeignKey(v => v.AssociationId);

                navigationBuilder.Property(p => p.Consultant)
                    .IsRequired()
                    .HasColumnName("basic_information_consultant")
                    .HasMaxLength(128);

                navigationBuilder.Property(p => p.Inspector)
                    .IsRequired()
                    .HasColumnName("basic_information_inspector")
                    .HasMaxLength(128);

                navigationBuilder.Property(p => p.Inspector)
                    .IsRequired()
                    .HasColumnName("basic_information_inspector")
                    .HasMaxLength(128);

                navigationBuilder.Property(p => p.Leader)
                    .IsRequired()
                    .HasColumnName("basic_information_leader")
                    .HasMaxLength(128);

                navigationBuilder.Property(p => p.LaboratoryLeader)
                    .IsRequired()
                    .HasColumnName("basic_information_laboratory_leader")
                    .HasMaxLength(128);

                navigationBuilder.Property(p => p.VisitDate)
                    .IsRequired()
                    .HasColumnName("basic_information_visit_date");

                navigationBuilder.Property(p => p.VisitTime)
                    .IsRequired()
                    .HasColumnName("basic_information_visit_time");
            });

        builder.OwnsOne(v => v.SugarcaneBalance,
            navigationBuilder =>
            {
                navigationBuilder.Property(p => p.InScale)
                    .IsRequired()
                    .HasColumnName("sugarcane_balance_in_scale");

                navigationBuilder.Property(p => p.OutScale)
                    .IsRequired()
                    .HasColumnName("sugarcane_balance_out_scale");

                navigationBuilder.Property(p => p.CargoDraw)
                    .IsRequired()
                    .HasColumnName("sugarcane_balance_cargo_draw");

                navigationBuilder.Property(p => p.ScaleObservations)
                    .IsRequired()
                    .HasColumnName("sugarcane_balance_scale_observations");

                navigationBuilder.Property(p => p.Calibration1)
                    .IsRequired()
                    .HasColumnName("sugarcane_balance_calibration1");

                navigationBuilder.Property(p => p.Calibration2)
                    .IsRequired()
                    .HasColumnName("sugarcane_balance_calibration2");

                navigationBuilder.Property(p => p.ResponsibleBody)
                    .IsRequired()
                    .HasColumnName("sugarcane_balance_responsible_body");

                navigationBuilder.Property(p => p.CalibrationCertificate)
                    .IsRequired()
                    .HasColumnName("sugarcane_balance_calibration_certificate");

                navigationBuilder.Property(p => p.Observations1)
                    .IsRequired()
                    .HasColumnName("sugarcane_balance_observations1");

                navigationBuilder.Property(p => p.PlantPercentage)
                    .IsRequired()
                    .HasColumnName("sugarcane_balance_plant_percentage");

                navigationBuilder.Property(p => p.ProviderPercentage)
                    .IsRequired()
                    .HasColumnName("sugarcane_balance_provider_percentage");

                navigationBuilder.Property(p => p.PlantFarmPercentage)
                    .IsRequired()
                    .HasColumnName("sugarcane_balance_plant_farm_percentage");

                navigationBuilder.Property(p => p.FarmProviderPercentage)
                    .IsRequired()
                    .HasColumnName("sugarcane_balance_farm_provider_percentage");

                navigationBuilder.Property(p => p.Observations2)
                    .IsRequired()
                    .HasColumnName("sugarcane_balance_observations2");
            });

        builder.OwnsOne(v => v.DesintegratorProbe,
            navigationBuilder =>
            {
                navigationBuilder
                    .Property(p => p.ProbeType)
                    .IsRequired()
                    .HasColumnName("desintegrator_probe_probe_type");

                navigationBuilder
                    .Property(p => p.TubeInserted)
                    .IsRequired()
                    .HasColumnName("desintegrator_probe_tube_inserted");

                navigationBuilder
                    .Property(p => p.TubeDischarged)
                    .IsRequired()
                    .HasColumnName("desintegrator_probe_tube_discharged");

                navigationBuilder
                    .Property(p => p.Collect)
                    .IsRequired()
                    .HasColumnName("desintegrator_probe_collect");

                navigationBuilder
                    .Property(p => p.SampleAmount)
                    .IsRequired()
                    .HasColumnName("desintegrator_probe_sample_amount");

                navigationBuilder
                    .Property(p => p.BrothExtraction)
                    .IsRequired()
                    .HasColumnName("desintegrator_probe_broth_extraction");

                navigationBuilder
                    .Property(p => p.LoadPosition)
                    .IsRequired()
                    .HasColumnName("desintegrator_probe_load_position");

                navigationBuilder
                    .Property(p => p.ToothedCrown)
                    .IsRequired()
                    .HasColumnName("desintegrator_probe_toothed_crown");

                navigationBuilder
                    .Property(p => p.ToothedCrownType)
                    .IsRequired()
                    .HasColumnName("desintegrator_probe_toothed_crown_type");

                navigationBuilder
                    .Property(p => p.LastCrownChange)
                    .IsRequired()
                    .HasColumnName("desintegrator_probe_last_crown_change");

                navigationBuilder
                    .Property(p => p.Observations3)
                    .IsRequired()
                    .HasColumnName("desintegrator_probe_observations3");

                navigationBuilder
                    .Property(p => p.HomogeneousSamples)
                    .IsRequired()
                    .HasColumnName("desintegrator_probe_homogeneous_samples");

                navigationBuilder
                    .Property(p => p.KnifeConservation)
                    .IsRequired()
                    .HasColumnName("desintegrator_probe_knife_conservation");

                navigationBuilder
                    .Property(p => p.AgainstKnifeConservation)
                    .IsRequired()
                    .HasColumnName("desintegrator_probe_against_knife_conservation");

                navigationBuilder
                    .Property(p => p.KnifeAgainstKnifeDistance)
                    .IsRequired()
                    .HasColumnName("desintegrator_probe_knife_against_knife_distance");

                navigationBuilder
                    .Property(p => p.HammerConservation)
                    .IsRequired()
                    .HasColumnName("desintegrator_probe_hammer_conservation");

                navigationBuilder
                    .Property(p => p.CleanMixer)
                    .IsRequired()
                    .HasColumnName("desintegrator_probe_clean_mixer");

                navigationBuilder
                    .Property(p => p.DesintegratorRpm)
                    .IsRequired()
                    .HasColumnName("desintegrator_probe_desintegrator_rpm");

                navigationBuilder
                    .Property(p => p.PreparationIndex)
                    .IsRequired()
                    .HasColumnName("desintegrator_probe_preparation_index");

                navigationBuilder
                    .Property(p => p.SharpenedOrReplacedKnifeAt)
                    .HasColumnName("desintegrator_probe_sharpened_or_replaced_knife_at")
                    .HasConversion(PostgresHelper.DateTimeToUtcConverter());

                navigationBuilder
                    .Property(p => p.Observations4)
                    .IsRequired()
                    .HasColumnName("desintegrator_probe_observations4");
            });

        builder.OwnsOne(v => v.AnalyticalBalance,
            navigationBuilder =>
            {
                navigationBuilder
                    .Property(p => p.HomogeneousWeight)
                    .IsRequired()
                    .HasColumnName("analytical_balance_homogeneous_weight");

                navigationBuilder
                    .Property(p => p.FinalWeight)
                    .IsRequired()
                    .HasColumnName("analytical_balance_final_weight");

                navigationBuilder
                    .Property(p => p.CalibratedBalance)
                    .IsRequired()
                    .HasColumnName("analytical_balance_calibrated_balance");

                navigationBuilder
                    .Property(p => p.LeveledBalance)
                    .IsRequired()
                    .HasColumnName("analytical_balance_leveled_balance");

                navigationBuilder
                    .Property(p => p.CalibrationCertificateBalance)
                    .IsRequired()
                    .HasColumnName("analytical_balance_calibration_certificate_balance");

                navigationBuilder
                    .Property(p => p.Observations5)
                    .IsRequired()
                    .HasColumnName("analytical_balance_observations5");

                navigationBuilder
                    .Property(p => p.AverageAmbientTemperature)
                    .IsRequired()
                    .HasColumnName("analytical_balance_average_ambient_temperature");

                navigationBuilder
                    .Property(p => p.Observations6)
                    .IsRequired()
                    .HasColumnName("analytical_balance_observations6");
            });

        builder.OwnsOne(v => v.PressRefractometer,
            navigationBuilder =>
            {
                navigationBuilder
                    .Property(p => p.PressureGaugeCertificated)
                    .IsRequired()
                    .HasColumnName("press_refractometer_pressure_gauge_certificated");

                navigationBuilder
                    .Property(p => p.DiscardCup)
                    .IsRequired()
                    .HasColumnName("press_refractometer_discard_cup");

                navigationBuilder
                    .Property(p => p.CollectorBottle)
                    .IsRequired()
                    .HasColumnName("press_refractometer_collector_bottle");

                navigationBuilder
                    .Property(p => p.Pressure)
                    .IsRequired()
                    .HasColumnName("press_refractometer_pressure");

                navigationBuilder
                    .Property(p => p.Timer)
                    .IsRequired()
                    .HasColumnName("press_refractometer_timer");

                navigationBuilder
                    .Property(p => p.PressCleaning)
                    .IsRequired()
                    .HasColumnName("press_refractometer_press_cleaning");

                navigationBuilder
                    .Property(p => p.Observations7)
                    .IsRequired()
                    .HasColumnName("press_refractometer_observations7");

                navigationBuilder
                    .Property(p => p.BrothHomogenization)
                    .IsRequired()
                    .HasColumnName("press_refractometer_broth_homogenization");

                navigationBuilder
                    .Property(p => p.RefractometerCalibrationCertificate)
                    .IsRequired()
                    .HasColumnName("press_refractometer_refractometer_calibration_certificate");

                navigationBuilder
                    .Property(p => p.PrecisionReading)
                    .IsRequired()
                    .HasColumnName("press_refractometer_precision_reading");

                navigationBuilder
                    .Property(p => p.RefractometerBenchmarking)
                    .IsRequired()
                    .HasColumnName("press_refractometer_refractometer_benchmarking");

                navigationBuilder
                    .Property(p => p.RefractometerCleaning)
                    .IsRequired()
                    .HasColumnName("press_refractometer_refractometer_cleaning");

                navigationBuilder
                    .Property(p => p.InternalTemperature)
                    .IsRequired()
                    .HasColumnName("press_refractometer_internal_temperature");

                navigationBuilder
                    .Property(p => p.Observations8)
                    .IsRequired()
                    .HasColumnName("press_refractometer_observations8");
            });

        builder.OwnsOne(v => v.ClarificationSaccharimeter,
            navigationBuilder =>
            {
                navigationBuilder
                    .Property(p => p.Bottle)
                    .IsRequired()
                    .HasColumnName("clarification_saccharimeter_bottle");

                navigationBuilder
                    .Property(p => p.Agitation)
                    .IsRequired()
                    .HasColumnName("clarification_saccharimeter_agitation");

                navigationBuilder
                    .Property(p => p.HasDilution)
                    .IsRequired()
                    .HasColumnName("clarification_saccharimeter_has_dilution");

                navigationBuilder
                    .Property(p => p.Clarifier)
                    .IsRequired()
                    .HasColumnName("clarification_saccharimeter_clarifier");

                navigationBuilder
                    .Property(p => p.Pressure)
                    .IsRequired()
                    .HasColumnName("clarification_saccharimeter_pressure");

                navigationBuilder
                    .Property(p => p.ClarifierAmount)
                    .IsRequired()
                    .HasColumnName("clarification_saccharimeter_clarifier_amount");

                navigationBuilder
                    .Property(p => p.BottleClarifiedVolume)
                    .IsRequired()
                    .HasColumnName("clarification_saccharimeter_bottle_clarified_volume");

                navigationBuilder
                    .Property(p => p.BottleAfterClarifiedVolume)
                    .IsRequired()
                    .HasColumnName("clarification_saccharimeter_bottle_after_clarified_volume");

                navigationBuilder
                    .Property(p => p.Observations9)
                    .IsRequired()
                    .HasColumnName("clarification_saccharimeter_observations9");

                navigationBuilder
                    .Property(p => p.Stabilization)
                    .IsRequired()
                    .HasColumnName("clarification_saccharimeter_stabilization");

                navigationBuilder
                    .Property(p => p.Benchmarking)
                    .IsRequired()
                    .HasColumnName("clarification_saccharimeter_benchmarking");

                navigationBuilder
                    .Property(p => p.QuartzPattern)
                    .IsRequired()
                    .HasColumnName("clarification_saccharimeter_quartz_pattern");

                navigationBuilder
                    .Property(p => p.QuartzResult)
                    .IsRequired()
                    .HasColumnName("clarification_saccharimeter_quartz_result");

                navigationBuilder
                    .Property(p => p.QuartzReading)
                    .IsRequired()
                    .HasColumnName("clarification_saccharimeter_quartz_reading");

                navigationBuilder
                    .Property(p => p.CalibrationCertificate)
                    .IsRequired()
                    .HasColumnName("clarification_saccharimeter_calibration_certificate");

                navigationBuilder
                    .Property(p => p.TubeCleaning)
                    .IsRequired()
                    .HasColumnName("clarification_saccharimeter_tube_cleaning");

                navigationBuilder
                    .Property(p => p.ClearCollingCooler)
                    .IsRequired()
                    .HasColumnName("clarification_saccharimeter_clear_colling_cooler");

                navigationBuilder
                    .Property(p => p.Observations10)
                    .IsRequired()
                    .HasColumnName("clarification_saccharimeter_observations10");
            });

        builder.OwnsOne(v => v.BenchmarkingEquipment,
            navigationBuilder =>
            {
                navigationBuilder
                    .Property(p => p.LoadCell)
                    .IsRequired()
                    .HasColumnName("benchmarking_equipment_load_cell");

                navigationBuilder
                    .Property(p => p.Thermometer)
                    .IsRequired()
                    .HasColumnName("benchmarking_equipment_thermometer");

                navigationBuilder
                    .Property(p => p.Tachometer)
                    .IsRequired()
                    .HasColumnName("benchmarking_equipment_tachometer");

                navigationBuilder
                    .Property(p => p.Pachymeter)
                    .IsRequired()
                    .HasColumnName("benchmarking_equipment_pachymeter");

                navigationBuilder
                    .Property(p => p.Gm500)
                    .IsRequired()
                    .HasColumnName("benchmarking_equipment_gm500");

                navigationBuilder
                    .Property(p => p.Gm100)
                    .IsRequired()
                    .HasColumnName("benchmarking_equipment_gm100");

                navigationBuilder
                    .Property(p => p.Gm1)
                    .IsRequired()
                    .HasColumnName("benchmarking_equipment_gm1");

                navigationBuilder
                    .Property(p => p.SucroseTest)
                    .IsRequired()
                    .HasColumnName("benchmarking_equipment_sucrose_test");

                navigationBuilder
                    .Property(p => p.Range10)
                    .IsRequired()
                    .HasColumnName("benchmarking_equipment_range10");

                navigationBuilder
                    .Property(p => p.Range20)
                    .IsRequired()
                    .HasColumnName("benchmarking_equipment_range20");

                navigationBuilder
                    .Property(p => p.Range30)
                    .IsRequired()
                    .HasColumnName("benchmarking_equipment_range30");

                navigationBuilder
                    .Property(p => p.Z25)
                    .IsRequired()
                    .HasColumnName("benchmarking_equipment_z25");

                navigationBuilder
                    .Property(p => p.Z50)
                    .IsRequired()
                    .HasColumnName("benchmarking_equipment_z50");

                navigationBuilder
                    .Property(p => p.Z75)
                    .IsRequired()
                    .HasColumnName("benchmarking_equipment_z75");

                navigationBuilder
                    .Property(p => p.Z100)
                    .IsRequired()
                    .HasColumnName("benchmarking_equipment_z100");

                navigationBuilder
                    .Property(p => p.Observations11)
                    .IsRequired()
                    .HasColumnName("benchmarking_equipment_observations11");

                navigationBuilder
                    .Property(p => p.ExpectedCrop)
                    .IsRequired()
                    .HasColumnName("benchmarking_equipment_expected_crop");

                navigationBuilder
                    .Property(p => p.AccomplishedCrop)
                    .IsRequired()
                    .HasColumnName("benchmarking_equipment_accomplished_crop");

                navigationBuilder
                    .Property(p => p.PreviousCrop)
                    .IsRequired()
                    .HasColumnName("benchmarking_equipment_previous_crop");

                navigationBuilder
                    .Property(p => p.PercentageRealized)
                    .IsRequired()
                    .HasColumnName("benchmarking_equipment_percentage_realized");

                navigationBuilder
                    .Property(p => p.VariationBetweenCrops)
                    .IsRequired()
                    .HasColumnName("benchmarking_equipment_variation_between_crops");

                navigationBuilder
                    .Property(p => p.CurrentFiber)
                    .IsRequired()
                    .HasColumnName("benchmarking_equipment_current_fiber");

                navigationBuilder
                    .Property(p => p.PreviousFiber)
                    .IsRequired()
                    .HasColumnName("benchmarking_equipment_previous_fiber");

                navigationBuilder
                    .Property(p => p.FiberVariation)
                    .IsRequired()
                    .HasColumnName("benchmarking_equipment_fiber_variation");

                navigationBuilder
                    .Property(p => p.CurrentAtr)
                    .IsRequired()
                    .HasColumnName("benchmarking_equipment_current_atr");

                navigationBuilder
                    .Property(p => p.PreviousAtr)
                    .IsRequired()
                    .HasColumnName("benchmarking_equipment_previous_atr");

                navigationBuilder
                    .Property(p => p.AtrVariation)
                    .IsRequired()
                    .HasColumnName("benchmarking_equipment_atr_variation");

                navigationBuilder
                    .Property(p => p.Observations12)
                    .IsRequired()
                    .HasColumnName("benchmarking_equipment_observations12");
            });

        builder.OwnsOne(v => v.SystemConsistency,
            navigationBuilder =>
            {
                navigationBuilder
                    .Property(p => p.Oc)
                    .IsRequired()
                    .HasColumnName("system_consistency_oc");

                navigationBuilder
                    .Property(p => p.Farm)
                    .IsRequired()
                    .HasColumnName("system_consistency_farm");

                navigationBuilder
                    .Property(p => p.Owner)
                    .IsRequired()
                    .HasColumnName("system_consistency_owner");

                navigationBuilder
                    .Property(p => p.Clarifier)
                    .HasConversion<string>()
                    .HasColumnName("system_consistency_clarifier");

                navigationBuilder.OwnsOne(v => v.PlantSugarcaneAnalysis,
                    nb =>
                    {
                        nb
                            .Property(p => p.Pbu)
                            .IsRequired()
                            .HasColumnName("system_consistency_plant_pbu");

                        nb
                            .Property(p => p.Brix)
                            .IsRequired()
                            .HasColumnName("system_consistency_plant_brix");
                        
                        nb
                            .Property(p => p.Ls)
                            .IsRequired()
                            .HasColumnName("system_consistency_plant_ls");
                        
                        nb
                            .Property(p => p.Purity)
                            .IsRequired()
                            .HasColumnName("system_consistency_plant_purity");
                        
                        nb
                            .Property(p => p.Pol)
                            .IsRequired()
                            .HasColumnName("system_consistency_plant_pol");
                        
                        nb
                            .Property(p => p.Fiber)
                            .IsRequired()
                            .HasColumnName("system_consistency_plant_fiber");
                        
                        nb
                            .Property(p => p.Pcc)
                            .IsRequired()
                            .HasColumnName("system_consistency_plant_pcc");
                        
                        nb
                            .Property(p => p.Ar)
                            .IsRequired()
                            .HasColumnName("system_consistency_plant_ar");
                        
                        nb
                            .Property(p => p.Atr)
                            .IsRequired()
                            .HasColumnName("system_consistency_plant_atr");
                    });
                
                navigationBuilder.OwnsOne(v => v.ConsecanaSugarcaneAnalysis,
                    nb =>
                    {
                        nb
                            .Property(p => p.Pbu)
                            .IsRequired()
                            .HasColumnName("system_consistency_consecana_pbu");

                        nb
                            .Property(p => p.Brix)
                            .IsRequired()
                            .HasColumnName("system_consistency_consecana_brix");
                        
                        nb
                            .Property(p => p.Ls)
                            .IsRequired()
                            .HasColumnName("system_consistency_consecana_ls");
                        
                        nb
                            .Property(p => p.Purity)
                            .IsRequired()
                            .HasColumnName("system_consistency_consecana_purity");
                        
                        nb
                            .Property(p => p.Pol)
                            .IsRequired()
                            .HasColumnName("system_consistency_consecana_pol");
                        
                        nb
                            .Property(p => p.Fiber)
                            .IsRequired()
                            .HasColumnName("system_consistency_consecana_fiber");
                        
                        nb
                            .Property(p => p.Pcc)
                            .IsRequired()
                            .HasColumnName("system_consistency_consecana_pcc");
                        
                        nb
                            .Property(p => p.Ar)
                            .IsRequired()
                            .HasColumnName("system_consistency_consecana_ar");
                        
                        nb
                            .Property(p => p.Atr)
                            .IsRequired()
                            .HasColumnName("system_consistency_consecana_atr");
                    });

                
                navigationBuilder
                    .Property(p => p.DifferencePurity)
                    .IsRequired()
                    .HasColumnName("system_consistency_difference_purity");
                
                navigationBuilder
                    .Property(p => p.DifferencePol)
                    .IsRequired()
                    .HasColumnName("system_consistency_difference_pol");
                
                navigationBuilder
                    .Property(p => p.DifferenceFiber)
                    .IsRequired()
                    .HasColumnName("system_consistency_difference_fiber");
                
                navigationBuilder
                    .Property(p => p.DifferencePcc)
                    .IsRequired()
                    .HasColumnName("system_consistency_difference_pcc");
                
                navigationBuilder
                    .Property(p => p.DifferenceAr)
                    .IsRequired()
                    .HasColumnName("system_consistency_difference_ar");
                
                navigationBuilder
                    .Property(p => p.DifferenceAtr)
                    .IsRequired()
                    .HasColumnName("system_consistency_difference_atr");

                navigationBuilder
                    .Property(p => p.Observations)
                    .IsRequired()
                    .HasColumnName("system_consistency_observations");
            });
        
        builder.OwnsOne(v => v.Conclusion,
            navigationBuilder =>
            {
                navigationBuilder
                    .Property(p => p.InspectorPerformance)
                    .IsRequired()
                    .HasColumnName("conclusion_inspector_performance");

                navigationBuilder
                    .Property(p => p.LaboratoryReceptivity)
                    .IsRequired()
                    .HasColumnName("conclusion_laboratory_receptivity");

                navigationBuilder
                    .Property(p => p.Pendencies)
                    .IsRequired()
                    .HasColumnName("conclusion_pendencies");

                navigationBuilder
                    .Property(p => p.Observations)
                    .IsRequired()
                    .HasColumnName("conclusion_conclusion_observations");
            });
    }
}