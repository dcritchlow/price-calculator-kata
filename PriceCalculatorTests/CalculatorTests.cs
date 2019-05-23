using PriceCalculator;
using Xunit;

namespace PriceCalculatorTests
{
  public class CalculatorTests
  {
    [Fact]
    public void Calculator_GivenProductAndTax20Percent_ReturnsCorrectPrice()
    {
      var product = new Product
      {
        Name = "The Little Prince",
        Upc = 12345,
        Price = new Money(20.25)
      };
      var tax = new Tax(20);
      var sut = new Calculator(product, tax);
      var result = sut.ToString();
      Assert.Matches(@"Product price reported as \$20.25 before tax and \$24.30 after 20\% tax.", sut.ToString());
    }

    [Fact]
    public void Calculator_GivenProductAndTax21Percent_ReturnsCorrectPrice()
    {
      var product = new Product
      {
        Name = "The Little Prince",
        Upc = 12345,
        Price = new Money(20.25)
      };
      var tax = new Tax(21);
      var sut = new Calculator(product, tax);
      var result = sut.ToString();
      Assert.Matches(@"Product price reported as \$20.25 before tax and \$24.50 after 21\% tax.", sut.ToString());
    }
  }
}