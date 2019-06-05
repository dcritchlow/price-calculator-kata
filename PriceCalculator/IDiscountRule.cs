namespace PriceCalculator
{
  public interface IDiscountRule
  {
    IDiscount Discount { get; }
    bool ApplyTo(Product product);
  }
}