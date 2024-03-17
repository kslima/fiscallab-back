using FiscalLabService.App.Dtos;
using FiscalLabService.App.Models;
using FiscalLabService.Domain.Entities;
using FiscalLabService.Domain.ValueObjects;

namespace FiscalLabService.App.Extensions;

public static class VisitExtensions
{
    public static VisitDto AsVisitDto(this Visit source)
    {
        return new VisitDto
        {
            Id = source.Id,
            BasicInformation = source.BasicInformation.AsBasicInformationDto(),
            SugarcaneBalance = source.SugarcaneBalance.AsSugarcaneBalanceDto(),
            DesintegratorProbe = source.DesintegratorProbe.AsDesintegratorProbeDto(),
            AnalyticalBalance = source.AnalyticalBalance.AsAnalyticalBalanceDto(),
            PressRefractometer = source.PressRefractometer.AsPressRefractometerDto(),
            ClarificationSaccharimeter = source.ClarificationSaccharimeter.AsClarificationSaccharimeterDto(),
            BenchmarkingEquipment = source.BenchmarkingEquipment.AsBenchmarkingEquipmentDto(),
            SystemConsistency = source.SystemConsistency.AsSystemConsistencyDto(),
            Conclusion = source.Conclusion.AsConclusionDto(),
            NotifyByEmail = source.NotifyByEmail,
            CreatedAt = source.CreatedAt,
            FinishedAt = source.FinishedAt,
            NotifiedByEmailAt = source.NotifiedByEmailAt,
            Images = source.Images.Select(i => new ImageDto
            {
                Name = i.Name,
                Url = i.Url,
                Description = i.Description
            }).ToList(),
            BalanceTests = source.BalanceTests.Select(i => new BalanceTestDto(i)).ToList()
        };
    }

    private static BasicInformationDto AsBasicInformationDto(this BasicInformation source)
    {
        return new BasicInformationDto
        {
            Plant = source.Plant.AsPlantDto(),
            Association = source.Association.AsAssociationDto(),
            Consultant = source.Consultant,
            Inspector = source.Inspector,
            Leader = source.Leader,
            LaboratoryLeader = source.LaboratoryLeader,
            VisitDate = source.VisitDate,
            VisitTime = source.VisitTime
        };
    }

    private static SugarcaneBalanceDto AsSugarcaneBalanceDto(this SugarcaneBalance source)
    {
        return new SugarcaneBalanceDto
        {
            InScale = source.InScale,
            OutScale = source.OutScale,
            CargoDraw = source.CargoDraw,
            ScaleObservations = source.ScaleObservations,
            Calibration1 = source.Calibration1,
            Calibration2 = source.Calibration2,
            ResponsibleBody = source.ResponsibleBody,
            CalibrationCertificate = source.CalibrationCertificate,
            Observations1 = source.Observations1,
            Observations2 = source.Observations2,
            PlantPercentage = source.PlantPercentage,
            ProviderPercentage = source.ProviderPercentage,
            PlantFarmPercentage = source.PlantFarmPercentage,
            FarmProviderPercentage = source.FarmProviderPercentage,
        };
    }

    private static DesintegratorProbeDto AsDesintegratorProbeDto(this DesintegratorProbe source)
    {
        return new DesintegratorProbeDto
        {
            ProbeType = source.ProbeType,
            TubeInserted = source.TubeInserted,
            TubeDischarged = source.TubeDischarged,
            Collect = source.Collect,
            SampleAmount = source.SampleAmount,
            BrothExtraction = source.BrothExtraction,
            LoadPosition = source.LoadPosition,
            ToothedCrown = source.ToothedCrown,
            ToothedCrownType = source.ToothedCrownType,
            LastCrownChange = source.LastCrownChange,
            Observations3 = source.Observations3,
            HomogeneousSamples = source.HomogeneousSamples,
            KnifeConservation = source.KnifeConservation,
            AgainstKnifeConservation = source.AgainstKnifeConservation,
            KnifeAgainstKnifeDistance = source.KnifeAgainstKnifeDistance,
            HammerConservation = source.HammerConservation,
            CleanMixer = source.CleanMixer,
            DesintegratorRpm = source.DesintegratorRpm,
            PreparationIndex = source.PreparationIndex,
            SharpenedOrReplacedKnifeAt = source.SharpenedOrReplacedKnifeAt,
            Observations4 = source.Observations4,
        };
    }

    private static AnalyticalBalanceDto AsAnalyticalBalanceDto(this AnalyticalBalance source)
    {
        return new AnalyticalBalanceDto
        {
            HomogeneousWeight = source.HomogeneousWeight,
            FinalWeight = source.FinalWeight,
            CalibratedBalance = source.CalibratedBalance,
            LeveledBalance = source.LeveledBalance,
            CalibrationCertificateBalance = source.CalibrationCertificateBalance,
            Observations5 = source.Observations5,
            AverageAmbientTemperature = source.AverageAmbientTemperature,
            Observations6 = source.Observations6
        };
    }

    private static PressRefractometerDto AsPressRefractometerDto(this PressRefractometer source)
    {
        return new PressRefractometerDto
        {
            PressureGaugeCertificated = source.PressureGaugeCertificated,
            DiscardCup = source.DiscardCup,
            CollectorBottle = source.CollectorBottle,
            Pressure = source.Pressure,
            Timer = source.Timer,
            PressCleaning = source.PressCleaning,
            Observations7 = source.Observations7,
            BrothHomogenization = source.BrothHomogenization,
            RefractometerCalibrationCertificate = source.RefractometerCalibrationCertificate,
            PrecisionReading = source.PrecisionReading,
            RefractometerBenchmarking = source.RefractometerBenchmarking,
            RefractometerCleaning = source.RefractometerCleaning,
            InternalTemperature = source.InternalTemperature,
            Observations8 = source.Observations8,
        };
    }

    private static ClarificationSaccharimeterDto AsClarificationSaccharimeterDto(
        this ClarificationSaccharimeter source)
    {
        return new ClarificationSaccharimeterDto
        {
            Bottle = source.Bottle,
            Agitation = source.Agitation,
            HasDilution = source.HasDilution,
            Clarifier = source.Clarifier,
            Pressure = source.Pressure,
            ClarifierAmount = source.ClarifierAmount,
            BottleClarifiedVolume = source.BottleClarifiedVolume,
            BottleAfterClarifiedVolume = source.BottleAfterClarifiedVolume,
            Observations9 = source.Observations9,
            Stabilization = source.Stabilization,
            Benchmarking = source.Benchmarking,
            QuartzPattern = source.QuartzPattern,
            QuartzResult = source.QuartzResult,
            QuartzReading = source.QuartzReading,
            CalibrationCertificate = source.CalibrationCertificate,
            TubeCleaning = source.TubeCleaning,
            ClearCollingCooler = source.ClearCollingCooler,
            Observations10 = source.Observations10,
        };
    }

    private static BenchmarkingEquipmentDto AsBenchmarkingEquipmentDto(this BenchmarkingEquipment source)
    {
        return new BenchmarkingEquipmentDto
        {
            LoadCell = source.LoadCell,
            Thermometer = source.Thermometer,
            Tachometer = source.Tachometer,
            Pachymeter = source.Pachymeter,
            Gm500 = source.Gm500,
            Gm100 = source.Gm100,
            Gm1 = source.Gm1,
            SucroseTest = source.SucroseTest,
            Range10 = source.Range10,
            Range20 = source.Range20,
            Range30 = source.Range30,
            Z25 = source.Z25,
            Z50 = source.Z50,
            Z75 = source.Z75,
            Z100 = source.Z100,
            Observations11 = source.Observations11,
            ExpectedCrop = source.ExpectedCrop,
            AccomplishedCrop = source.AccomplishedCrop,
            PreviousCrop = source.PreviousCrop,
            PercentageRealized = source.PercentageRealized,
            VariationBetweenCrops = source.VariationBetweenCrops,
            CurrentFiber = source.CurrentFiber,
            PreviousFiber = source.PreviousFiber,
            FiberVariation = source.FiberVariation,
            CurrentAtr = source.CurrentAtr,
            PreviousAtr = source.PreviousAtr,
            AtrVariation = source.AtrVariation,
            Observations12 = source.Observations12
        };
    }
    
    private static SystemConsistencyDto AsSystemConsistencyDto(this SystemConsistency source)
    {
        return new SystemConsistencyDto
        {
            Oc = source.Oc,
            Farm = source.Farm,
            Owner = source.Owner,
            Clarifier = source.Clarifier,
            PlantSugarcaneAnalysis = source.PlantSugarcaneAnalysis.AsSugarcaneAnalysisDto(),
            ConsecanaSugarcaneAnalysis = source.ConsecanaSugarcaneAnalysis.AsSugarcaneAnalysisDto(),
            DifferencePurity = source.DifferencePurity,
            DifferencePol = source.DifferencePol,
            DifferenceFiber = source.DifferenceFiber,
            DifferencePcc = source.DifferencePcc,
            DifferenceAr = source.DifferenceAr,
            DifferenceAtr = source.DifferenceAtr,
            Observations = source.Observations
        };
    }
    
    private static SugarcaneAnalysisDto AsSugarcaneAnalysisDto(this SugarcaneAnalysis source)
    {
        return new SugarcaneAnalysisDto
        {
            Pbu = source.Pbu,
            Brix = source.Brix,
            Ls = source.Ls,
            Purity = source.Purity,
            Pol = source.Pol,
            Fiber = source.Fiber,
            Pcc = source.Pcc,
            Ar = source.Ar,
            Atr = source.Atr
        };
    }
    
    private static ConclusionDto AsConclusionDto(this Conclusion source)
    {
        return new ConclusionDto
        {
            InspectorPerformance = source.InspectorPerformance,
            LaboratoryReceptivity = source.LaboratoryReceptivity,
            Pendencies = source.Pendencies,
            Observations = source.Observations
        };
    }
    public static Visit AsVisit(this VisitModel source)
    {
        return new Visit
        {
            Id = source.Id,
            BasicInformation = source.BasicInformation.AsBasicInformation(),
            SugarcaneBalance = source.SugarcaneBalance.AsSugarcaneBalance(),
            DesintegratorProbe = source.DesintegratorProbe.AsDesintegratorProbe(),
            AnalyticalBalance = source.AnalyticalBalance.AsAnalyticalBalance(),
            PressRefractometer = source.PressRefractometer.AsPressRefractometer(),
            ClarificationSaccharimeter = source.ClarificationSaccharimeter.AsClarificationSaccharimeter(),
            BenchmarkingEquipment = source.BenchmarkingEquipment.AsBenchmarkingEquipment(),
            SystemConsistency = source.SystemConsistency.AsSystemConsistency(),
            Conclusion = source.Conclusion.AsConclusion(),
            CreatedAt = source.CreatedAt,
            NotifyByEmail = source.IsFinished,
            FinishedAt = source.FinishedAt,
            NotifiedByEmailAt = source.SentAt,
            Images = source.Images.Select(i => new Image
            {
                Name = i.Name,
                Url = i.Url,
                Description = i.Description
            }).ToList()
        };
    }
    
    private static BasicInformation AsBasicInformation(this BasicInformationModel source)
    {
        return new BasicInformation
        {
            PlantId = source.PlantId,
            AssociationId = source.AssociationId,
            Consultant = source.Consultant,
            Inspector = source.Inspector,
            Leader = source.Leader,
            LaboratoryLeader = source.LaboratoryLeader,
            VisitDate = source.VisitDate,
            VisitTime = source.VisitTime
        };
    }

    private static SugarcaneBalance AsSugarcaneBalance(this SugarcaneBalanceModel source)
    {
        return new SugarcaneBalance
        {
            InScale = source.InScale,
            OutScale = source.OutScale,
            CargoDraw = source.CargoDraw,
            ScaleObservations = source.ScaleObservations,
            Calibration1 = source.Calibration1,
            Calibration2 = source.Calibration2,
            ResponsibleBody = source.ResponsibleBody,
            CalibrationCertificate = source.CalibrationCertificate,
            Observations1 = source.Observations1,
            PlantPercentage = source.PlantPercentage,
            ProviderPercentage = source.ProviderPercentage,
            PlantFarmPercentage = source.PlantFarmPercentage,
            FarmProviderPercentage = source.FarmProviderPercentage,
        };
    }

    private static DesintegratorProbe AsDesintegratorProbe(this DesintegratorProbeModel source)
    {
        return new DesintegratorProbe
        {
            ProbeType = source.ProbeType,
            TubeInserted = source.TubeInserted,
            TubeDischarged = source.TubeDischarged,
            Collect = source.Collect,
            SampleAmount = source.SampleAmount,
            BrothExtraction = source.BrothExtraction,
            LoadPosition = source.LoadPosition,
            ToothedCrown = source.ToothedCrown,
            ToothedCrownType = source.ToothedCrownType,
            LastCrownChange = source.LastCrownChange,
            Observations3 = source.Observations3,
            HomogeneousSamples = source.HomogeneousSamples,
            KnifeConservation = source.KnifeConservation,
            AgainstKnifeConservation = source.AgainstKnifeConservation,
            KnifeAgainstKnifeDistance = source.KnifeAgainstKnifeDistance,
            HammerConservation = source.HammerConservation,
            CleanMixer = source.CleanMixer,
            DesintegratorRpm = source.DesintegratorRpm,
            PreparationIndex = source.PreparationIndex,
            SharpenedOrReplacedKnifeAt = source.SharpenedOrReplacedKnifeAt,
            Observations4 = source.Observations4,
        };
    }

    private static AnalyticalBalance AsAnalyticalBalance(this AnalyticalBalanceModel source)
    {
        return new AnalyticalBalance
        {
            HomogeneousWeight = source.HomogeneousWeight,
            FinalWeight = source.FinalWeight,
            CalibratedBalance = source.CalibratedBalance,
            LeveledBalance = source.LeveledBalance,
            CalibrationCertificateBalance = source.CalibrationCertificateBalance,
            Observations5 = source.Observations5,
            AverageAmbientTemperature = source.AverageAmbientTemperature,
            Observations6 = source.Observations6
        };
    }

    private static PressRefractometer AsPressRefractometer(this PressRefractometerModel source)
    {
        return new PressRefractometer
        {
            PressureGaugeCertificated = source.PressureGaugeCertificated,
            DiscardCup = source.DiscardCup,
            CollectorBottle = source.CollectorBottle,
            Pressure = source.Pressure,
            Timer = source.Timer,
            PressCleaning = source.PressCleaning,
            Observations7 = source.Observations7,
            BrothHomogenization = source.BrothHomogenization,
            RefractometerCalibrationCertificate = source.RefractometerCalibrationCertificate,
            PrecisionReading = source.PrecisionReading,
            RefractometerBenchmarking = source.RefractometerBenchmarking,
            RefractometerCleaning = source.RefractometerCleaning,
            InternalTemperature = source.InternalTemperature,
            Observations8 = source.Observations8,
        };
    }

    private static ClarificationSaccharimeter AsClarificationSaccharimeter(
        this ClarificationSaccharimeterModel source)
    {
        return new ClarificationSaccharimeter
        {
            Bottle = source.Bottle,
            Agitation = source.Agitation,
            HasDilution = source.HasDilution,
            Clarifier = source.Clarifier,
            Pressure = source.Pressure,
            ClarifierAmount = source.ClarifierAmount,
            BottleClarifiedVolume = source.BottleClarifiedVolume,
            BottleAfterClarifiedVolume = source.BottleAfterClarifiedVolume,
            Observations9 = source.Observations9,
            Stabilization = source.Stabilization,
            Benchmarking = source.Benchmarking,
            QuartzPattern = source.QuartzPattern,
            QuartzResult = source.QuartzResult,
            QuartzReading = source.QuartzReading,
            CalibrationCertificate = source.CalibrationCertificate,
            TubeCleaning = source.TubeCleaning,
            ClearCollingCooler = source.ClearCollingCooler,
            Observations10 = source.Observations10,
        };
    }

    private static BenchmarkingEquipment AsBenchmarkingEquipment(this BenchmarkingEquipmentModel source)
    {
        return new BenchmarkingEquipment
        {
            LoadCell = source.LoadCell,
            Thermometer = source.Thermometer,
            Tachometer = source.Tachometer,
            Pachymeter = source.Pachymeter,
            Gm500 = source.Gm500,
            Gm100 = source.Gm100,
            Gm1 = source.Gm1,
            SucroseTest = source.SucroseTest,
            Range10 = source.Range10,
            Range20 = source.Range20,
            Range30 = source.Range30,
            Z25 = source.Z25,
            Z50 = source.Z50,
            Z75 = source.Z75,
            Z100 = source.Z100,
            Observations11 = source.Observations11,
            ExpectedCrop = source.ExpectedCrop,
            AccomplishedCrop = source.AccomplishedCrop,
            PreviousCrop = source.PreviousCrop,
            PercentageRealized = source.PercentageRealized,
            VariationBetweenCrops = source.VariationBetweenCrops,
            CurrentFiber = source.CurrentFiber,
            PreviousFiber = source.PreviousFiber,
            FiberVariation = source.FiberVariation,
            CurrentAtr = source.CurrentAtr,
            PreviousAtr = source.PreviousAtr,
            AtrVariation = source.AtrVariation,
            Observations12 = source.Observations12
        };
    }
    
    private static SystemConsistency AsSystemConsistency(this SystemConsistencyModel source)
    {
        return new SystemConsistency
        {
            Oc = source.Oc,
            Farm = source.Farm,
            Owner = source.Owner,
            Clarifier = source.Clarifier,
            PlantSugarcaneAnalysis = source.PlantSugarcaneAnalysis.AsSugarcaneAnalysis(),
            ConsecanaSugarcaneAnalysis = source.ConsecanaSugarcaneAnalysis.AsSugarcaneAnalysis(),
            DifferencePurity = source.DifferencePurity,
            DifferencePol = source.DifferencePol,
            DifferenceFiber = source.DifferenceFiber,
            DifferencePcc = source.DifferencePcc,
            DifferenceAr = source.DifferenceAr,
            DifferenceAtr = source.DifferenceAtr,
            Observations = source.Observations
        };
    }
    
    private static SugarcaneAnalysis AsSugarcaneAnalysis(this SugarcaneAnalysisModel source)
    {
        return new SugarcaneAnalysis
        {
            Pbu = source.Pbu,
            Brix = source.Brix,
            Ls = source.Ls,
            Purity = source.Purity,
            Pol = source.Pol,
            Fiber = source.Fiber,
            Pcc = source.Pcc,
            Ar = source.Ar,
            Atr = source.Atr
        };
    }
    
    private static Conclusion AsConclusion(this ConclusionModel source)
    {
        return new Conclusion
        {
            InspectorPerformance = source.InspectorPerformance,
            LaboratoryReceptivity = source.LaboratoryReceptivity,
            Pendencies = source.Pendencies,
            Observations = source.Observations
        };
    }
}