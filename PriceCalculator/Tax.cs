namespace PriceCalculator
{
  public class Tax
  {
    public double TaxPercentage { get; }

    public Tax(double taxPercentage)
    {
      TaxPercentage = taxPercentage;
    }

    public override string ToString() => $"{TaxPercentage}%";
  }
}