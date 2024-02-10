using FiscalLabService.App.Dtos;
using FiscalLabService.Domain.Entities;
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
            .FontSize(20)
            .Bold()
            .FontColor(DocumentConstants.HeaderTitleColor);

        var subTitleStyle = TextStyle.Default
            .FontSize(13)
            .Bold()
            .FontColor(DocumentConstants.HeaderSubTitleColor);

        var descriptionStyle = TextStyle.Default
            .FontSize(10)
            .SemiBold()
            .FontColor(DocumentConstants.HeaderSubTitleColor);

        container.Row(row =>
        {
            row.RelativeItem()
                .Column(column =>
                {
                    column.Item().Text($"Visita #{Model.Id}").Style(titleStyle);

                    column.Item().Text(text =>
                    {
                        text
                            .Span("Data: ")
                            .Style(subTitleStyle);

                        text
                            .Span(
                                $"{Model.BasicInformation.VisitDate:dd/MM/yyyy} {Model.BasicInformation.VisitTime:HH:mm:ss}")
                            .Style(subTitleStyle);
                    });

                    // column.Item()
                    //     .Text(text =>
                    //     {
                    //         text
                    //             .Span(DocumentConstants.HeaderDescription)
                    //             .Style(descriptionStyle);
                    //     });
                });

            row.ConstantItem(100).Height(50).Placeholder();
        });
    }

    private void ComposeContent(IContainer container)
    {
        // container
        //     .PaddingVertical(40)
        //     .Height(250)
        //     .Background(Colors.Grey.Lighten3)
        //     .AlignCenter()
        //     .AlignMiddle()
        //     .Text("Content").FontSize(16);

        container.PaddingVertical(20).Column(column =>
        {
            column.Spacing(10);

            column.Item().Element(ComposeBasicData);
            column.Item().Element(ComposeCaneBalance);
            column.Item().Element(ComposeCaneBalanceCalibrations);
            column.Item().Element(ComposeCaneBalanceTests);
            column.Item().Element(ComposeAnalyzedPercentage);
            column.Item().Element(ComposeSampleCollect);
            column.Item().Element(ComposeSampleDisintegration);
            column.Item().Element(e => e.PageBreak());
            column.Item().Element(ComposeAnalyticalBalance);
            column.Item().Element(ComposePress);
            column.Item().Element(ComposeRefractometer);
            column.Item().Element(ComposeClassification);
            column.Item().Element(ComposeSaccharometer);
            column.Item().Element(e => e.PageBreak());
            column.Item().Element(ComposeMeasurementEquipment);
            column.Item().Element(ComposeWeightedAverages);
            column.Item().Element(ComposeCrop);
            column.Item().Element(ComposeResultComparison);
            column.Item().Element(ComposeImages);
        });
    }

    private void ComposeBasicData(IContainer container)
    {
        container
            .Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.ConstantColumn(100);
                    columns.RelativeColumn();
                    columns.ConstantColumn(100);
                    columns.RelativeColumn();
                });

                table.ExtendLastCellsToTableBottom();
                table.Cell().ColumnSpan(4).LabelTitleCell("Dados Básicos");

                table.Cell().LabelCell("Consultor");
                table.Cell().ValueCell(Model.BasicInformation.Consultant);
                
                table.Cell().LabelCell("Data");
                table.Cell().ValueCell($"{Model.BasicInformation.VisitDate.ToString("dd/MM/yyyy")} {Model.BasicInformation.VisitTime.ToString("HH:mm:ss")}");
                
                table.Cell().LabelCell("Unidade Industrial");
                table.Cell().ValueCell(Model.BasicInformation.Plant.Name);
                
                table.Cell().LabelCell("Associação/Fornecedor");
                table.Cell().ValueCell(Model.BasicInformation.Association.Name);
                
                table.Cell().LabelCell("Líder do Turno");
                table.Cell().ValueCell(Model.BasicInformation.Leader);

                table.Cell().LabelCell("Fiscal do Turno");
                table.Cell().ValueCell(Model.BasicInformation.Inspector);
                
                table.Cell().LabelCell("Encarregado(a) Lab. Sacarose");
                table.Cell().ColumnSpan(3).ValueCell(Model.BasicInformation.LaboratoryLeader);
            });
    }
    
    private void ComposeCaneBalance(IContainer container)
    {
        container
            .Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.ConstantColumn(100);
                    columns.RelativeColumn();
                    columns.ConstantColumn(100);
                    columns.RelativeColumn();
                    columns.ConstantColumn(100);
                    columns.RelativeColumn();
                });

                table.ExtendLastCellsToTableBottom();
                table.Cell().ColumnSpan(6).LabelTitleCell("Balança de Cana");

                table.Cell().LabelCell("Balança de Entrada");
                table.Cell().ValueCell(Model.SugarcaneBalance.InScale);

                table.Cell().LabelCell("Balança de Saída");
                table.Cell().ColumnSpan(3).ValueCell(Model.SugarcaneBalance.OutScale);

                table.Cell().LabelCell("Sorteio de Cargas");
                table.Cell().ValueCell(Model.SugarcaneBalance.CargoDraw);

                table.Cell().LabelCell("Observações");
                table.Cell().ColumnSpan(3).ValueCell(Model.SugarcaneBalance.ScaleObservations);
            });
    }

    private void ComposeCaneBalanceCalibrations(IContainer container)
    {
        container
            .Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.ConstantColumn(100);
                    columns.ConstantColumn(100);
                    columns.ConstantColumn(100);
                    columns.ConstantColumn(100);
                    columns.RelativeColumn();
                });

                table.ExtendLastCellsToTableBottom();
                table.Cell().ColumnSpan(5).LabelTitleCell("Balança de Cana (Calibragens)");

                table.Cell().LabelCell("1º Calibração");
                table.Cell().LabelCell("2º Calibração");
                table.Cell().LabelCell("Orgão Responsavel");
                table.Cell().LabelCell("Certificado de Calibração");
                table.Cell().LabelCell("Observações");

                table.Cell().ValueCell(Model.SugarcaneBalance.Calibration1);
                table.Cell().ValueCell(Model.SugarcaneBalance.Calibration2);
                table.Cell().ValueCell(Model.SugarcaneBalance.ResponsibleBody);
                table.Cell().ValueCell(Model.SugarcaneBalance.CalibrationCertificate);
                table.Cell().RowSpan(2).ValueCell(Model.SugarcaneBalance.Observations1);
            });
    }

    private void ComposeCaneBalanceTests(IContainer container)
    {
        container
            .Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.RelativeColumn(100);
                    columns.RelativeColumn(100);
                    columns.RelativeColumn(100);
                    columns.RelativeColumn(100);
                });

                table.ExtendLastCellsToTableBottom();
                // table.Cell().ColumnSpan(4).LabelTitleCell("Teste de Balança (Mesmo caminhão nas duas balanças)");
                //
                // table.Cell().LabelCell("Nº caminhão");
                // table.Cell().LabelCell("Peso balança de entrada");
                // table.Cell().LabelCell("Peso balança de saída");
                // table.Cell().LabelCell("Variação entre balanças");
                // foreach (var balanceTest in Model.BalanceTests)
                // {
                //     table.Cell().ValueCell(balanceTest.TruckNumber);
                //     table.Cell().FloatValueCell(balanceTest.InputBalanceWeight);
                //     table.Cell().FloatValueCell(balanceTest.OutputBalanceWeight);
                //     table.Cell().FloatValueCell(balanceTest.VariationBetweenBalances);
                // }
            });
    }

    private void ComposeAnalyzedPercentage(IContainer container)
    {
        container
            .Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.ConstantColumn(100);
                    columns.ConstantColumn(100);
                    columns.ConstantColumn(100);
                    columns.ConstantColumn(100);
                    columns.RelativeColumn();
                });

                table.ExtendLastCellsToTableBottom();
                table.Cell().ColumnSpan(5).LabelTitleCell("Percentual Analisado");

                table.Cell().LabelCell("Usina");
                table.Cell().LabelCell("Fornecedor");
                table.Cell().LabelCell("Usina/Fazenda");
                table.Cell().LabelCell("Fornecedor/Fazenda");
                table.Cell().LabelCell("Observações");

                table.Cell().ValueCell(Model.SugarcaneBalance.PlantPercentage);
                table.Cell().ValueCell(Model.SugarcaneBalance.ProviderPercentage);
                table.Cell().ValueCell(Model.SugarcaneBalance.PlantFarmPercentage);
                table.Cell().ValueCell(Model.SugarcaneBalance.FarmProviderPercentage);
                table.Cell().RowSpan(3).ValueCell(Model.SugarcaneBalance.Observations2);
            });
    }

    private void ComposeSampleCollect(IContainer container)
    {
        container
            .Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.ConstantColumn(100);
                    columns.RelativeColumn();
                    columns.ConstantColumn(100);
                    columns.RelativeColumn();
                    columns.ConstantColumn(100);
                    columns.RelativeColumn();
                });

                table.ExtendLastCellsToTableBottom();
                table.Cell().ColumnSpan(6).LabelTitleCell("Coleta da Amostras (Sondas)");

                //line 1
                table.Cell().LabelCell("Tipo de sonda");
                table.Cell().ValueCell(Model.DesintegratorProbe.ProbeType);

                table.Cell().LabelCell("Quantidade de amostra suficiente");
                table.Cell().ValueCell(Model.DesintegratorProbe.SampleAmount);

                table.Cell().LabelCell("Tubo introduzido total");
                table.Cell().ValueCell(Model.DesintegratorProbe.TubeInserted);

                //line 2
                table.Cell().LabelCell("Extração do caldo");
                table.Cell().ValueCell(Model.DesintegratorProbe.BrothExtraction);

                table.Cell().LabelCell("Ultima troca/fiação da coroa");
                table.Cell().ValueCell(Model.DesintegratorProbe.LastCrownChange);

                table.Cell().LabelCell("Descarrega tubo após furo");
                table.Cell().ValueCell(Model.DesintegratorProbe.TubeDischarged);

                //line 3
                table.Cell().LabelCell("Posição da carga");
                table.Cell().ValueCell(Model.DesintegratorProbe.LoadPosition);

                table.Cell().LabelCell("Coleta");
                table.Cell().ValueCell(Model.DesintegratorProbe.Collect);

                table.Cell().LabelCell("Coroa dentada");
                table.Cell().ValueCell(Model.DesintegratorProbe.ToothedCrown);

                //line 4
                table.Cell().LabelCell("Tipo coroa");
                table.Cell().ValueCell(Model.DesintegratorProbe.ToothedCrownType);

                table.Cell().LabelCell("Observações");
                table.Cell().ColumnSpan(3).RowSpan(2).ValueCell(Model.DesintegratorProbe.Observations3);
            });
    }

    private void ComposeSampleDisintegration(IContainer container)
    {
        container
            .Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.ConstantColumn(100);
                    columns.RelativeColumn();
                    columns.ConstantColumn(100);
                    columns.RelativeColumn();
                    columns.ConstantColumn(100);
                    columns.RelativeColumn();
                });

                table.ExtendLastCellsToTableBottom();
                table.Cell().ColumnSpan(6).LabelTitleCell("Desintegração da Amostra (Forrageira)");

                //line 1
                table.Cell().LabelCell("Amostras homogênias");
                table.Cell().LabelCell("Conservação facas");
                table.Cell().LabelCell("Conservaçao contra-faca");
                table.Cell().LabelCell("Distância faca/contra-faca");
                table.Cell().LabelCell("Conservação martelo");
                table.Cell().LabelCell("Betoneira limpa a cada amostra");


                table.Cell().ValueCell(Model.DesintegratorProbe.HomogeneousSamples);
                table.Cell().ValueCell(Model.DesintegratorProbe.KnifeConservation);
                table.Cell().ValueCell(Model.DesintegratorProbe.AgainstKnifeConservation);
                table.Cell().ValueCell(Model.DesintegratorProbe.KnifeAgainstKnifeDistance);
                table.Cell().ValueCell(Model.DesintegratorProbe.HammerConservation);
                table.Cell().ValueCell(Model.DesintegratorProbe.CleanMixer);

                //line 2
                table.Cell().LabelCell("RPM do Desintegrador");
                table.Cell().LabelCell("Índice de preparo");
                table.Cell().LabelCell("Ultima troca navalhas");
                table.Cell().ColumnSpan(3).LabelCell("Observações");


                table.Cell().ValueCell(Model.DesintegratorProbe.DesintegratorRpm);
                table.Cell().ValueCell(Model.DesintegratorProbe.PreparationIndex);
                var sharpenedOrReplacedKnifeAt = Model.DesintegratorProbe.SharpenedOrReplacedKnifeAt == null
                    ? "-"
                    : Model.DesintegratorProbe.SharpenedOrReplacedKnifeAt.Value.ToString("dd/MM/yyyy");
                table.Cell().ValueCell(sharpenedOrReplacedKnifeAt);

                table.Cell().ColumnSpan(3).RowSpan(2).ValueCell(Model.DesintegratorProbe.Observations4);
            });
    }

    private void ComposeAnalyticalBalance(IContainer container)
    {
        container
            .Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.ConstantColumn(100);
                    columns.RelativeColumn();
                    columns.ConstantColumn(100);
                    columns.RelativeColumn();
                });

                table.ExtendLastCellsToTableBottom();
                table.Cell().ColumnSpan(4).LabelTitleCell("Balança analítica");

                table.Cell().LabelCell("Peso Homogênio após desintegração");
                table.Cell().ValueCell(Model.AnalyticalBalance.HomogeneousWeight);

                table.Cell().LabelCell("Peso amostra final");
                table.Cell().ValueCell(Model.AnalyticalBalance.FinalWeight);

                table.Cell().LabelCell("Balança aferida");
                table.Cell().ValueCell(Model.AnalyticalBalance.CalibratedBalance);

                table.Cell().LabelCell("Balança nivelada");
                table.Cell().ValueCell(Model.AnalyticalBalance.LeveledBalance);

                table.Cell().RowSpan(2).LabelCell("Balança com certificado de calibração");
                table.Cell().RowSpan(2).ValueCell(Model.AnalyticalBalance.CalibrationCertificateBalance);

                table.Cell().RowSpan(2).LabelCell("Observações");
                table.Cell().RowSpan(2).ValueCell(Model.AnalyticalBalance.Observations5);

                table.Cell().LabelCell("Média temp. amb. (20ºC ± 5)");
                table.Cell().ValueCell(Model.AnalyticalBalance.AverageAmbientTemperature);

                table.Cell().RowSpan(2).LabelCell("Observações(Temperatura)");
                table.Cell().RowSpan(2).ValueCell(Model.AnalyticalBalance.Observations6);
            });
    }

    private void ComposePress(IContainer container)
    {
        container
            .Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.ConstantColumn(100);
                    columns.RelativeColumn();
                    columns.ConstantColumn(100);
                    columns.RelativeColumn();
                });

                table.ExtendLastCellsToTableBottom();
                table.Cell().ColumnSpan(4).LabelTitleCell("Prensa");

                table.Cell().LabelCell("Manômetro com cert. de calibralçao");
                table.Cell().ValueCell(Model.AnalyticalBalance.HomogeneousWeight);

                table.Cell().LabelCell("Pressão");
                table.Cell().ValueCell(Model.AnalyticalBalance.FinalWeight);

                table.Cell().LabelCell("Uso do copo descarte");
                table.Cell().ValueCell(Model.AnalyticalBalance.CalibratedBalance);

                table.Cell().LabelCell("Temporizador");
                table.Cell().ValueCell(Model.AnalyticalBalance.LeveledBalance);

                table.Cell().LabelCell("Frasco coletor");
                table.Cell().ValueCell(Model.AnalyticalBalance.CalibrationCertificateBalance);

                table.Cell().LabelCell("Limpeza da prensa");
                table.Cell().ValueCell(Model.AnalyticalBalance.CalibrationCertificateBalance);

                table.Cell().LabelCell("Observações");
                table.Cell().ColumnSpan(3).ValueCell(Model.AnalyticalBalance.Observations5);
            });
    }

    private void ComposeRefractometer(IContainer container)
    {
        container
            .Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.ConstantColumn(100);
                    columns.RelativeColumn();
                    columns.ConstantColumn(100);
                    columns.RelativeColumn();
                });

                table.ExtendLastCellsToTableBottom();
                table.Cell().ColumnSpan(4).LabelTitleCell("Refratômetro");

                table.Cell().LabelCell("Hômogenização do caldo");
                table.Cell().ValueCell(Model.PressRefractometer.BrothHomogenization);

                table.Cell().LabelCell("Aferição");
                table.Cell().ValueCell(Model.PressRefractometer.BrothHomogenization);

                table.Cell().LabelCell("Certificado de calibração");
                table.Cell().ValueCell(Model.PressRefractometer.RefractometerCalibrationCertificate);

                table.Cell().LabelCell("Limpeza");
                table.Cell().ValueCell(Model.PressRefractometer.PressCleaning);

                table.Cell().LabelCell("Precisão da leitura");
                table.Cell().ValueCell(Model.PressRefractometer.PrecisionReading);

                table.Cell().LabelCell("Temperatura interna");
                table.Cell().ValueCell(Model.PressRefractometer.InternalTemperature);

                table.Cell().LabelCell("Observações");
                table.Cell().ColumnSpan(3).ValueCell(Model.PressRefractometer.Observations8);
            });
    }

    private void ComposeClassification(IContainer container)
    {
        container
            .Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.ConstantColumn(100);
                    columns.RelativeColumn();
                    columns.ConstantColumn(100);
                    columns.RelativeColumn();
                });

                table.ExtendLastCellsToTableBottom();
                table.Cell().ColumnSpan(4).LabelTitleCell("Clarificação");

                table.Cell().LabelCell("Frasco");
                table.Cell().ValueCell(Model.ClarificationSaccharimeter.Bottle);

                table.Cell().LabelCell("Clarificante");
                table.Cell().ValueCell(Model.ClarificationSaccharimeter.Clarifier);

                table.Cell().LabelCell("Agitação");
                table.Cell().ValueCell(Model.ClarificationSaccharimeter.Agitation);

                table.Cell().LabelCell("Qtd. de clarificante (200ml)");
                table.Cell().ValueCell(Model.ClarificationSaccharimeter.ClarifierAmount);

                table.Cell().LabelCell("Houve diluição");
                table.Cell().ValueCell(Model.ClarificationSaccharimeter.HasDilution);

                table.Cell().LabelCell("Volume clarificado");
                table.Cell().ValueCell(Model.ClarificationSaccharimeter.BottleClarifiedVolume);

                table.Cell().LabelCell("100ml após limpeza do sacarimetro");
                table.Cell().ValueCell(Model.ClarificationSaccharimeter.BottleAfterClarifiedVolume);

                table.Cell().LabelCell("Observações");
                table.Cell().RowSpan(2).ValueCell(Model.ClarificationSaccharimeter.BottleAfterClarifiedVolume);
            });
    }

    private void ComposeSaccharometer(IContainer container)
    {
        container
            .Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.ConstantColumn(100);
                    columns.RelativeColumn();
                    columns.ConstantColumn(100);
                    columns.RelativeColumn();
                });

                table.ExtendLastCellsToTableBottom();
                table.Cell().ColumnSpan(4).LabelTitleCell("Sacarímetro");

                table.Cell().LabelCell("Certificado de calibração");
                table.Cell().ValueCell(Model.ClarificationSaccharimeter.CalibrationCertificate);

                table.Cell().LabelCell("Padrão quartzo");
                table.Cell().ValueCell(Model.ClarificationSaccharimeter.QuartzPattern);

                table.Cell().LabelCell("Estabilização");
                table.Cell().ValueCell(Model.ClarificationSaccharimeter.Stabilization);

                table.Cell().LabelCell("Resultado quartzo");
                table.Cell().ValueCell(Model.ClarificationSaccharimeter.QuartzResult);

                table.Cell().LabelCell("Aferição");
                table.Cell().ValueCell(Model.ClarificationSaccharimeter.Benchmarking);

                table.Cell().LabelCell("Leitura quartzo");
                table.Cell().ValueCell(Model.ClarificationSaccharimeter.QuartzReading);

                table.Cell().LabelCell("Limpeza tubo");
                table.Cell().ValueCell(Model.ClarificationSaccharimeter.TubeCleaning);

                table.Cell().LabelCell("Cooler de resfriamento limpo");
                table.Cell().ValueCell(Model.ClarificationSaccharimeter.ClearCollingCooler);

                table.Cell().LabelCell("Observações");
                table.Cell().ColumnSpan(3).ValueCell(Model.ClarificationSaccharimeter.Observations10);
            });
    }

    private void ComposeMeasurementEquipment(IContainer container)
    {
        container
            .Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.ConstantColumn(100);
                    columns.RelativeColumn();
                    columns.ConstantColumn(100);
                    columns.RelativeColumn();
                    columns.ConstantColumn(100);
                    columns.RelativeColumn();
                });

                table.ExtendLastCellsToTableBottom();
                table.Cell().ColumnSpan(6).LabelTitleCell("Equipamentos de aferições");

                table.Cell().LabelCell("Célula carga");
                table.Cell().ValueCell(Model.BenchmarkingEquipment.LoadCell);

                table.Cell().LabelCell("Peso padrão (500gm)");
                table.Cell().ValueCell(Model.BenchmarkingEquipment.Gm500);

                table.Cell().LabelCell("Termômetro");
                table.Cell().ValueCell(Model.BenchmarkingEquipment.Thermometer);

                table.Cell().LabelCell("Peso padrão (100gm)");
                table.Cell().ValueCell(Model.BenchmarkingEquipment.Gm100);

                table.Cell().LabelCell("Tacômetro");
                table.Cell().ValueCell(Model.BenchmarkingEquipment.Tachometer);

                table.Cell().LabelCell("Peso padrão (1gm)");
                table.Cell().ValueCell(Model.BenchmarkingEquipment.Gm1);

                table.Cell().LabelCell("Taquímetro");
                table.Cell().ValueCell(Model.BenchmarkingEquipment.Pachymeter);

                table.Cell().LabelCell("Linearidade/Repetividade-Sacarose(PA) ");
                table.Cell().ValueCell(Model.BenchmarkingEquipment.SucroseTest);

                table.Cell().LabelCell("Refratômetro - Faixa 10º");
                table.Cell().ValueCell(Model.BenchmarkingEquipment.Range10);

                table.Cell().LabelCell("Sacarímetro - Solução 25ºZ");
                table.Cell().ValueCell(Model.BenchmarkingEquipment.Z25);

                table.Cell().LabelCell("Refratômetro - Faixa 20º");
                table.Cell().ValueCell(Model.BenchmarkingEquipment.Range20);

                table.Cell().LabelCell("Sacarímetro - Solução 50ºZ");
                table.Cell().ValueCell(Model.BenchmarkingEquipment.Z50);

                table.Cell().LabelCell("Refratômetro - Faixa 30º");
                table.Cell().ValueCell(Model.BenchmarkingEquipment.Range30);

                table.Cell().LabelCell("Sacarímetro - Solução 75ºZ");
                table.Cell().ValueCell(Model.BenchmarkingEquipment.Z75);

                table.Cell().LabelCell("Observações");
                table.Cell().RowSpan(2).ValueCell(Model.BenchmarkingEquipment.Observations11);

                table.Cell().LabelCell("Sacarímetro - Solução 100ºZ");
                table.Cell().ValueCell(Model.BenchmarkingEquipment.Z100);
            });
    }

    private void ComposeWeightedAverages(IContainer container)
    {
        container
            .Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.ConstantColumn(100);
                    columns.RelativeColumn();
                    columns.ConstantColumn(100);
                    columns.RelativeColumn();
                });

                table.ExtendLastCellsToTableBottom();
                table.Cell().ColumnSpan(4).LabelTitleCell("Médias Ponderadas (Acumulado)");

                table.Cell().LabelCell("Fibra(Safra Atual)");
                table.Cell().DecimalValueCell(Model.BenchmarkingEquipment.CurrentFiber);

                table.Cell().LabelCell("ATR(Safra Atual)");
                table.Cell().DecimalValueCell(Model.BenchmarkingEquipment.CurrentAtr);

                table.Cell().LabelCell("Fibra(Safra Anterior)");
                table.Cell().DecimalValueCell(Model.BenchmarkingEquipment.PreviousFiber);

                table.Cell().LabelCell("ATR(Safra Anterior)");
                table.Cell().DecimalValueCell(Model.BenchmarkingEquipment.PreviousAtr);

                table.Cell().LabelCell("Fibra(Variação Entre Safras)");
                table.Cell().DecimalValueCell(Model.BenchmarkingEquipment.FiberVariation);

                table.Cell().LabelCell("ATR(Variação Entre Safras)");
                table.Cell().DecimalValueCell(Model.BenchmarkingEquipment.AtrVariation);
            });
    }

    private void ComposeCrop(IContainer container)
    {
        container
            .Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.ConstantColumn(100);
                    columns.RelativeColumn();
                    columns.ConstantColumn(100);
                    columns.RelativeColumn();
                });

                table.ExtendLastCellsToTableBottom();
                table.Cell().ColumnSpan(4).LabelTitleCell("Moagem");

                table.Cell().LabelCell("Previsto safra");
                table.Cell().DecimalValueCell(Model.BenchmarkingEquipment.ExpectedCrop);

                table.Cell().LabelCell("Safra Anterior");
                table.Cell().DecimalValueCell(Model.BenchmarkingEquipment.PreviousCrop);

                table.Cell().LabelCell("Realizado");
                table.Cell().DecimalValueCell(Model.BenchmarkingEquipment.AccomplishedCrop);

                table.Cell().LabelCell("Variação Entre Safras");
                table.Cell().DecimalValueCell(Model.BenchmarkingEquipment.VariationBetweenCrops);

                table.Cell().LabelCell("Percentual realizado");
                table.Cell().DecimalValueCell(Model.BenchmarkingEquipment.PercentageRealized);

                table.Cell().LabelCell("Observações");
                table.Cell().RowSpan(2).ValueCell(Model.BenchmarkingEquipment.Observations12);
            });
    }

    private void ComposeResultComparison(IContainer container)
    {
        container
            .Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.ConstantColumn(100);
                    columns.RelativeColumn();
                    columns.ConstantColumn(100);
                    columns.RelativeColumn();
                    columns.ConstantColumn(100);
                    columns.RelativeColumn();
                    columns.RelativeColumn();
                });

                table.ExtendLastCellsToTableBottom();
                table.Cell().ColumnSpan(7).LabelTitleCell("Comparação de Resultados Unid.Industrial x Consecana");

                table.Cell().ColumnSpan(2).LabelCell("O.C");
                table.Cell().ColumnSpan(3).ValueCell(Model.SystemConsistency.Oc);

                table.Cell().LabelCell("Clarificante");
                table.Cell().ValueCell(Model.SystemConsistency.Clarifier.ToString());

                table.Cell().ColumnSpan(2).LabelCell("Fazenda");
                table.Cell().ColumnSpan(3).ValueCell(Model.SystemConsistency.Farm);

                table.Cell().LabelCell("PBU");
                table.Cell().DecimalValueCell(Model.SystemConsistency.PlantSugarcaneAnalysis.Pbu);

                table.Cell().ColumnSpan(2).RowSpan(2).LabelCell("Propietário");
                table.Cell().ColumnSpan(3).RowSpan(2).ValueCell(Model.SystemConsistency.Farm);

                table.Cell().LabelCell("BRIX");
                table.Cell().DecimalValueCell(Model.SystemConsistency.PlantSugarcaneAnalysis.Brix);

                table.Cell().LabelCell("Leitura Sacarimétrica");
                table.Cell().DecimalValueCell(Model.SystemConsistency.PlantSugarcaneAnalysis.Ls);

                table.Cell().LabelCell(string.Empty);
                table.Cell().LabelCell("Pureza");
                table.Cell().LabelCell("POL");
                table.Cell().LabelCell("Fibra");
                table.Cell().LabelCell("PCC");
                table.Cell().LabelCell("AR");
                table.Cell().LabelCell("ATR");

                table.Cell().LabelCell("Usina");
                table.Cell().DecimalValueCell(Model.SystemConsistency.PlantSugarcaneAnalysis.Purity);
                table.Cell().DecimalValueCell(Model.SystemConsistency.PlantSugarcaneAnalysis.Pol);
                table.Cell().DecimalValueCell(Model.SystemConsistency.PlantSugarcaneAnalysis.Fiber);
                table.Cell().DecimalValueCell(Model.SystemConsistency.PlantSugarcaneAnalysis.Pcc);
                table.Cell().DecimalValueCell(Model.SystemConsistency.PlantSugarcaneAnalysis.Ar);
                table.Cell().DecimalValueCell(Model.SystemConsistency.PlantSugarcaneAnalysis.Atr);

                table.Cell().LabelCell("Consecana");
                table.Cell().DecimalValueCell(Model.SystemConsistency.ConsecanaSugarcaneAnalysis.Purity);
                table.Cell().DecimalValueCell(Model.SystemConsistency.ConsecanaSugarcaneAnalysis.Pol);
                table.Cell().DecimalValueCell(Model.SystemConsistency.ConsecanaSugarcaneAnalysis.Fiber);
                table.Cell().DecimalValueCell(Model.SystemConsistency.ConsecanaSugarcaneAnalysis.Pcc);
                table.Cell().DecimalValueCell(Model.SystemConsistency.ConsecanaSugarcaneAnalysis.Ar);
                table.Cell().DecimalValueCell(Model.SystemConsistency.ConsecanaSugarcaneAnalysis.Atr);

                table.Cell().LabelCell("Variação");
                table.Cell().DecimalValueCell(Model.SystemConsistency.DifferencePurity);
                table.Cell().DecimalValueCell(Model.SystemConsistency.DifferencePol);
                table.Cell().DecimalValueCell(Model.SystemConsistency.DifferenceFiber);
                table.Cell().DecimalValueCell(Model.SystemConsistency.DifferencePcc);
                table.Cell().DecimalValueCell(Model.SystemConsistency.DifferenceAr);
                table.Cell().DecimalValueCell(Model.SystemConsistency.DifferenceAtr);

                table.Cell().ColumnSpan(1).LabelCell("Observações");
                table.Cell().ColumnSpan(6).ValueCell(Model.SystemConsistency.Observations);
            });
    }

    private void ComposeImages(IContainer container)
    {
        foreach (var imageBytes in Model.Images.Select(modelImage =>
                     Convert.FromBase64String(ExtractBase64Content(modelImage.Url))))
        {
            container.Image(imageBytes);
        }
    }

    private static string ExtractBase64Content(string imageBase64)
    {
        const string prefix = "data:image/jpeg;base64,";
        if (imageBase64.StartsWith(prefix))
        {
            return imageBase64[prefix.Length..];
        }

        throw new ArgumentException("A string não possui o prefixo esperado.");
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