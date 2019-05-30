using PriceCalculator;
using Xunit;

namespace PriceCalculatorTests
{
  public class DiscountTests
  {
    [Fact]
    public void Discount_GivenPercentage_ReturnsCorrectFormat()
    {
      var sut = new Discount(20);
      Assert.Matches(@"20\%", sut.ToString());
    }
  }
}