using FiscalLabService.App.Dtos.Shared;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

namespace FiscalLabService.App.Documents;

public class VisitDocument(
    VisitDto visit,
    List<ImageDto> images) : IDocument
{
    private VisitDto Visit { get; } = visit;
    private List<ImageDto> Images { get; } = images;
    public DocumentMetadata GetMetadata() => DocumentMetadata.Default;
    public DocumentSettings GetSettings() => DocumentSettings.Default;

    public void Compose(IDocumentContainer container)
    {
        container
            .Page(page =>
            {
                page.Margin(30);
                page.PageColor(DocumentConstants.PageColor);

                page.Header().Element(ComposeHeader);
                page.Content().Element(ComposeContent);

                page.Footer().Element(ComposeFooter);
            });
    }

    private void ComposeHeader(IContainer container)
    {
        var titleStyle = TextStyle.Default
            .FontSize(16)
            .Bold()
            .FontColor(DocumentConstants.HeaderTitleColor);

        var descriptionStyle = TextStyle.Default
            .FontSize(8)
            .SemiBold()
            .FontColor(DocumentConstants.HeaderSubTitleColor);

        container
            .Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.RelativeColumn();
                    columns.RelativeColumn();
                    columns.RelativeColumn();
                    columns.RelativeColumn();
                });

                table.ExtendLastCellsToTableBottom();

                table
                    .Cell()
                    .ColumnSpan(4)
                    .Width(100)
                    .Image("logo.png")
                    .WithRasterDpi(500);

                table
                    .Cell()
                    .ColumnSpan(4)
                    .AlignBottom()
                    .AlignCenter()
                    .Text("Relatório Visita Analítica")
                    .Style(titleStyle);

                table
                    .Cell()
                    .ColumnSpan(4)
                    .Text(text =>
                    {
                        text
                            .Span(DocumentConstants.HeaderDescription)
                            .Style(descriptionStyle);
                    });
            });
    }

    private void ComposeContent(IContainer container)
    {
        container.PaddingVertical(5).Column(column =>
        {
            column.Spacing(5);
            column.Item().EnsureSpace().Element(ComposeBasicData);
            column.Item().EnsureSpace().Element(ComposeCaneBalance);
            column.Item().EnsureSpace().Element(ComposeDesintegratorProbe);
            column.Item().EnsureSpace().Element(ComposeAnalyticalBalanceAndTemp);
            column.Item().EnsureSpace().Element(ComposePressRefractometer);
            column.Item().EnsureSpace().Element(ComposeClarificationSaccharimeter);
            column.Item().EnsureSpace().Element(ComposeBenchmarkingEquipment);
            column.Item().EnsureSpace().Element(ComposeResultComparison);
            column.Item().EnsureSpace().Element(ComposeConclusion);
            column.Item().EnsureSpace().Element(ComposeImages);
        });
    }

    private void ComposeBasicData(IContainer container)
    {
        container
            .Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.RelativeColumn();
                    columns.RelativeColumn();
                    columns.RelativeColumn();
                    columns.RelativeColumn();
                });

                table.ExtendLastCellsToTableBottom();
                table.Cell().ColumnSpan(4).LabelTitleCell("Dados Básicos");

                table.Cell().SubLabelCell("Data");
                table.Cell().SubLabelCell("Consultor");
                table.Cell().SubLabelCell("Unidade Industrial");
                table.Cell().SubLabelCell("Associação/Fornecedor");

                table.Cell()
                    .ValueCell(
                        $"{Visit.BasicInformation.VisitDate.ToString("dd/MM/yyyy")} {Visit.BasicInformation.VisitTime.ToString("HH:mm:ss")}");
                table.Cell().ValueCell(Visit.BasicInformation.Consultant);
                table.Cell().ValueCell(Visit.BasicInformation.Plant.Name);
                table.Cell().ValueCell(Visit.BasicInformation.Association.Name);

                table.Cell().SubLabelCell("Líder do Turno");
                table.Cell().SubLabelCell("Fiscal do Turno");
                table.Cell().ColumnSpan(2).SubLabelCell("Encarregado(a) Lab. Sacarose");
                table.Cell().ValueCell(Visit.BasicInformation.Leader);
                table.Cell().ValueCell(Visit.BasicInformation.Inspector);
                table.Cell().ColumnSpan(2).ValueCell(Visit.BasicInformation.LaboratoryLeader);
            });
    }

    private void ComposeCaneBalance(IContainer container)
    {
        container
            .Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.RelativeColumn();
                    columns.RelativeColumn();
                    columns.RelativeColumn();
                    columns.RelativeColumn();
                    columns.RelativeColumn();
                    columns.RelativeColumn();
                });

                table.ExtendLastCellsToTableBottom();
                table.Header(h => h.Cell().ColumnSpan(6).LabelTitleCell("Balança de Cana"));

                table.Cell().ColumnSpan(6).LabelCell("Balanças");
                table.Cell().ColumnSpan(2).SubLabelCell("Balança de Entrada");
                table.Cell().ColumnSpan(2).SubLabelCell("Balança de Saída");
                table.Cell().ColumnSpan(2).SubLabelCell("Sorteio de Cargas");
                table.Cell().ColumnSpan(2).ValueCell(Visit.SugarcaneBalance.InScale);
                table.Cell().ColumnSpan(2).ValueCell(Visit.SugarcaneBalance.OutScale);
                table.Cell().ColumnSpan(2).ValueCell(Visit.SugarcaneBalance.CargoDraw);
                table.Cell().ColumnSpan(6).SubLabelCell("Observações");
                table.Cell().ColumnSpan(6).ValueCell(Visit.SugarcaneBalance.ScaleObservations);

                table.Cell().ColumnSpan(6).LabelCell("Calibragens");
                table.Cell().ColumnSpan(1).SubLabelCell("1º Calibração");
                table.Cell().ColumnSpan(1).SubLabelCell("2º Calibração");
                table.Cell().ColumnSpan(2).SubLabelCell("Orgão Responsavel");
                table.Cell().ColumnSpan(2).SubLabelCell("Certificado de Calibração");
                table.Cell().ColumnSpan(1).ValueCell(Visit.SugarcaneBalance.Calibration1);
                table.Cell().ColumnSpan(1).ValueCell(Visit.SugarcaneBalance.Calibration2);
                table.Cell().ColumnSpan(2).ValueCell(Visit.SugarcaneBalance.ResponsibleBody);
                table.Cell().ColumnSpan(2).ValueCell(Visit.SugarcaneBalance.CalibrationCertificate);
                table.Cell().ColumnSpan(6).SubLabelCell("Observações");
                table.Cell().ColumnSpan(6).ValueCell(Visit.SugarcaneBalance.Observations1);

                table.Cell().ColumnSpan(6).LabelCell("Porcentagens Analisadas");
                table.Cell().ColumnSpan(1).SubLabelCell("Usina");
                table.Cell().ColumnSpan(1).SubLabelCell("Fornecedor");
                table.Cell().ColumnSpan(2).SubLabelCell("Usina/Fazenda");
                table.Cell().ColumnSpan(2).SubLabelCell("Fornecedor/Fazenda");
                table.Cell().ColumnSpan(1).ValueCell(Visit.SugarcaneBalance.PlantPercentage);
                table.Cell().ColumnSpan(1).ValueCell(Visit.SugarcaneBalance.ProviderPercentage);
                table.Cell().ColumnSpan(2).ValueCell(Visit.SugarcaneBalance.PlantFarmPercentage);
                table.Cell().ColumnSpan(2).ValueCell(Visit.SugarcaneBalance.FarmProviderPercentage);
                table.Cell().ColumnSpan(6).SubLabelCell("Observações");
                table.Cell().ColumnSpan(6).ValueCell(Visit.SugarcaneBalance.Observations2);

                if (Visit.BalanceTests.Count == 0) return;

                table.Cell().ColumnSpan(6).LabelCell("Testes");
                table.Cell().SubLabelCell("Placa");
                table.Cell().ColumnSpan(2).SubLabelCell("Entrada");
                table.Cell().ColumnSpan(2).SubLabelCell("Saída");
                table.Cell().SubLabelCell("Variação");

                foreach (var modelBalanceTest in Visit.BalanceTests)
                {
                    table.Cell().ValueCell(modelBalanceTest.Identification);
                    table.Cell().ColumnSpan(2).DecimalValueCell(modelBalanceTest.InputBalanceWeight);
                    table.Cell().ColumnSpan(2).DecimalValueCell(modelBalanceTest.OutputBalanceWeight);
                    table.Cell().DecimalValueCell(modelBalanceTest.InputBalanceWeight -
                                                  modelBalanceTest.OutputBalanceWeight);
                }
            });
    }

    private void ComposeDesintegratorProbe(IContainer container)
    {
        container
            .Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.RelativeColumn();
                    columns.RelativeColumn();
                    columns.RelativeColumn();
                    columns.RelativeColumn();
                    columns.RelativeColumn();
                });

                table.ExtendLastCellsToTableBottom();
                table.Header(h => h.Cell().ColumnSpan(5).LabelTitleCell("Sonda/Desintegrador"));

                table.Cell().ColumnSpan(5).LabelCell("Sonda");
                table.Cell().SubLabelCell("Tipo de sonda");
                table.Cell().SubLabelCell("Tubo introduzido total");
                table.Cell().SubLabelCell("Descarrega tubo após furo");
                table.Cell().SubLabelCell("Coleta");
                table.Cell().SubLabelCell("Quantidade de amostra suficiente");
                table.Cell().ValueCell(Visit.DesintegratorProbe.ProbeType);
                table.Cell().ValueCell(Visit.DesintegratorProbe.TubeInserted);
                table.Cell().ValueCell(Visit.DesintegratorProbe.TubeDischarged);
                table.Cell().ValueCell(Visit.DesintegratorProbe.Collect);
                table.Cell().ValueCell(Visit.DesintegratorProbe.SampleAmount);
                table.Cell().SubLabelCell("Extração do caldo");
                table.Cell().SubLabelCell("Posição da carga");
                table.Cell().SubLabelCell("Coroa dentada");
                table.Cell().ColumnSpan(2).SubLabelCell("Tipo coroa");
                table.Cell().ValueCell(Visit.DesintegratorProbe.BrothExtraction);
                table.Cell().ValueCell(Visit.DesintegratorProbe.LoadPosition);
                table.Cell().ValueCell(Visit.DesintegratorProbe.ToothedCrown);
                table.Cell().ColumnSpan(2).ValueCell(Visit.DesintegratorProbe.ToothedCrownType);
                table.Cell().ColumnSpan(5).SubLabelCell("Observações");
                table.Cell().ColumnSpan(5).ValueCell(Visit.DesintegratorProbe.Observations3);


                table.Cell().ColumnSpan(5).LabelCell("Desintegrador");
                table.Cell().SubLabelCell("Amostras homogênias");
                table.Cell().SubLabelCell("Betoneira limpa a cada amostra");
                table.Cell().SubLabelCell("Conservação facas");
                table.Cell().SubLabelCell("RPM do Desintegrador");
                table.Cell().SubLabelCell("Conservaçao contra-faca");
                table.Cell().ValueCell(Visit.DesintegratorProbe.HomogeneousSamples);
                table.Cell().ValueCell(Visit.DesintegratorProbe.CleanMixer);
                table.Cell().ValueCell(Visit.DesintegratorProbe.KnifeConservation);
                table.Cell().ValueCell(Visit.DesintegratorProbe.DesintegratorRpm);
                table.Cell().ValueCell(Visit.DesintegratorProbe.AgainstKnifeConservation);
                table.Cell().SubLabelCell("Índice de preparo");
                table.Cell().SubLabelCell("Distância faca/contra-faca");
                table.Cell().SubLabelCell("Ultima troca navalhas");
                table.Cell().ColumnSpan(2).SubLabelCell("Conservação martelo");
                table.Cell().ValueCell(Visit.DesintegratorProbe.PreparationIndex);
                table.Cell().ValueCell(Visit.DesintegratorProbe.KnifeAgainstKnifeDistance);
                var sharpenedOrReplacedKnifeAt = Visit.DesintegratorProbe.SharpenedOrReplacedKnifeAt == null
                    ? "-"
                    : Visit.DesintegratorProbe.SharpenedOrReplacedKnifeAt.Value.ToString("dd/MM/yyyy");
                table.Cell().ValueCell(sharpenedOrReplacedKnifeAt);
                table.Cell().ColumnSpan(2).ValueCell(Visit.DesintegratorProbe.HammerConservation);
                table.Cell().ColumnSpan(5).SubLabelCell("Observações");
                table.Cell().ColumnSpan(5).ValueCell(Visit.DesintegratorProbe.Observations4);
            });
    }

    private void ComposeAnalyticalBalanceAndTemp(IContainer container)
    {
        container
            .Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.RelativeColumn();
                    columns.RelativeColumn();
                    columns.RelativeColumn();
                    columns.RelativeColumn();
                    columns.RelativeColumn();
                });

                table.ExtendLastCellsToTableBottom();
                table.Header(h => h.Cell().ColumnSpan(5).LabelTitleCell("Balança Analítica/Temperatura"));

                table.Cell().ColumnSpan(5).LabelCell("Balança Analítica");
                table.Cell().SubLabelCell("Peso Homogênio após desintegração");
                table.Cell().SubLabelCell("Peso amostra final");
                table.Cell().SubLabelCell("Balança aferida");
                table.Cell().SubLabelCell("Balança nivelada");
                table.Cell().SubLabelCell("Balança com certificado de calibração");
                table.Cell().ValueCell(Visit.AnalyticalBalance.HomogeneousWeight);
                table.Cell().ValueCell(Visit.AnalyticalBalance.FinalWeight);
                table.Cell().ValueCell(Visit.AnalyticalBalance.CalibratedBalance);
                table.Cell().ValueCell(Visit.AnalyticalBalance.LeveledBalance);
                table.Cell().ValueCell(Visit.AnalyticalBalance.CalibrationCertificateBalance);
                table.Cell().ColumnSpan(5).SubLabelCell("Observações");
                table.Cell().ColumnSpan(5).ValueCell(Visit.AnalyticalBalance.Observations6);

                table.Cell().ColumnSpan(5).LabelCell("Temperatura");
                table.Cell().ColumnSpan(1).SubLabelCell("Média (20ºC ± 5)");
                table.Cell().ColumnSpan(4).ValueCell(Visit.AnalyticalBalance.AverageAmbientTemperature);
                table.Cell().ColumnSpan(5).SubLabelCell("Observações");
                table.Cell().ColumnSpan(5).ValueCell(Visit.AnalyticalBalance.Observations5);
            });
    }

    private void ComposePressRefractometer(IContainer container)
    {
        container
            .Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.RelativeColumn();
                    columns.RelativeColumn();
                    columns.RelativeColumn();
                    columns.RelativeColumn();
                    columns.RelativeColumn();
                    columns.RelativeColumn();
                });

                table.ExtendLastCellsToTableBottom();
                table.Header(h => h.Cell().ColumnSpan(6).LabelTitleCell("Prensa/Refratômetro"));

                table.Cell().ColumnSpan(6).LabelCell("Prensa");
                table.Cell().SubLabelCell("Manômetro com cert. de calibralçao");
                table.Cell().SubLabelCell("Uso do copo descarte");
                table.Cell().SubLabelCell("Frasco coletor");
                table.Cell().SubLabelCell("Pressão");
                table.Cell().SubLabelCell("Temporizador");
                table.Cell().SubLabelCell("Limpeza da prensa");
                table.Cell().ValueCell(Visit.PressRefractometer.PressureGaugeCertificated);
                table.Cell().ValueCell(Visit.PressRefractometer.DiscardCup);
                table.Cell().ValueCell(Visit.PressRefractometer.CollectorBottle);
                table.Cell().ValueCell(Visit.PressRefractometer.Pressure);
                table.Cell().ValueCell(Visit.PressRefractometer.Timer);
                table.Cell().ValueCell(Visit.PressRefractometer.PressCleaning);
                table.Cell().ColumnSpan(6).SubLabelCell("Observações");
                table.Cell().ColumnSpan(6).ValueCell(Visit.PressRefractometer.Observations7);

                table.Cell().ColumnSpan(6).LabelCell("Refratômetro");
                table.Cell().SubLabelCell("Hômogenização do caldo");
                table.Cell().SubLabelCell("Certificado de calibração");
                table.Cell().SubLabelCell("Precisão da leitura");
                table.Cell().SubLabelCell("Aferição");
                table.Cell().SubLabelCell("Limpeza");
                table.Cell().SubLabelCell("Temperatura interna");
                table.Cell().ValueCell(Visit.PressRefractometer.BrothHomogenization);
                table.Cell().ValueCell(Visit.PressRefractometer.RefractometerCalibrationCertificate);
                table.Cell().ValueCell(Visit.PressRefractometer.PrecisionReading);
                table.Cell().ValueCell(Visit.PressRefractometer.BrothHomogenization);
                table.Cell().ValueCell(Visit.PressRefractometer.PressCleaning);
                table.Cell().ValueCell(Visit.PressRefractometer.InternalTemperature);
                table.Cell().ColumnSpan(6).SubLabelCell("Observações");
                table.Cell().ColumnSpan(6).ValueCell(Visit.PressRefractometer.Observations8);
            });
    }

    private void ComposeClarificationSaccharimeter(IContainer container)
    {
        container
            .Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.RelativeColumn();
                    columns.RelativeColumn();
                    columns.RelativeColumn();
                    columns.RelativeColumn();
                });

                table.ExtendLastCellsToTableBottom();
                table.Header(h => h.Cell().ColumnSpan(4).LabelTitleCell("Clarificação/Sacarímetro"));

                table.Cell().ColumnSpan(4).LabelCell("Clarificação");
                table.Cell().SubLabelCell("Frasco");
                table.Cell().SubLabelCell("Agitação");
                table.Cell().SubLabelCell("Houve diluição");
                table.Cell().SubLabelCell("Clarificante");
                table.Cell().ValueCell(Visit.ClarificationSaccharimeter.Bottle);
                table.Cell().ValueCell(Visit.ClarificationSaccharimeter.Agitation);
                table.Cell().ValueCell(Visit.ClarificationSaccharimeter.HasDilution);
                table.Cell().ValueCell(Visit.ClarificationSaccharimeter.Clarifier);
                table.Cell().ColumnSpan(2).SubLabelCell("Qtd. de clarificante (200ml)");
                table.Cell().SubLabelCell("Volume clarificado");
                table.Cell().SubLabelCell("100ml após limpeza do sacarimetro");
                table.Cell().ColumnSpan(2).ValueCell(Visit.ClarificationSaccharimeter.ClarifierAmount);
                table.Cell().ValueCell(Visit.ClarificationSaccharimeter.BottleClarifiedVolume);
                table.Cell().ValueCell(Visit.ClarificationSaccharimeter.BottleAfterClarifiedVolume);
                table.Cell().ColumnSpan(4).SubLabelCell("Observações");
                table.Cell().ColumnSpan(4).ValueCell(Visit.ClarificationSaccharimeter.Observations9);

                table.Cell().ColumnSpan(4).ColumnSpan(4).LabelCell("Sacarímetro");

                table.Cell().SubLabelCell("Estabilização");
                table.Cell().SubLabelCell("Aferição");
                table.Cell().SubLabelCell("Padrão quartzo");
                table.Cell().SubLabelCell("Resultado quartzo");
                table.Cell().ValueCell(Visit.ClarificationSaccharimeter.Stabilization);
                table.Cell().ValueCell(Visit.ClarificationSaccharimeter.Benchmarking);
                table.Cell().ValueCell(Visit.ClarificationSaccharimeter.QuartzPattern);
                table.Cell().ValueCell(Visit.ClarificationSaccharimeter.QuartzResult);
                table.Cell().SubLabelCell("Leitura quartzo");
                table.Cell().SubLabelCell("Certificado de calibração");
                table.Cell().SubLabelCell("Limpeza tubo");
                table.Cell().SubLabelCell("Cooler de resfriamento limpo");
                table.Cell().ValueCell(Visit.ClarificationSaccharimeter.QuartzReading);
                table.Cell().ValueCell(Visit.ClarificationSaccharimeter.CalibrationCertificate);
                table.Cell().ValueCell(Visit.ClarificationSaccharimeter.TubeCleaning);
                table.Cell().ValueCell(Visit.ClarificationSaccharimeter.ClearCollingCooler);
                table.Cell().ColumnSpan(4).SubLabelCell("Observações");
                table.Cell().ColumnSpan(4).ValueCell(Visit.ClarificationSaccharimeter.Observations10);
            });
    }

    private void ComposeBenchmarkingEquipment(IContainer container)
    {
        container
            .Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.RelativeColumn();
                    columns.RelativeColumn();
                    columns.RelativeColumn();
                    columns.RelativeColumn();
                    columns.RelativeColumn();
                    columns.RelativeColumn();
                    columns.RelativeColumn();
                    columns.RelativeColumn();
                    columns.RelativeColumn();
                    columns.RelativeColumn();
                });

                table.ExtendLastCellsToTableBottom();
                table.Header(h => h.Cell().ColumnSpan(10).LabelTitleCell("Equipamentos de Aferição/Medias"));

                table.Cell().ColumnSpan(10).LabelCell("Prensa/Desintegrador/Temperatura");

                table.Cell().ColumnSpan(3).SubLabelCell("Célula Carga");
                table.Cell().ColumnSpan(3).SubLabelCell("Termômetro");
                table.Cell().ColumnSpan(2).SubLabelCell("Tacômetro");
                table.Cell().ColumnSpan(2).SubLabelCell("Paquímetro");

                table.Cell().ColumnSpan(3).ValueCell(Visit.BenchmarkingEquipment.LoadCell);
                table.Cell().ColumnSpan(3).ValueCell(Visit.BenchmarkingEquipment.Thermometer);
                table.Cell().ColumnSpan(2).ValueCell(Visit.BenchmarkingEquipment.Tachometer);
                table.Cell().ColumnSpan(2).ValueCell(Visit.BenchmarkingEquipment.Pachymeter);


                table.Cell().ColumnSpan(10).LabelCell("Pesos Padrões");
                table.Cell().ColumnSpan(4).SubLabelCell("500gm");
                table.Cell().ColumnSpan(3).SubLabelCell("100gm");
                table.Cell().ColumnSpan(3).SubLabelCell("1gm");

                table.Cell().ColumnSpan(4).ValueCell(Visit.BenchmarkingEquipment.Gm500);
                table.Cell().ColumnSpan(3).ValueCell(Visit.BenchmarkingEquipment.Gm100);
                table.Cell().ColumnSpan(3).ValueCell(Visit.BenchmarkingEquipment.Gm1);

                table.Cell().ColumnSpan(4).LabelCell("Linearidade/Repetitividade-Sacarose(PA)");
                table.Cell().ColumnSpan(6).LabelCell("Refratômetro(Faixa)");

                table.Cell().ColumnSpan(4).SubLabelCell("Teste de Sacarose");
                table.Cell().ColumnSpan(2).SubLabelCell("10º");
                table.Cell().ColumnSpan(2).SubLabelCell("20º");
                table.Cell().ColumnSpan(2).SubLabelCell("30º");

                table.Cell().ColumnSpan(4).ValueCell(Visit.BenchmarkingEquipment.SucroseTest);

                table.Cell().ColumnSpan(2).ValueCell(Visit.BenchmarkingEquipment.Range10);
                table.Cell().ColumnSpan(2).ValueCell(Visit.BenchmarkingEquipment.Range20);
                table.Cell().ColumnSpan(2).ValueCell(Visit.BenchmarkingEquipment.Range30);


                table.Cell().ColumnSpan(10).LabelCell("Sacarímetro");

                table.Cell().ColumnSpan(2).SubLabelCell("25z");
                table.Cell().ColumnSpan(2).SubLabelCell("50z");
                table.Cell().ColumnSpan(3).SubLabelCell("75z");
                table.Cell().ColumnSpan(3).SubLabelCell("100z");

                table.Cell().ColumnSpan(2).ValueCell(Visit.BenchmarkingEquipment.Z25);
                table.Cell().ColumnSpan(2).ValueCell(Visit.BenchmarkingEquipment.Z50);
                table.Cell().ColumnSpan(3).ValueCell(Visit.BenchmarkingEquipment.Z75);
                table.Cell().ColumnSpan(3).ValueCell(Visit.BenchmarkingEquipment.Z100);
                table.Cell().ColumnSpan(10).SubLabelCell("Observações");
                table.Cell().ColumnSpan(10).ValueCell(Visit.BenchmarkingEquipment.Observations11);

                table.Cell().ColumnSpan(10).LabelCell("Moagem");
                table.Cell().ColumnSpan(2).SubLabelCell("Previsto");
                table.Cell().ColumnSpan(2).SubLabelCell("Realizado");
                table.Cell().ColumnSpan(2).SubLabelCell("Percentual");
                table.Cell().ColumnSpan(2).SubLabelCell("Safra Passada");
                table.Cell().ColumnSpan(2).SubLabelCell("Variação Entre Safras");

                table.Cell().ColumnSpan(2).DecimalValueCell(Visit.BenchmarkingEquipment.ExpectedCrop);
                table.Cell().ColumnSpan(2).DecimalValueCell(Visit.BenchmarkingEquipment.AccomplishedCrop);
                table.Cell().ColumnSpan(2).DecimalValueCell(Visit.BenchmarkingEquipment.PercentageRealized);
                table.Cell().ColumnSpan(2).DecimalValueCell(Visit.BenchmarkingEquipment.PreviousCrop);
                table.Cell().ColumnSpan(2).DecimalValueCell(Visit.BenchmarkingEquipment.VariationBetweenCrops);

                table.Cell().ColumnSpan(10).LabelCell("Resultados Analíticos");

                table.Cell().ColumnSpan(1).SubLabelCell(string.Empty);
                table.Cell().ColumnSpan(3).SubLabelCell("Atual");
                table.Cell().ColumnSpan(3).SubLabelCell("Anterior");
                table.Cell().ColumnSpan(3).SubLabelCell("Variação");

                table.Cell().ColumnSpan(1).SubLabelCell("Fibra");
                table.Cell().ColumnSpan(3).DecimalValueCell(Visit.BenchmarkingEquipment.CurrentFiber);
                table.Cell().ColumnSpan(3).DecimalValueCell(Visit.BenchmarkingEquipment.PreviousFiber);
                table.Cell().ColumnSpan(3).DecimalValueCell(Visit.BenchmarkingEquipment.FiberVariation);

                table.Cell().ColumnSpan(1).SubLabelCell("ATR");
                table.Cell().ColumnSpan(3).DecimalValueCell(Visit.BenchmarkingEquipment.CurrentAtr);
                table.Cell().ColumnSpan(3).DecimalValueCell(Visit.BenchmarkingEquipment.PreviousAtr);
                table.Cell().ColumnSpan(3).DecimalValueCell(Visit.BenchmarkingEquipment.AtrVariation);
            });
    }

    private void ComposeResultComparison(IContainer container)
    {
        container
            .Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.RelativeColumn();
                    columns.RelativeColumn();
                    columns.RelativeColumn();
                    columns.RelativeColumn();
                    columns.RelativeColumn();
                    columns.RelativeColumn();
                    columns.RelativeColumn();
                });

                table.ExtendLastCellsToTableBottom();
                table.Cell().ColumnSpan(7).LabelTitleCell("Comparação de Resultados Unid.Industrial x Consecana");


                table.Cell().ColumnSpan(1).SubLabelCell("O.C");
                table.Cell().ColumnSpan(1).SubLabelCell("Fazenda");
                table.Cell().ColumnSpan(1).SubLabelCell("Propietário");
                table.Cell().ColumnSpan(1).SubLabelCell("Clarificante");
                table.Cell().ColumnSpan(1).SubLabelCell("PBU");
                table.Cell().ColumnSpan(1).SubLabelCell("BRIX");
                table.Cell().ColumnSpan(1).SubLabelCell("Leitura Sacarimétrica");

                table.Cell().ColumnSpan(1).ValueCell(Visit.SystemConsistency.Oc);
                table.Cell().ColumnSpan(1).ValueCell(Visit.SystemConsistency.Farm);
                table.Cell().ColumnSpan(1).ValueCell(Visit.SystemConsistency.Owner);
                table.Cell().ColumnSpan(1)
                    .ValueCell((Visit.SystemConsistency.Clarifier == null
                        ? string.Empty
                        : Visit.SystemConsistency.Clarifier.ToString()) ?? string.Empty);
                table.Cell().ColumnSpan(1).DecimalValueCell(Visit.SystemConsistency.PlantSugarcaneAnalysis.Pbu);
                table.Cell().ColumnSpan(1).DecimalValueCell(Visit.SystemConsistency.PlantSugarcaneAnalysis.Brix);
                table.Cell().ColumnSpan(1).DecimalValueCell(Visit.SystemConsistency.PlantSugarcaneAnalysis.Ls);

                table.Cell().SubLabelCell(string.Empty);
                table.Cell().SubLabelCell("Pureza");
                table.Cell().SubLabelCell("POL");
                table.Cell().SubLabelCell("Fibra");
                table.Cell().SubLabelCell("PCC");
                table.Cell().SubLabelCell("AR");
                table.Cell().SubLabelCell("ATR");

                table.Cell().SubLabelCell("Usina");
                table.Cell().DecimalValueCell(Visit.SystemConsistency.PlantSugarcaneAnalysis.Purity);
                table.Cell().DecimalValueCell(Visit.SystemConsistency.PlantSugarcaneAnalysis.Pol);
                table.Cell().DecimalValueCell(Visit.SystemConsistency.PlantSugarcaneAnalysis.Fiber);
                table.Cell().DecimalValueCell(Visit.SystemConsistency.PlantSugarcaneAnalysis.Pcc);
                table.Cell().DecimalValueCell(Visit.SystemConsistency.PlantSugarcaneAnalysis.Ar);
                table.Cell().DecimalValueCell(Visit.SystemConsistency.PlantSugarcaneAnalysis.Atr);

                table.Cell().SubLabelCell("Consecana");
                table.Cell().DecimalValueCell(Visit.SystemConsistency.ConsecanaSugarcaneAnalysis.Purity);
                table.Cell().DecimalValueCell(Visit.SystemConsistency.ConsecanaSugarcaneAnalysis.Pol);
                table.Cell().DecimalValueCell(Visit.SystemConsistency.ConsecanaSugarcaneAnalysis.Fiber);
                table.Cell().DecimalValueCell(Visit.SystemConsistency.ConsecanaSugarcaneAnalysis.Pcc);
                table.Cell().DecimalValueCell(Visit.SystemConsistency.ConsecanaSugarcaneAnalysis.Ar);
                table.Cell().DecimalValueCell(Visit.SystemConsistency.ConsecanaSugarcaneAnalysis.Atr);

                table.Cell().SubLabelCell("Variação");
                table.Cell().DecimalValueCell(Visit.SystemConsistency.DifferencePurity);
                table.Cell().DecimalValueCell(Visit.SystemConsistency.DifferencePol);
                table.Cell().DecimalValueCell(Visit.SystemConsistency.DifferenceFiber);
                table.Cell().DecimalValueCell(Visit.SystemConsistency.DifferencePcc);
                table.Cell().DecimalValueCell(Visit.SystemConsistency.DifferenceAr);
                table.Cell().DecimalValueCell(Visit.SystemConsistency.DifferenceAtr);

                table.Cell().ColumnSpan(7).SubLabelCell("Observações");
                table.Cell().ColumnSpan(7).ValueCell(Visit.SystemConsistency.Observations);
            });
    }

    private void ComposeConclusion(IContainer container)
    {
        container
            .Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.RelativeColumn();
                    columns.RelativeColumn();
                });

                table.ExtendLastCellsToTableBottom();
                table.Cell().ColumnSpan(2).LabelTitleCell("Conclusão");

                table.Cell().ColumnSpan(1).SubLabelCell("Desempenho do Fiscal");
                table.Cell().ColumnSpan(1).SubLabelCell("Desempenho Laboratório");
                table.Cell().ColumnSpan(1).ValueCell(Visit.Conclusion.InspectorPerformance);
                table.Cell().ColumnSpan(1).ValueCell(Visit.Conclusion.LaboratoryReceptivity);

                table.Cell().ColumnSpan(2).SubLabelCell("Pendências");
                table.Cell().ColumnSpan(2).ValueCell(Visit.Conclusion.Pendencies);

                table.Cell().ColumnSpan(2).SubLabelCell("Observações Sobre a Visita");
                table.Cell().ColumnSpan(2).ValueCell(Visit.Conclusion.Observations);
            });
    }

    private void ComposeImages(IContainer container)
    {
        container
            .Column(column =>
            {
                column.Spacing(10);
                for (var i = 0; i < Images.Count; i += 2)
                {
                    var i2 = i;
                    column.Item().Row(row =>
                    {
                        row.Spacing(10);

                        var i1 = i2;
                        row.RelativeItem()
                            .Column(innerColumn =>
                            {
                                row.Spacing(20);
                                innerColumn
                                    .Item()
                                    .Border(0.3f)
                                    .Image(Images[i1].Data);
                                innerColumn.Item()
                                    .ValueCell(Images[i1].Description);
                            });

                        if (i2 + 1 < Images.Count)
                        {
                            row.RelativeItem()
                                .Column(innerColumn =>
                                {
                                    row.Spacing(10);
                                    innerColumn
                                        .Item()
                                        .Border(0.3f)
                                        .Image(Images[i2 + 1].Data);
                                    innerColumn
                                        .Item()
                                        .ValueCell(Images[i2 + 1].Description);
                                });
                        }
                        else
                        {
                            row.RelativeItem();
                        }
                    });
                }
            });
    }

    private void ComposeFooter(IContainer container)
    {
        container
            .Text(x =>
            {
                x.CurrentPageNumber();
                x.Span("/");
                x.TotalPages();
            });
    }
}