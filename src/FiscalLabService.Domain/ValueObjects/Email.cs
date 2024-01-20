namespace FiscalLabService.Domain.ValueObjects;

public class Email(string address)
{
    public string Address { get; } = address.ToLower().Trim();
}