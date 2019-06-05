using System;

namespace PriceCalculator.Reports
{
  public class StringReport
  {
    public string PrintReport(Money productPrice, Money discountTotal, Money finalPrice) =>
      $"Price before = {productPrice}{Environment.NewLine}Discount amount = {discountTotal}{Environment.NewLine}Price after = {finalPrice}";
  }
}