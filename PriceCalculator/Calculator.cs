using System;
using System.Collections.Generic;
using System.Linq;
using PriceCalculator.Discounts;
using PriceCalculator.Reports;

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

    private Money BeforeTaxDiscount()
    {
      var discountAmount = _rules
        .Where(discountRule => discountRule.ApplyTo(_product) && discountRule.BeforeTax)
        .Sum(discountRule => _product.Price.Amount * (discountRule.Discount.DiscountPercentage / 100));
      return new Money(discountAmount);
    }

    private Money AfterTaxDiscount(Money price)
    {
      var discountAmount = _rules
        .Where(discountRule => discountRule.ApplyTo(_product) && discountRule.AfterTax)
        .Sum(discountRule => price * (discountRule.Discount.DiscountPercentage / 100));
      return new Money(discountAmount);
    }

    private Money CalculatedTax(Money price) => new Money(price * (_tax.TaxPercentage / 100));

    private string CalculatePrice()
    {
      var beforeTaxDiscount = BeforeTaxDiscount();
      var beforeTaxDiscountPrice = new Money(_product.Price.Amount - beforeTaxDiscount);
      var afterTaxDiscount = AfterTaxDiscount(beforeTaxDiscountPrice);
      var totalDiscount = new Money(beforeTaxDiscount + afterTaxDiscount);
      var tax = CalculatedTax(beforeTaxDiscountPrice);
      var finalPrice = new Money(beforeTaxDiscountPrice + tax - afterTaxDiscount);
      return new StringReport().PrintReport(_product.Price, totalDiscount, finalPrice);
    }


    public override string ToString() => CalculatePrice();
  }
}