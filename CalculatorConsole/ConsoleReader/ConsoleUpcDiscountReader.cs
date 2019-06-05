using System;
using CalculatorConsole.Infrastructure;
using PriceCalculator.Discounts;

namespace CalculatorConsole.ConsoleReader
{
  public class ConsoleUpcDiscountReader
  {
    public UpcDiscount ReadDiscount() => new UpcDiscount(DesiredDiscountAmount, DesiredUpc);

    private static decimal DesiredDiscountAmount =>
      Console.In.IncomingLines(PromptDesiredDiscountAmount).NonNegativeDecimal();

    private static void PromptDesiredDiscountAmount() =>
      Console.Write("UPC Discount Percentage: ");

    private static int DesiredUpc =>
      Console.In.IncomingLines(PromptDesiredUpcCode).NonNegativeInteger();

    private static void PromptDesiredUpcCode() =>
      Console.Write("UPC Code: ");
  }
}