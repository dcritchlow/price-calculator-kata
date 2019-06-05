namespace PriceCalculator.Discounts
{
  public class UpcDiscount : IDiscount
  {
    public decimal DiscountPercentage { get; }
    public int Upc { get; }

    public UpcDiscount(decimal discountPercentage, int upc)
    {
      DiscountPercentage = discountPercentage;
      Upc = upc;
    }

    public override string ToString() => $"{DiscountPercentage}%";
  }
}