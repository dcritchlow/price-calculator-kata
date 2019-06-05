using PriceCalculator.Discounts;

namespace PriceCalculator.DiscountRules
{
  public class UniversalDiscountRule : IDiscountRule
  {
    public IDiscount Discount { get; }

    public UniversalDiscountRule(IDiscount discount)
    {
      Discount = discount;
    }

    public bool ApplyTo(Product product) => true;
  }
}