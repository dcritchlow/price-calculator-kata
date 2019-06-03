using System;
using PriceCalculator;

namespace CalculatorConsole.ConsoleReader
{
  public class ConsoleDiscountReader
  {
    public Discount ReadDiscount() => new Discount(DesiredDiscountAmount);

    private static decimal DesiredDiscountAmount =>
      Console.In.IncomingLines(PromptDesiredDiscountAmount).NonNegativeDecimal();

    private static void PromptDesiredDiscountAmount() =>
      Console.Write("Discount Percentage: ");
  }
}