using System;

namespace PriceCalculator
{
  public class Money
  {
    public decimal Amount { get; }

    public Money(decimal amount)
    {
      Amount = Math.Round(amount, 2);
    }

    public static implicit operator decimal(Money m) => m.Amount;
    public override string ToString() => $"{Amount:C}";
  }
}