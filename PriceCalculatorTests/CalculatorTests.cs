using PriceCalculator;
using PriceCalculator.Discounts;
using PriceCalculator.Reports;
using Xunit;

namespace PriceCalculatorTests
{
  public class CalculatorTests
  {
    private Product _testProduct => new Product
    {
      Name = "The Little Prince",
      Upc = 12345,
      Price = new Money(20.25m)
    };

    [Theory]
    [InlineData(20, 21.26, 15, 0, 123, 3.04)]
    [InlineData(21, 20.45, 20, 0, 123, 4.05)]
    [InlineData(21, 24.5, 0, 0, 123, 0)]
    [InlineData(20, 19.78, 15, 7, 12345, 4.24)]
    [InlineData(21, 21.46, 15, 7, 789, 3.04)]
    public void Calculator_GivenProductAndTax20Percent_ReturnsCorrectPrice(int taxInput, decimal expectedAmount, int universalDiscountInput, int upcDiscountInput, int upc, decimal expectedDiscountAmount)
    {
      var tax = new Tax(taxInput);
      var universalDiscount = new UniversalDiscount(universalDiscountInput);
      var upcDiscount = new UpcDiscount(upcDiscountInput, upc);
      var sut = new Calculator(_testProduct, tax, universalDiscount, upcDiscount);
      var result = sut.ToString();
      var report = new StringReport().PrintReport(_testProduct.Price, new Money(expectedDiscountAmount), new Money(expectedAmount));
      Assert.Equal(report, result);
    }
  }
}