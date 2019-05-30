namespace PriceCalculator
{
  public class Money
  {
    public decimal Amount { get; }

    public Money(decimal amount)
    {
      Amount = amount;
    }

    public override string ToString() => $"{Amount:C}";
  }
}