using System;
using CalculatorConsole.ConsoleReader;
using PriceCalculator;

namespace CalculatorConsole
{
  public class Program
  {
    public static void Main(string[] args)
    {
      var tax = new ConsoleTaxReader().ReadTax();
      var discount = new ConsoleUniversalDiscountReader().ReadDiscount();
      var upcDiscount = new ConsoleUpcDiscountReader().ReadDiscount();
      var calculator = new Calculator(new ConsoleProductReader().ReadProduct(), tax, discount, upcDiscount);
      Console.WriteLine(calculator.ToString());
      Console.ReadLine();
    }
  }
}
