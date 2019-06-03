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
      var discount = new ConsoleDiscountReader().ReadDiscount();
      var calculator = new Calculator(new ConsoleProductReader().ReadProduct(), tax, discount);
      Console.WriteLine(calculator.ToString());
      Console.ReadLine();
    }
  }
}
