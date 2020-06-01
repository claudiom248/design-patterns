namespace DesignPatterns.Creational.FactoryMethod.Discounts
{
    public abstract class Discount
    {
        public double DiscountValue { get; set; }

        public abstract double GetDiscountValue(Product product);
    }
}