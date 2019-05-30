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
      Price = new Money(20.25m)
    };

    [Theory]
    [InlineData(20, 21.26, 15, 4.05, 3.04)]
    [InlineData(21, 20.45, 20, 4.25, 4.05)]
    public void Calculator_GivenProductAndTax20Percent_ReturnsCorrectPrice(int taxInput, decimal expectedAmount, int discountInput, decimal expectedTaxAmount, decimal expectedDiscountAmount)
    {
      var tax = new Tax(taxInput);
      var discount = new Discount(discountInput);
      var sut = new Calculator(_testProduct, tax, discount);
      var result = sut.ToString();
      var expected = $@"Tax={taxInput}% Discount={discountInput}% Tax amount = {expectedTaxAmount:C} Discount amount = {expectedDiscountAmount:C} Price before = {_testProduct.Price:C} Price after = {expectedAmount:C}";
      Assert.Equal(expected, result);
    }
  }
}