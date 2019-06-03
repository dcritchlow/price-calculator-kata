using System;
using PriceCalculator;

namespace CalculatorConsole.ConsoleReader
{
  public class ConsoleTaxReader
  {
    public Tax ReadTax() => new Tax(DesiredTaxAmount);

    private static decimal DesiredTaxAmount =>
      Console.In.IncomingLines(PromptDesiredTaxAmount).NonNegativeDecimal();

    private static void PromptDesiredTaxAmount() =>
      Console.Write("Tax Percentage: ");
  }
}