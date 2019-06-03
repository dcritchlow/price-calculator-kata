using System;
using PriceCalculator;

namespace CalculatorConsole.ConsoleReader
{
  public class ConsoleProductReader
  {
    public Product ReadProduct() =>
      new Product(DesiredProductName, DesiredProductUpc, new Money(DesiredProductPrice));
    
    private static string DesiredProductName =>
      Console.In.IncomingLines(PromptDesiredName).SingleNonEmptyString();

    private static void PromptDesiredName() =>
      Console.Write("Product name: ");

    private static int DesiredProductUpc =>
      Console.In.IncomingLines(PromptDesiredUpc).NonNegativeInteger();

    private static void PromptDesiredUpc() =>
      Console.Write("Product UPC: ");

    private static decimal DesiredProductPrice =>
      Console.In.IncomingLines(PromptDesiredPrice).NonNegativeDecimal();

    private static void PromptDesiredPrice() =>
      Console.Write("Product Price: ");
  }
}