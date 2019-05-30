namespace PriceCalculator
{
  public class Discount
  {
    public decimal DiscountPercentage { get; }

    public Discount(decimal discountPercentage)
    {
      DiscountPercentage = discountPercentage;
    }

    public override string ToString() => $"{DiscountPercentage}%";
  }
}