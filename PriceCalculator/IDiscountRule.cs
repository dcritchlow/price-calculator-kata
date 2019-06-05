namespace PriceCalculator
{
  public interface IDiscountRule
  {
    IDiscount Discount { get; }
    bool ApplyTo(Product product);
    bool BeforeTax { get; }
    bool AfterTax { get; }
  }
}