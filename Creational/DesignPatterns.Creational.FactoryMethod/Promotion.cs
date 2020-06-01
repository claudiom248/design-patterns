using DesignPatterns.Creational.FactoryMethod.Discounts;

namespace DesignPatterns.Creational.FactoryMethod
{
    public class Promotion
    {
        public DiscountType DiscountType { get; set; }

        public double DiscountValue { get; set; }

        public Promotion() { }
    }
}
