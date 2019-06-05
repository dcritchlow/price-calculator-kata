using PriceCalculator;
using PriceCalculator.Discounts;
using Xunit;

namespace PriceCalculatorTests
{
  public class DiscountTests
  {
    private Product _testProduct => new Product
    {
      Name = "The Little Prince",
      Upc = 12345,
      Price = new Money(20.25m)
    };

    [Fact]
    public void UniversalDiscount_GivenPercentage_ReturnsCorrectFormat()
    {
      var sut = new UniversalDiscount(20);
      Assert.Matches(@"20\%", sut.ToString());
    }

    [Fact]
    public void UpcDiscount_GivenProductWithDiscountedUpc_ReturnsPercentage()
    {
      var sut = new UpcDiscount(20, 12345);
      Assert.Equal("20%", sut.ToString());
      Assert.Equal(12345, sut.Upc);
    }
  }
}