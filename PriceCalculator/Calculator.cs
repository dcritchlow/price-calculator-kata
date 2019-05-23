namespace PriceCalculator
{
  public class Calculator
  {
    private Product _product { get; }
    private Tax _tax { get; }
    

    public Calculator(Product product, Tax tax)
    {
      _product = product;
      _tax = tax;
    }

    private Money CalculateTotal(Money productPrice, Tax taxPercentage)
    {
      var priceWithTax = _product.Price.Amount * (1 + _tax.TaxPercentage/100);
      return new Money(priceWithTax);
    }

    private string CalculatePrice() => $"Product price reported as {_product.Price} before tax and {CalculateTotal(_product.Price, _tax)} after {_tax} tax.";

    public override string ToString() => CalculatePrice();
  }
}