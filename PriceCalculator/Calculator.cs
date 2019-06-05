using System;
using System.Collections.Generic;
using System.Linq;
using PriceCalculator.Discounts;

namespace PriceCalculator
{
  public class Calculator
  {
    private Product _product { get; }
    private Tax _tax { get; }
    private UniversalDiscount _universalDiscount { get; }
    private UpcDiscount _upcDiscount { get; }
    private IEnumerable<IDiscountRule> _rules => DiscountRuleFactory.Rules(_universalDiscount, _upcDiscount);

    public Calculator(Product product, Tax tax, UniversalDiscount universalDiscount, UpcDiscount upcDiscount)
    {
      _product = product;
      _tax = tax;
      _universalDiscount = universalDiscount;
      _upcDiscount = upcDiscount;
    }

    private Money CalculatedDiscount()
    {
      var discountAmount = _rules
        .Where(discountRule => discountRule.ApplyTo(_product))
        .Sum(discountRule => _product.Price.Amount * (discountRule.Discount.DiscountPercentage / 100));
      return new Money(discountAmount);
    }

    private Money CalculatedTax() => new Money(_product.Price.Amount * (_tax.TaxPercentage / 100));

    private Money CalculatePrice() => new Money(_product.Price.Amount - CalculatedDiscount() + CalculatedTax());
    

    public override string ToString() => $"Tax={_tax}{Environment.NewLine}Tax amount = {CalculatedTax()}{Environment.NewLine}Discount amount = {CalculatedDiscount()}{Environment.NewLine}Price before = {_product.Price}{Environment.NewLine}Price after = {CalculatePrice()}";
  }
}