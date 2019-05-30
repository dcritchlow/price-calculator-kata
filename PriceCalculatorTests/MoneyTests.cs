using PriceCalculator;
using Xunit;

namespace PriceCalculatorTests
{
  public class MoneyTests
  {
    [Fact]
    public void Money_Constructor_ReturnsValidObject()
    {
      var sut = new Money(1.00m);
      Assert.Matches(@"\$1.00", sut.ToString());
    }
  }
}