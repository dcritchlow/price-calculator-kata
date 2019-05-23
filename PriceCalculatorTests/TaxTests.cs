using PriceCalculator;
using Xunit;

namespace PriceCalculatorTests
{
  public class TaxTests
  {
    [Fact]
    public void Tax_GivenPercentage_ReturnsCorrectFormat()
    {
      var sut = new Tax(20);
      Assert.Matches(@"20\%", sut.ToString());
    }
  }
}