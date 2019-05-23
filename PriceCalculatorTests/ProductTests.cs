using AutoFixture;
using PriceCalculator;
using Xunit;

namespace PriceCalculatorTests
{
  public class ProductTests
  {
    private readonly Fixture _fixture = new Fixture();

    [Fact]
    public void Product_Constructor_ReturnsValidObject()
    {
      var sut = new Product
      {
        Name = _fixture.Create<string>(),
        Upc = _fixture.Create<int>(),
        Price = _fixture.Create<Money>()
      };

      Assert.NotNull(sut);
    }
  }
}
