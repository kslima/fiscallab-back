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
            column.Item().Element(ComposeDesintegratorProbe);
            column.Item().Element(ComposeAnalyticalBalanceAndTemp);
            column.Item().Element(ComposePressRefractometer);
            column.Item().Element(ComposeClarificationSaccharimeter);
            column.Item().Element(ComposeBenchmarkingEquipment);
            column.Item().Element(ComposeResultComparison);

            foreach (var modelImage in Model.Images)
            {
                column.Item().Element(c => ComposeImages(c, modelImage));
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
                    columns.RelativeColumn();
                    columns.RelativeColumn();
                });

                table.ExtendLastCellsToTableBottom();
                table.Cell().ColumnSpan(6).LabelTitleCell("Dados Básicos");

                table.Cell().SubLabelCell("Data");
                table.Cell()
                    .ValueCell(
                        $"{Model.BasicInformation.VisitDate.ToString("dd/MM/yyyy")} {Model.BasicInformation.VisitTime.ToString("HH:mm:ss")}");

                table.Cell().SubLabelCell("Unidade Industrial");
                table.Cell().ValueCell(Model.BasicInformation.Plant.Name);

                table.Cell().SubLabelCell("Associação/Fornecedor");
                table.Cell().ValueCell(Model.BasicInformation.Association.Name);

                table.Cell().SubLabelCell("Líder do Turno");
                table.Cell().ValueCell(Model.BasicInformation.Leader);

                table.Cell().SubLabelCell("Fiscal do Turno");
                table.Cell().ValueCell(Model.BasicInformation.Inspector);

                table.Cell().SubLabelCell("Encarregado(a) Lab. Sacarose");
                table.Cell().ValueCell(Model.BasicInformation.LaboratoryLeader);

                table.Cell().SubLabelCell("Consultor");
                table.Cell().ColumnSpan(5).ValueCell(Model.BasicInformation.Consultant);
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

                table.Cell().ColumnSpan(2).LabelCell("Balanças");
                table.Cell().ColumnSpan(2).LabelCell("Calibragens");
                table.Cell().ColumnSpan(2).LabelCell("Porcentagens Analisadas");

                //line 1
                table.Cell().SubLabelCell("Balança de Entrada");
                table.Cell().ValueCell(Model.SugarcaneBalance.InScale);

                table.Cell().SubLabelCell("1º Calibração");
                table.Cell().ValueCell(Model.SugarcaneBalance.Calibration1);

                table.Cell().SubLabelCell("Usina");
                table.Cell().ValueCell(Model.SugarcaneBalance.PlantPercentage);

                //line 2
                table.Cell().SubLabelCell("Balança de Saída");
                table.Cell().ValueCell(Model.SugarcaneBalance.OutScale);

                table.Cell().SubLabelCell("2º Calibração");
                table.Cell().ValueCell(Model.SugarcaneBalance.Calibration2);

                table.Cell().SubLabelCell("Fornecedor");
                table.Cell().ValueCell(Model.SugarcaneBalance.ProviderPercentage);

                //line 3
                table.Cell().SubLabelCell("Sorteio de Cargas");
                table.Cell().ValueCell(Model.SugarcaneBalance.CargoDraw);

                table.Cell().SubLabelCell("Orgão Responsavel");
                table.Cell().ValueCell(Model.SugarcaneBalance.ResponsibleBody);

                table.Cell().SubLabelCell("Usina/Fazenda");
                table.Cell().ValueCell(Model.SugarcaneBalance.PlantFarmPercentage);

                //line 4
                table.Cell().RowSpan(2).SubLabelCell("Observações");
                table.Cell().RowSpan(2).ValueCell(Model.SugarcaneBalance.ScaleObservations);

                table.Cell().SubLabelCell("Certificado de Calibração");
                table.Cell().ValueCell(Model.SugarcaneBalance.CalibrationCertificate);

                table.Cell().SubLabelCell("Fornecedor/Fazenda");
                table.Cell().ValueCell(Model.SugarcaneBalance.FarmProviderPercentage);

                //line 5
                table.Cell().SubLabelCell("Observações");
                table.Cell().ValueCell(Model.SugarcaneBalance.Observations1);

                table.Cell().SubLabelCell("Observações");
                table.Cell().ValueCell(Model.SugarcaneBalance.Observations2);

                if (Model.BalanceTests.Count == 0) return;

                table.Cell().ColumnSpan(6).LabelCell("Testes");
                table.Cell().SubLabelCell("Placa");
                table.Cell().ColumnSpan(2).SubLabelCell("Entrada");
                table.Cell().ColumnSpan(2).SubLabelCell("Saída");
                table.Cell().SubLabelCell("Variação");

                foreach (var modelBalanceTest in Model.BalanceTests)
                {
                    table.Cell().ValueCell(modelBalanceTest.TruckNumber);
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
                });

                table.ExtendLastCellsToTableBottom();
                table.Header(h => h.Cell().ColumnSpan(4).LabelTitleCell("Sonda/Desintegrador"));

                table.Cell().ColumnSpan(2).LabelCell("Sonda");
                table.Cell().ColumnSpan(2).LabelCell("Desintegrador");

                //line 1
                table.Cell().SubLabelCell("Tipo de sonda");
                table.Cell().ValueCell(Model.DesintegratorProbe.ProbeType);

                table.Cell().SubLabelCell("Amostras homogênias");
                table.Cell().ValueCell(Model.DesintegratorProbe.HomogeneousSamples);

                //line 2
                table.Cell().SubLabelCell("Tubo introduzido total");
                table.Cell().ValueCell(Model.DesintegratorProbe.TubeInserted);

                table.Cell().SubLabelCell("Betoneira limpa a cada amostra");
                table.Cell().ValueCell(Model.DesintegratorProbe.CleanMixer);

                //line 3
                table.Cell().SubLabelCell("Descarrega tubo após furo");
                table.Cell().ValueCell(Model.DesintegratorProbe.TubeDischarged);

                table.Cell().SubLabelCell("Conservação facas");
                table.Cell().ValueCell(Model.DesintegratorProbe.KnifeConservation);

                //line 4
                table.Cell().SubLabelCell("Coleta");
                table.Cell().ValueCell(Model.DesintegratorProbe.Collect);

                table.Cell().SubLabelCell("RPM do Desintegrador");
                table.Cell().ValueCell(Model.DesintegratorProbe.DesintegratorRpm);

                //line 5
                table.Cell().SubLabelCell("Quantidade de amostra suficiente");
                table.Cell().ValueCell(Model.DesintegratorProbe.SampleAmount);

                table.Cell().SubLabelCell("Conservaçao contra-faca");
                table.Cell().ValueCell(Model.DesintegratorProbe.AgainstKnifeConservation);

                //line 6
                table.Cell().SubLabelCell("Extração do caldo");
                table.Cell().ValueCell(Model.DesintegratorProbe.BrothExtraction);

                table.Cell().SubLabelCell("Índice de preparo");
                table.Cell().ValueCell(Model.DesintegratorProbe.PreparationIndex);

                //line 7
                table.Cell().SubLabelCell("Posição da carga");
                table.Cell().ValueCell(Model.DesintegratorProbe.LoadPosition);

                table.Cell().SubLabelCell("Distância faca/contra-faca");
                table.Cell().ValueCell(Model.DesintegratorProbe.KnifeAgainstKnifeDistance);

                //line 8
                table.Cell().SubLabelCell("Coroa dentada");
                table.Cell().ValueCell(Model.DesintegratorProbe.ToothedCrown);

                table.Cell().SubLabelCell("Ultima troca navalhas");
                var sharpenedOrReplacedKnifeAt = Model.DesintegratorProbe.SharpenedOrReplacedKnifeAt == null
                    ? "-"
                    : Model.DesintegratorProbe.SharpenedOrReplacedKnifeAt.Value.ToString("dd/MM/yyyy");
                table.Cell().ValueCell(sharpenedOrReplacedKnifeAt);

                //line 9
                table.Cell().SubLabelCell("Tipo coroa");
                table.Cell().ValueCell(Model.DesintegratorProbe.ToothedCrownType);

                table.Cell().SubLabelCell("Conservação martelo");
                table.Cell().ValueCell(Model.DesintegratorProbe.HammerConservation);

                //line 10
                table.Cell().SubLabelCell("Observações");
                table.Cell().ValueCell(Model.DesintegratorProbe.Observations3);

                table.Cell().SubLabelCell("Observações");
                table.Cell().ValueCell(Model.DesintegratorProbe.Observations4);
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
                });

                table.ExtendLastCellsToTableBottom();
                table.Header(h => h.Cell().ColumnSpan(4).LabelTitleCell("Balança Analítica/Temperatura"));

                table.Cell().ColumnSpan(2).LabelCell("Balança Analítica");
                table.Cell().ColumnSpan(2).LabelCell("Temperatura");


                //line 1
                table.Cell().SubLabelCell("Peso Homogênio após desintegração");
                table.Cell().ValueCell(Model.AnalyticalBalance.HomogeneousWeight);

                table.Cell().SubLabelCell("Média (20ºC ± 5)");
                table.Cell().ValueCell($"{Model.AnalyticalBalance.AverageAmbientTemperature} ºC");

                //line 2
                table.Cell().SubLabelCell("Peso amostra final");
                table.Cell().ValueCell(Model.AnalyticalBalance.FinalWeight);

                table.Cell().RowSpan(5).SubLabelCell("Observações");
                table.Cell().RowSpan(5).ValueCell(Model.AnalyticalBalance.Observations6);

                //line 3
                table.Cell().SubLabelCell("Balança aferida");
                table.Cell().ValueCell(Model.AnalyticalBalance.CalibratedBalance);

                //line 4
                table.Cell().SubLabelCell("Balança nivelada");
                table.Cell().ValueCell(Model.AnalyticalBalance.LeveledBalance);

                //line 5
                table.Cell().SubLabelCell("Balança com certificado de calibração");
                table.Cell().ValueCell(Model.AnalyticalBalance.CalibrationCertificateBalance);

                //line 6
                table.Cell().SubLabelCell("Observações");
                table.Cell().ValueCell(Model.AnalyticalBalance.Observations5);
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
                });

                table.ExtendLastCellsToTableBottom();
                table.Header(h => h.Cell().ColumnSpan(4).LabelTitleCell("Prensa/Refratômetro"));

                table.Cell().ColumnSpan(2).LabelCell("Prensa");
                table.Cell().ColumnSpan(2).LabelCell("Refratômetro");

                //line 1
                table.Cell().SubLabelCell("Manômetro com cert. de calibralçao");
                table.Cell().ValueCell(Model.PressRefractometer.PressureGaugeCertificated);

                table.Cell().SubLabelCell("Hômogenização do caldo");
                table.Cell().ValueCell(Model.PressRefractometer.BrothHomogenization);

                //line 2
                table.Cell().SubLabelCell("Uso do copo descarte");
                table.Cell().ValueCell(Model.PressRefractometer.DiscardCup);

                table.Cell().SubLabelCell("Certificado de calibração");
                table.Cell().ValueCell(Model.PressRefractometer.RefractometerCalibrationCertificate);

                //line 3
                table.Cell().SubLabelCell("Frasco coletor");
                table.Cell().ValueCell(Model.PressRefractometer.CollectorBottle);

                table.Cell().SubLabelCell("Precisão da leitura");
                table.Cell().ValueCell(Model.PressRefractometer.PrecisionReading);

                //line 4
                table.Cell().SubLabelCell("Pressão");
                table.Cell().ValueCell(Model.PressRefractometer.Pressure);

                table.Cell().SubLabelCell("Aferição");
                table.Cell().ValueCell(Model.PressRefractometer.BrothHomogenization);

                //line 5
                table.Cell().SubLabelCell("Temporizador");
                table.Cell().ValueCell(Model.PressRefractometer.Timer);

                table.Cell().SubLabelCell("Limpeza");
                table.Cell().ValueCell(Model.PressRefractometer.PressCleaning);

                //line 6
                table.Cell().SubLabelCell("Limpeza da prensa");
                table.Cell().ValueCell(Model.PressRefractometer.PressCleaning);

                table.Cell().SubLabelCell("Temperatura interna");
                table.Cell().ValueCell($"{Model.PressRefractometer.InternalTemperature} ºC");

                //line 7
                table.Cell().SubLabelCell("Observações");
                table.Cell().ValueCell(Model.PressRefractometer.Observations7);

                table.Cell().SubLabelCell("Observações");
                table.Cell().ValueCell(Model.PressRefractometer.Observations8);
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

                table.Cell().ColumnSpan(2).LabelCell("Clarificação");
                table.Cell().ColumnSpan(2).LabelCell("Sacarímetro");

                //line 1
                table.Cell().SubLabelCell("Frasco");
                table.Cell().ValueCell(Model.ClarificationSaccharimeter.Bottle);

                table.Cell().SubLabelCell("Estabilização");
                table.Cell().ValueCell(Model.ClarificationSaccharimeter.Stabilization);

                //line 2
                table.Cell().SubLabelCell("Agitação");
                table.Cell().ValueCell(Model.ClarificationSaccharimeter.Agitation);

                table.Cell().SubLabelCell("Aferição");
                table.Cell().ValueCell(Model.ClarificationSaccharimeter.Benchmarking);

                //line 3
                table.Cell().SubLabelCell("Houve diluição");
                table.Cell().ValueCell(Model.ClarificationSaccharimeter.HasDilution);

                table.Cell().SubLabelCell("Padrão quartzo");
                table.Cell().ValueCell(Model.ClarificationSaccharimeter.QuartzPattern);

                //line 4
                table.Cell().SubLabelCell("Clarificante");
                table.Cell().ValueCell(Model.ClarificationSaccharimeter.Clarifier);

                table.Cell().SubLabelCell("Resultado quartzo");
                table.Cell().ValueCell(Model.ClarificationSaccharimeter.QuartzResult);

                //line 5
                table.Cell().SubLabelCell("Pressão");
                table.Cell().ValueCell(Model.ClarificationSaccharimeter.Pressure);

                table.Cell().SubLabelCell("Leitura quartzo");
                table.Cell().ValueCell(Model.ClarificationSaccharimeter.QuartzReading);

                //line 6
                table.Cell().SubLabelCell("Qtd. de clarificante (200ml)");
                table.Cell().ValueCell(Model.ClarificationSaccharimeter.ClarifierAmount);

                table.Cell().SubLabelCell("Certificado de calibração");
                table.Cell().ValueCell(Model.ClarificationSaccharimeter.CalibrationCertificate);

                //line 7
                table.Cell().SubLabelCell("Volume clarificado");
                table.Cell().ValueCell(Model.ClarificationSaccharimeter.BottleClarifiedVolume);

                table.Cell().SubLabelCell("Limpeza tubo");
                table.Cell().ValueCell(Model.ClarificationSaccharimeter.TubeCleaning);

                //line 8
                table.Cell().SubLabelCell("100ml após limpeza do sacarimetro");
                table.Cell().ValueCell(Model.ClarificationSaccharimeter.BottleAfterClarifiedVolume);

                table.Cell().SubLabelCell("Cooler de resfriamento limpo");
                table.Cell().ValueCell(Model.ClarificationSaccharimeter.ClearCollingCooler);

                //line 9
                table.Cell().SubLabelCell("Observações");
                table.Cell().ValueCell(Model.ClarificationSaccharimeter.BottleAfterClarifiedVolume);

                table.Cell().SubLabelCell("Observações");
                table.Cell().ValueCell(Model.ClarificationSaccharimeter.Observations10);
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

                table.Cell().ColumnSpan(2).SubLabelCell("Célula Carga");
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

                table.Cell().ColumnSpan(1).SubLabelCell("25z");
                table.Cell().ColumnSpan(1).SubLabelCell("50z");
                table.Cell().ColumnSpan(1).SubLabelCell("75z");
                table.Cell().ColumnSpan(1).SubLabelCell("100z");
                table.Cell().ColumnSpan(6).SubLabelCell("Observações");

                table.Cell().ColumnSpan(1).ValueCell(Model.BenchmarkingEquipment.Z25);
                table.Cell().ColumnSpan(1).ValueCell(Model.BenchmarkingEquipment.Z50);
                table.Cell().ColumnSpan(1).ValueCell(Model.BenchmarkingEquipment.Z75);
                table.Cell().ColumnSpan(1).ValueCell(Model.BenchmarkingEquipment.Z100);
                table.Cell().ColumnSpan(6).ValueCell(Model.BenchmarkingEquipment.Observations11);

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
                table.Cell().ColumnSpan(1).ValueCell(Model.SystemConsistency.Clarifier.ToString() ?? string.Empty);
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

                table.Cell().ColumnSpan(1).SubLabelCell("Observações");
                table.Cell().ColumnSpan(6).ValueCell(Model.SystemConsistency.Observations);
            });
    }

    private void ComposeImages(IContainer container, ImageDto image)
    {
        var imageBytes = Convert.FromBase64String(image.Url.Split(",")[1]);
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

                table.Cell().ColumnSpan(6).Image(imageBytes);
                table.Cell().ColumnSpan(1).SubLabelCell("Descrição");
                table.Cell().ColumnSpan(5).ValueCell(image.Description);
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