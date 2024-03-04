using FiscalLabService.Domain.ValueObjects;

namespace FiscalLabService.App.Dtos;

public class BalanceTestDto
{
    public string TruckNumber { get; set; }
    public float InputBalanceWeight { get; set; }
    public float OutputBalanceWeight { get; set; }
    public float VariationBetweenBalances { get; set; }

    public BalanceTestDto(BalanceTest balanceTest)
    {
        TruckNumber = balanceTest.TruckNumber;
        InputBalanceWeight = balanceTest.InputBalanceWeight;
        OutputBalanceWeight = balanceTest.OutputBalanceWeight;
        VariationBetweenBalances = balanceTest.InputBalanceWeight - balanceTest.OutputBalanceWeight;
    }
}