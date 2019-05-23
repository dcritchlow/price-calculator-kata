using PriceCalculator;
using Xunit;

namespace PriceCalculatorTests
{
  public class CalculatorTests
  {
    private Product _testProduct => new Product
    {
      Name = "The Little Prince",
      Upc = 12345,
      Price = new Money(20.25)
    };

    [Theory]
    [InlineData(20, 24.30)]
    [InlineData(21, 24.50)]
    public void Calculator_GivenProductAndTax20Percent_ReturnsCorrectPrice(int taxInput, decimal expectedAmount)
    {
      var tax = new Tax(taxInput);
      var sut = new Calculator(_testProduct, tax);
      var result = sut.ToString();
      var expected = $@"Product price reported as {_testProduct.Price} before tax and {expectedAmount:C} after {tax} tax.";
      Assert.Equal(expected, result);
    }
  }
}