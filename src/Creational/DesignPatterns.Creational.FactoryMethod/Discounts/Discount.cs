namespace DesignPatterns.Creational.FactoryMethod.Discounts
{
    public abstract class Discount
    {
        public double Value { get; set; }

        public abstract double Calculate(Product product);
    }
}