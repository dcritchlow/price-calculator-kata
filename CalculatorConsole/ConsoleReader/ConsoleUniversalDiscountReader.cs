using System;
using CalculatorConsole.Infrastructure;
using PriceCalculator.Discounts;

namespace CalculatorConsole.ConsoleReader
{
  public class ConsoleUniversalDiscountReader
  {
    public UniversalDiscount ReadDiscount() => new UniversalDiscount(DesiredDiscountAmount);

    private static decimal DesiredDiscountAmount =>
      Console.In.IncomingLines(PromptDesiredDiscountAmount).NonNegativeDecimal();

    private static void PromptDesiredDiscountAmount() =>
      Console.Write("UniversalDiscount Percentage: ");
  }
}