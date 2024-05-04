using FiscalLabService.Domain.ValueObjects;

namespace FiscalLabService.App.Dtos;

public class BalanceTestDto
{
    public string Identification { get; set; }
    public float InputBalanceWeight { get; set; }
    public float OutputBalanceWeight { get; set; }
    public float VariationBetweenBalances { get; set; }

    public BalanceTestDto(BalanceTest balanceTest)
    {
        Identification = balanceTest.Identification;
        InputBalanceWeight = balanceTest.InputBalanceWeight;
        OutputBalanceWeight = balanceTest.OutputBalanceWeight;
        VariationBetweenBalances = balanceTest.InputBalanceWeight - balanceTest.OutputBalanceWeight;
    }
}