namespace PriceCalculator
{
  public class Calculator
  {
    private Product _product { get; }
    private Tax _tax { get; }
    private Discount _discount { get; }

    public Calculator(Product product, Tax tax, Discount discount)
    {
      _product = product;
      _tax = tax;
      _discount = discount;
    }

    private Money CalculatedDiscount() => new Money(_product.Price.Amount * (_discount.DiscountPercentage / 100));

    private Money CalculatedTax() => new Money(_product.Price.Amount * (_tax.TaxPercentage / 100));

    //private string CalculatePrice() => $"Product price reported as {_product.Price} before tax and {CalculateTotal(_product.Price, _tax, _discount)} after {_tax} tax.";
    private Money CalculatePrice() => new Money(_product.Price.Amount - CalculatedDiscount() + CalculatedTax());
    

    public override string ToString() => $"Tax={_tax} Discount={_discount} Tax amount = {CalculatedTax()} Discount amount = {CalculatedDiscount()} Price before = {_product.Price} Price after = {CalculatePrice()}";
  }
}