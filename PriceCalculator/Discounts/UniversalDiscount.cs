namespace PriceCalculator.Discounts
{
  public class UniversalDiscount : IDiscount
  {
    public decimal DiscountPercentage { get; }

    public UniversalDiscount(decimal discountPercentage)
    {
      DiscountPercentage = discountPercentage;
    }

    public override string ToString() => $"{DiscountPercentage}%";
  }
}