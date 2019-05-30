namespace PriceCalculator
{
  public class Tax
  {
    public decimal TaxPercentage { get; }

    public Tax(decimal taxPercentage)
    {
      TaxPercentage = taxPercentage;
    }

    public override string ToString() => $"{TaxPercentage}%";
  }
}