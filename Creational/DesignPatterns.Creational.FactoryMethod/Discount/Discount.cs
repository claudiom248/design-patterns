namespace DesignPatterns.Creational.FactoryMethod.Discount
{
    public abstract class Discount
    {
        public double DiscountValue { get; set; }

        public abstract double GetDiscountValue(Product product);
    }
}