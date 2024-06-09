using FiscalLabService.App.Dtos;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

namespace FiscalLabService.App.Documents;

public class VisitDocument(VisitDto model) : IDocument
{
    private VisitDto Model { get; } = model;
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
            foreach (var modelImage in Model.Images)
            {
                column.Item().EnsureSpace().Element(c => ComposeImages(c, modelImage));
            }
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
                        $"{Model.BasicInformation.VisitDate.ToString("dd/MM/yyyy")} {Model.BasicInformation.VisitTime.ToString("HH:mm:ss")}");
                table.Cell().ValueCell(Model.BasicInformation.Consultant);
                table.Cell().ValueCell(Model.BasicInformation.Plant.Name);
                table.Cell().ValueCell(Model.BasicInformation.Association.Name);

                table.Cell().SubLabelCell("Líder do Turno");
                table.Cell().SubLabelCell("Fiscal do Turno");
                table.Cell().ColumnSpan(2).SubLabelCell("Encarregado(a) Lab. Sacarose");
                table.Cell().ValueCell(Model.BasicInformation.Leader);
                table.Cell().ValueCell(Model.BasicInformation.Inspector);
                table.Cell().ColumnSpan(2).ValueCell(Model.BasicInformation.LaboratoryLeader);
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
                table.Cell().ColumnSpan(2).ValueCell(Model.SugarcaneBalance.InScale);
                table.Cell().ColumnSpan(2).ValueCell(Model.SugarcaneBalance.OutScale);
                table.Cell().ColumnSpan(2).ValueCell(Model.SugarcaneBalance.CargoDraw);
                table.Cell().ColumnSpan(6).SubLabelCell("Observações");
                table.Cell().ColumnSpan(6).ValueCell(Model.SugarcaneBalance.ScaleObservations);

                table.Cell().ColumnSpan(6).LabelCell("Calibragens");
                table.Cell().ColumnSpan(1).SubLabelCell("1º Calibração");
                table.Cell().ColumnSpan(1).SubLabelCell("2º Calibração");
                table.Cell().ColumnSpan(2).SubLabelCell("Orgão Responsavel");
                table.Cell().ColumnSpan(2).SubLabelCell("Certificado de Calibração");
                table.Cell().ColumnSpan(1).ValueCell(Model.SugarcaneBalance.Calibration1);
                table.Cell().ColumnSpan(1).ValueCell(Model.SugarcaneBalance.Calibration2);
                table.Cell().ColumnSpan(2).ValueCell(Model.SugarcaneBalance.ResponsibleBody);
                table.Cell().ColumnSpan(2).ValueCell(Model.SugarcaneBalance.CalibrationCertificate);
                table.Cell().ColumnSpan(6).SubLabelCell("Observações");
                table.Cell().ColumnSpan(6).ValueCell(Model.SugarcaneBalance.Observations1);

                table.Cell().ColumnSpan(6).LabelCell("Porcentagens Analisadas");
                table.Cell().ColumnSpan(1).SubLabelCell("Usina");
                table.Cell().ColumnSpan(1).SubLabelCell("Fornecedor");
                table.Cell().ColumnSpan(2).SubLabelCell("Usina/Fazenda");
                table.Cell().ColumnSpan(2).SubLabelCell("Fornecedor/Fazenda");
                table.Cell().ColumnSpan(1).ValueCell(Model.SugarcaneBalance.PlantPercentage);
                table.Cell().ColumnSpan(1).ValueCell(Model.SugarcaneBalance.ProviderPercentage);
                table.Cell().ColumnSpan(2).ValueCell(Model.SugarcaneBalance.PlantFarmPercentage);
                table.Cell().ColumnSpan(2).ValueCell(Model.SugarcaneBalance.FarmProviderPercentage);
                table.Cell().ColumnSpan(6).SubLabelCell("Observações");
                table.Cell().ColumnSpan(6).ValueCell(Model.SugarcaneBalance.Observations2);

                if (Model.BalanceTests.Count == 0) return;

                table.Cell().ColumnSpan(6).LabelCell("Testes");
                table.Cell().SubLabelCell("Placa");
                table.Cell().ColumnSpan(2).SubLabelCell("Entrada");
                table.Cell().ColumnSpan(2).SubLabelCell("Saída");
                table.Cell().SubLabelCell("Variação");

                foreach (var modelBalanceTest in Model.BalanceTests)
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
                table.Cell().ValueCell(Model.DesintegratorProbe.ProbeType);
                table.Cell().ValueCell(Model.DesintegratorProbe.TubeInserted);
                table.Cell().ValueCell(Model.DesintegratorProbe.TubeDischarged);
                table.Cell().ValueCell(Model.DesintegratorProbe.Collect);
                table.Cell().ValueCell(Model.DesintegratorProbe.SampleAmount);
                table.Cell().SubLabelCell("Extração do caldo");
                table.Cell().SubLabelCell("Posição da carga");
                table.Cell().SubLabelCell("Coroa dentada");
                table.Cell().ColumnSpan(2).SubLabelCell("Tipo coroa");
                table.Cell().ValueCell(Model.DesintegratorProbe.BrothExtraction);
                table.Cell().ValueCell(Model.DesintegratorProbe.LoadPosition);
                table.Cell().ValueCell(Model.DesintegratorProbe.ToothedCrown);
                table.Cell().ColumnSpan(2).ValueCell(Model.DesintegratorProbe.ToothedCrownType);
                table.Cell().ColumnSpan(5).SubLabelCell("Observações");
                table.Cell().ColumnSpan(5).ValueCell(Model.DesintegratorProbe.Observations3);


                table.Cell().ColumnSpan(5).LabelCell("Desintegrador");
                table.Cell().SubLabelCell("Amostras homogênias");
                table.Cell().SubLabelCell("Betoneira limpa a cada amostra");
                table.Cell().SubLabelCell("Conservação facas");
                table.Cell().SubLabelCell("RPM do Desintegrador");
                table.Cell().SubLabelCell("Conservaçao contra-faca");
                table.Cell().ValueCell(Model.DesintegratorProbe.HomogeneousSamples);
                table.Cell().ValueCell(Model.DesintegratorProbe.CleanMixer);
                table.Cell().ValueCell(Model.DesintegratorProbe.KnifeConservation);
                table.Cell().ValueCell(Model.DesintegratorProbe.DesintegratorRpm);
                table.Cell().ValueCell(Model.DesintegratorProbe.AgainstKnifeConservation);
                table.Cell().SubLabelCell("Índice de preparo");
                table.Cell().SubLabelCell("Distância faca/contra-faca");
                table.Cell().SubLabelCell("Ultima troca navalhas");
                table.Cell().ColumnSpan(2).SubLabelCell("Conservação martelo");
                table.Cell().ValueCell(Model.DesintegratorProbe.PreparationIndex);
                table.Cell().ValueCell(Model.DesintegratorProbe.KnifeAgainstKnifeDistance);
                var sharpenedOrReplacedKnifeAt = Model.DesintegratorProbe.SharpenedOrReplacedKnifeAt == null
                    ? "-"
                    : Model.DesintegratorProbe.SharpenedOrReplacedKnifeAt.Value.ToString("dd/MM/yyyy");
                table.Cell().ValueCell(sharpenedOrReplacedKnifeAt);
                table.Cell().ColumnSpan(2).ValueCell(Model.DesintegratorProbe.HammerConservation);
                table.Cell().ColumnSpan(5).SubLabelCell("Observações");
                table.Cell().ColumnSpan(5).ValueCell(Model.DesintegratorProbe.Observations4);
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
                table.Cell().ValueCell(Model.AnalyticalBalance.HomogeneousWeight);
                table.Cell().ValueCell(Model.AnalyticalBalance.FinalWeight);
                table.Cell().ValueCell(Model.AnalyticalBalance.CalibratedBalance);
                table.Cell().ValueCell(Model.AnalyticalBalance.LeveledBalance);
                table.Cell().ValueCell(Model.AnalyticalBalance.CalibrationCertificateBalance);
                table.Cell().ColumnSpan(5).SubLabelCell("Observações");
                table.Cell().ColumnSpan(5).ValueCell(Model.AnalyticalBalance.Observations6);

                table.Cell().ColumnSpan(5).LabelCell("Temperatura");
                table.Cell().ColumnSpan(1).SubLabelCell("Média (20ºC ± 5)");
                table.Cell().ColumnSpan(4).ValueCell(Model.AnalyticalBalance.AverageAmbientTemperature);
                table.Cell().ColumnSpan(5).SubLabelCell("Observações");
                table.Cell().ColumnSpan(5).ValueCell(Model.AnalyticalBalance.Observations5);
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
                table.Cell().ValueCell(Model.PressRefractometer.PressureGaugeCertificated);
                table.Cell().ValueCell(Model.PressRefractometer.DiscardCup);
                table.Cell().ValueCell(Model.PressRefractometer.CollectorBottle);
                table.Cell().ValueCell(Model.PressRefractometer.Pressure);
                table.Cell().ValueCell(Model.PressRefractometer.Timer);
                table.Cell().ValueCell(Model.PressRefractometer.PressCleaning);
                table.Cell().ColumnSpan(6).SubLabelCell("Observações");
                table.Cell().ColumnSpan(6).ValueCell(Model.PressRefractometer.Observations7);

                table.Cell().ColumnSpan(6).LabelCell("Refratômetro");
                table.Cell().SubLabelCell("Hômogenização do caldo");
                table.Cell().SubLabelCell("Certificado de calibração");
                table.Cell().SubLabelCell("Precisão da leitura");
                table.Cell().SubLabelCell("Aferição");
                table.Cell().SubLabelCell("Limpeza");
                table.Cell().SubLabelCell("Temperatura interna");
                table.Cell().ValueCell(Model.PressRefractometer.BrothHomogenization);
                table.Cell().ValueCell(Model.PressRefractometer.RefractometerCalibrationCertificate);
                table.Cell().ValueCell(Model.PressRefractometer.PrecisionReading);
                table.Cell().ValueCell(Model.PressRefractometer.BrothHomogenization);
                table.Cell().ValueCell(Model.PressRefractometer.PressCleaning);
                table.Cell().ValueCell(Model.PressRefractometer.InternalTemperature);
                table.Cell().ColumnSpan(6).SubLabelCell("Observações");
                table.Cell().ColumnSpan(6).ValueCell(Model.PressRefractometer.Observations8);
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
                table.Cell().ValueCell(Model.ClarificationSaccharimeter.Bottle);
                table.Cell().ValueCell(Model.ClarificationSaccharimeter.Agitation);
                table.Cell().ValueCell(Model.ClarificationSaccharimeter.HasDilution);
                table.Cell().ValueCell(Model.ClarificationSaccharimeter.Clarifier);
                table.Cell().ColumnSpan(2).SubLabelCell("Qtd. de clarificante (200ml)");
                table.Cell().SubLabelCell("Volume clarificado");
                table.Cell().SubLabelCell("100ml após limpeza do sacarimetro");
                table.Cell().ColumnSpan(2).ValueCell(Model.ClarificationSaccharimeter.ClarifierAmount);
                table.Cell().ValueCell(Model.ClarificationSaccharimeter.BottleClarifiedVolume);
                table.Cell().ValueCell(Model.ClarificationSaccharimeter.BottleAfterClarifiedVolume);
                table.Cell().ColumnSpan(4).SubLabelCell("Observações");
                table.Cell().ColumnSpan(4).ValueCell(Model.ClarificationSaccharimeter.Observations9);

                table.Cell().ColumnSpan(4).ColumnSpan(4).LabelCell("Sacarímetro");

                table.Cell().SubLabelCell("Estabilização");
                table.Cell().SubLabelCell("Aferição");
                table.Cell().SubLabelCell("Padrão quartzo");
                table.Cell().SubLabelCell("Resultado quartzo");
                table.Cell().ValueCell(Model.ClarificationSaccharimeter.Stabilization);
                table.Cell().ValueCell(Model.ClarificationSaccharimeter.Benchmarking);
                table.Cell().ValueCell(Model.ClarificationSaccharimeter.QuartzPattern);
                table.Cell().ValueCell(Model.ClarificationSaccharimeter.QuartzResult);
                table.Cell().SubLabelCell("Leitura quartzo");
                table.Cell().SubLabelCell("Certificado de calibração");
                table.Cell().SubLabelCell("Limpeza tubo");
                table.Cell().SubLabelCell("Cooler de resfriamento limpo");
                table.Cell().ValueCell(Model.ClarificationSaccharimeter.QuartzReading);
                table.Cell().ValueCell(Model.ClarificationSaccharimeter.CalibrationCertificate);
                table.Cell().ValueCell(Model.ClarificationSaccharimeter.TubeCleaning);
                table.Cell().ValueCell(Model.ClarificationSaccharimeter.ClearCollingCooler);
                table.Cell().ColumnSpan(4).SubLabelCell("Observações");
                table.Cell().ColumnSpan(4).ValueCell(Model.ClarificationSaccharimeter.Observations10);
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

                table.Cell().ColumnSpan(3).ValueCell(Model.BenchmarkingEquipment.LoadCell);
                table.Cell().ColumnSpan(3).ValueCell(Model.BenchmarkingEquipment.Thermometer);
                table.Cell().ColumnSpan(2).ValueCell(Model.BenchmarkingEquipment.Tachometer);
                table.Cell().ColumnSpan(2).ValueCell(Model.BenchmarkingEquipment.Pachymeter);


                table.Cell().ColumnSpan(10).LabelCell("Pesos Padrões");
                table.Cell().ColumnSpan(4).SubLabelCell("500gm");
                table.Cell().ColumnSpan(3).SubLabelCell("100gm");
                table.Cell().ColumnSpan(3).SubLabelCell("1gm");

                table.Cell().ColumnSpan(4).ValueCell(Model.BenchmarkingEquipment.Gm500);
                table.Cell().ColumnSpan(3).ValueCell(Model.BenchmarkingEquipment.Gm100);
                table.Cell().ColumnSpan(3).ValueCell(Model.BenchmarkingEquipment.Gm1);

                table.Cell().ColumnSpan(4).LabelCell("Linearidade/Repetitividade-Sacarose(PA)");
                table.Cell().ColumnSpan(6).LabelCell("Refratômetro(Faixa)");

                table.Cell().ColumnSpan(4).SubLabelCell("Teste de Sacarose");
                table.Cell().ColumnSpan(2).SubLabelCell("10º");
                table.Cell().ColumnSpan(2).SubLabelCell("20º");
                table.Cell().ColumnSpan(2).SubLabelCell("30º");

                table.Cell().ColumnSpan(4).ValueCell(Model.BenchmarkingEquipment.SucroseTest);

                table.Cell().ColumnSpan(2).ValueCell(Model.BenchmarkingEquipment.Range10);
                table.Cell().ColumnSpan(2).ValueCell(Model.BenchmarkingEquipment.Range20);
                table.Cell().ColumnSpan(2).ValueCell(Model.BenchmarkingEquipment.Range30);


                table.Cell().ColumnSpan(10).LabelCell("Sacarímetro");

                table.Cell().ColumnSpan(2).SubLabelCell("25z");
                table.Cell().ColumnSpan(2).SubLabelCell("50z");
                table.Cell().ColumnSpan(3).SubLabelCell("75z");
                table.Cell().ColumnSpan(3).SubLabelCell("100z");

                table.Cell().ColumnSpan(2).ValueCell(Model.BenchmarkingEquipment.Z25);
                table.Cell().ColumnSpan(2).ValueCell(Model.BenchmarkingEquipment.Z50);
                table.Cell().ColumnSpan(3).ValueCell(Model.BenchmarkingEquipment.Z75);
                table.Cell().ColumnSpan(3).ValueCell(Model.BenchmarkingEquipment.Z100);
                table.Cell().ColumnSpan(10).SubLabelCell("Observações");
                table.Cell().ColumnSpan(10).ValueCell(Model.BenchmarkingEquipment.Observations11);

                table.Cell().ColumnSpan(10).LabelCell("Moagem");
                table.Cell().ColumnSpan(2).SubLabelCell("Previsto");
                table.Cell().ColumnSpan(2).SubLabelCell("Realizado");
                table.Cell().ColumnSpan(2).SubLabelCell("Percentual");
                table.Cell().ColumnSpan(2).SubLabelCell("Safra Passada");
                table.Cell().ColumnSpan(2).SubLabelCell("Variação Entre Safras");

                table.Cell().ColumnSpan(2).DecimalValueCell(Model.BenchmarkingEquipment.ExpectedCrop);
                table.Cell().ColumnSpan(2).DecimalValueCell(Model.BenchmarkingEquipment.AccomplishedCrop);
                table.Cell().ColumnSpan(2).DecimalValueCell(Model.BenchmarkingEquipment.PercentageRealized);
                table.Cell().ColumnSpan(2).DecimalValueCell(Model.BenchmarkingEquipment.PreviousCrop);
                table.Cell().ColumnSpan(2).DecimalValueCell(Model.BenchmarkingEquipment.VariationBetweenCrops);

                table.Cell().ColumnSpan(10).LabelCell("Resultados Analíticos");

                table.Cell().ColumnSpan(1).SubLabelCell(string.Empty);
                table.Cell().ColumnSpan(3).SubLabelCell("Atual");
                table.Cell().ColumnSpan(3).SubLabelCell("Anterior");
                table.Cell().ColumnSpan(3).SubLabelCell("Variação");

                table.Cell().ColumnSpan(1).SubLabelCell("Fibra");
                table.Cell().ColumnSpan(3).DecimalValueCell(Model.BenchmarkingEquipment.CurrentFiber);
                table.Cell().ColumnSpan(3).DecimalValueCell(Model.BenchmarkingEquipment.PreviousFiber);
                table.Cell().ColumnSpan(3).DecimalValueCell(Model.BenchmarkingEquipment.FiberVariation);

                table.Cell().ColumnSpan(1).SubLabelCell("ATR");
                table.Cell().ColumnSpan(3).DecimalValueCell(Model.BenchmarkingEquipment.CurrentAtr);
                table.Cell().ColumnSpan(3).DecimalValueCell(Model.BenchmarkingEquipment.PreviousAtr);
                table.Cell().ColumnSpan(3).DecimalValueCell(Model.BenchmarkingEquipment.AtrVariation);
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

                table.Cell().ColumnSpan(1).ValueCell(Model.SystemConsistency.Oc);
                table.Cell().ColumnSpan(1).ValueCell(Model.SystemConsistency.Farm);
                table.Cell().ColumnSpan(1).ValueCell(Model.SystemConsistency.Owner);
                table.Cell().ColumnSpan(1).ValueCell(Model.SystemConsistency.Clarifier.ToString());
                table.Cell().ColumnSpan(1).DecimalValueCell(Model.SystemConsistency.PlantSugarcaneAnalysis.Pbu);
                table.Cell().ColumnSpan(1).DecimalValueCell(Model.SystemConsistency.PlantSugarcaneAnalysis.Brix);
                table.Cell().ColumnSpan(1).DecimalValueCell(Model.SystemConsistency.PlantSugarcaneAnalysis.Ls);

                table.Cell().SubLabelCell(string.Empty);
                table.Cell().SubLabelCell("Pureza");
                table.Cell().SubLabelCell("POL");
                table.Cell().SubLabelCell("Fibra");
                table.Cell().SubLabelCell("PCC");
                table.Cell().SubLabelCell("AR");
                table.Cell().SubLabelCell("ATR");

                table.Cell().SubLabelCell("Usina");
                table.Cell().DecimalValueCell(Model.SystemConsistency.PlantSugarcaneAnalysis.Purity);
                table.Cell().DecimalValueCell(Model.SystemConsistency.PlantSugarcaneAnalysis.Pol);
                table.Cell().DecimalValueCell(Model.SystemConsistency.PlantSugarcaneAnalysis.Fiber);
                table.Cell().DecimalValueCell(Model.SystemConsistency.PlantSugarcaneAnalysis.Pcc);
                table.Cell().DecimalValueCell(Model.SystemConsistency.PlantSugarcaneAnalysis.Ar);
                table.Cell().DecimalValueCell(Model.SystemConsistency.PlantSugarcaneAnalysis.Atr);

                table.Cell().SubLabelCell("Consecana");
                table.Cell().DecimalValueCell(Model.SystemConsistency.ConsecanaSugarcaneAnalysis.Purity);
                table.Cell().DecimalValueCell(Model.SystemConsistency.ConsecanaSugarcaneAnalysis.Pol);
                table.Cell().DecimalValueCell(Model.SystemConsistency.ConsecanaSugarcaneAnalysis.Fiber);
                table.Cell().DecimalValueCell(Model.SystemConsistency.ConsecanaSugarcaneAnalysis.Pcc);
                table.Cell().DecimalValueCell(Model.SystemConsistency.ConsecanaSugarcaneAnalysis.Ar);
                table.Cell().DecimalValueCell(Model.SystemConsistency.ConsecanaSugarcaneAnalysis.Atr);

                table.Cell().SubLabelCell("Variação");
                table.Cell().DecimalValueCell(Model.SystemConsistency.DifferencePurity);
                table.Cell().DecimalValueCell(Model.SystemConsistency.DifferencePol);
                table.Cell().DecimalValueCell(Model.SystemConsistency.DifferenceFiber);
                table.Cell().DecimalValueCell(Model.SystemConsistency.DifferencePcc);
                table.Cell().DecimalValueCell(Model.SystemConsistency.DifferenceAr);
                table.Cell().DecimalValueCell(Model.SystemConsistency.DifferenceAtr);

                table.Cell().ColumnSpan(7).SubLabelCell("Observações");
                table.Cell().ColumnSpan(7).ValueCell(Model.SystemConsistency.Observations);
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
                table.Cell().ColumnSpan(1).ValueCell(Model.Conclusion.InspectorPerformance);
                table.Cell().ColumnSpan(1).ValueCell(Model.Conclusion.LaboratoryReceptivity);

                table.Cell().ColumnSpan(2).SubLabelCell("Pendências");
                table.Cell().ColumnSpan(2).ValueCell(Model.Conclusion.Pendencies);

                table.Cell().ColumnSpan(2).SubLabelCell("Observações Sobre a Visita");
                table.Cell().ColumnSpan(2).ValueCell(Model.Conclusion.Observations);
            });
    }

    private void ComposeImages(IContainer container, ImageDto image)
    {
        var imageBytes = Convert.FromBase64String(image.Url.Split(",")[1]);
        container
            .Table(table =>
            {
                table.ColumnsDefinition(columns => { columns.RelativeColumn(); });

                table.ExtendLastCellsToTableBottom();

                table.Cell().AlignCenter().Width(5, Unit.Inch).Image(imageBytes).WithCompressionQuality(ImageCompressionQuality.High);
                table.Cell().AlignCenter().Width(5, Unit.Inch).SubLabelCell("Descrição");
                table.Cell().AlignCenter().Width(5, Unit.Inch).ValueCell(image.Description);
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