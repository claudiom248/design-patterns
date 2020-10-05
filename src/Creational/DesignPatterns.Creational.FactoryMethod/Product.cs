namespace DesignPatterns.Creational.FactoryMethod
{
    public class Product
    {
        public double BasePrice { get; set; }

        public double AppliedDiscount { get; set; }

        public double Price => BasePrice - AppliedDiscount;
    }
}