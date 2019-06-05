using PriceCalculator.Discounts;

namespace PriceCalculator.DiscountRules
{
  public class UpcDiscountRule : IDiscountRule
  {
    private int _upc;
    public IDiscount Discount { get; }

    public UpcDiscountRule(UpcDiscount upcDiscount)
    {
      _upc = upcDiscount.Upc;
      Discount = upcDiscount;
    }

    public bool ApplyTo(Product product) => product.Upc == _upc;
  }
}