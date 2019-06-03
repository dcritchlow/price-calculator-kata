namespace PriceCalculator
{
  public class Product
  {
    public string Name { get; set; }
    public int Upc { get; set; }
    public Money Price { get; set; }

    public Product()
    {
      
    }
    public Product(string name, int upc, Money price)
    {
      Name = name;
      Upc = upc;
      Price = price;
    }
  }
}