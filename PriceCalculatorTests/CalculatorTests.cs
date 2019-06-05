using System;
using PriceCalculator;
using PriceCalculator.Discounts;
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
    [InlineData(20, 21.26, 15, 0, 123, 4.05, 3.04)]
    [InlineData(21, 20.45, 20, 0, 123, 4.25, 4.05)]
    [InlineData(21, 24.5, 0, 0, 123, 4.25, 0)]
    public void Calculator_GivenProductAndTax20Percent_ReturnsCorrectPrice(int taxInput, decimal expectedAmount, int universalDiscountInput, int upcDiscountInput, int upc, decimal expectedTaxAmount, decimal expectedDiscountAmount)
    {
      var tax = new Tax(taxInput);
      var universalDiscount = new UniversalDiscount(universalDiscountInput);
      var upcDiscount = new UpcDiscount(upcDiscountInput, upc);
      var sut = new Calculator(_testProduct, tax, universalDiscount, upcDiscount);
      var result = sut.ToString();
      var expected = $@"Tax={taxInput}%{Environment.NewLine}Tax amount = {expectedTaxAmount:C}{Environment.NewLine}Discount amount = {expectedDiscountAmount:C}{Environment.NewLine}Price before = {_testProduct.Price:C}{Environment.NewLine}Price after = {expectedAmount:C}";
      Assert.Equal(expected, result);
    }

    [Fact]
    public void Calculator_UniversalDiscount15_UpcDiscount7_upc12345_ReturnsCorrectDiscountAmount()
    {
      var tax = new Tax(20);
      var universalDiscount = new UniversalDiscount(15);
      var upcDiscount = new UpcDiscount(7, 12345);
      var sut = new Calculator(_testProduct, tax, universalDiscount, upcDiscount);
      var result = sut.ToString();
      var expected = $"Tax=20%{Environment.NewLine}Tax amount = $4.05{Environment.NewLine}Discount amount = $4.46{Environment.NewLine}Price before = $20.25{Environment.NewLine}Price after = $19.84";
      Assert.Equal(expected, result);
    }

    [Fact]
    public void Calculator_UniversalDiscount15_UpcDiscount7_Upc789_ReturnsOnlyUniversalAmount()
    {
      var tax = new Tax(21);
      var universalDiscount = new UniversalDiscount(15);
      var upcDiscount = new UpcDiscount(7, 789);
      var sut = new Calculator(_testProduct, tax, universalDiscount, upcDiscount);
      var result = sut.ToString();
      var expected = $"Tax=21%{Environment.NewLine}Tax amount = $4.25{Environment.NewLine}Discount amount = $3.04{Environment.NewLine}Price before = $20.25{Environment.NewLine}Price after = $21.46";
      Assert.Equal(expected, result);
    }
  }
}