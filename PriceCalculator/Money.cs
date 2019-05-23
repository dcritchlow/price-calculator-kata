namespace PriceCalculator
{
  public class Money
  {
    public double Amount { get; }

    public Money(double amount)
    {
      Amount = amount;
    }

    public override string ToString() => $"{Amount:C}";
  }
}