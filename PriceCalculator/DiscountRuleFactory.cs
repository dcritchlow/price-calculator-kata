using System.Collections.Generic;
using PriceCalculator.DiscountRules;
using PriceCalculator.Discounts;

namespace PriceCalculator
{
  public class DiscountRuleFactory
  {
    public static IEnumerable<IDiscountRule> Rules(UniversalDiscount universalDiscount, UpcDiscount upcDiscount)
    {
      yield return new UniversalDiscountRule(universalDiscount);
      yield return new UpcDiscountRule(upcDiscount);
    }
  }
}