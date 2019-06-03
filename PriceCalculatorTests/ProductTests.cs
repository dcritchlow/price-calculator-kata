using AutoFixture;
using PriceCalculator;
using Xunit;

namespace PriceCalculatorTests
{
  public class ProductTests
  {
    private readonly Fixture _fixture = new Fixture();

    [Fact]
    public void Product_DefaultConstructor_ReturnsValidObject()
    {
      var name = _fixture.Create<string>();
      var upc = _fixture.Create<int>();
      var price = _fixture.Create<Money>();

      var sut = new Product
      {
        Name = name,
        Upc = upc,
        Price = price
      };

      Assert.NotNull(sut);
      Assert.Equal(name, sut.Name);
      Assert.Equal(upc, sut.Upc);
      Assert.Equal(price, sut.Price);
    }

    [Fact]
    public void Product_ParameterConstructor_ReturnsValidObject()
    {
      var name = _fixture.Create<string>();
      var upc = _fixture.Create<int>();
      var price = _fixture.Create<Money>();
      var sut = new Product(name, upc, price);

      Assert.NotNull(sut);
      Assert.Equal(name, sut.Name);
      Assert.Equal(upc, sut.Upc);
      Assert.Equal(price, sut.Price);
    }
  }
}
