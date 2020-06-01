using DesignPatterns.Creational.FactoryMethod.Discount;

namespace DesignPatterns.Creational.FactoryMethod
{
    public class Promotion
    {
        public DiscountType DiscountType { get; set; }

        public double DiscountValue { get; set; }

        public Promotion() { }
    }
}
