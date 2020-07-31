namespace DesignPatterns.Creational.FactoryMethod.Discounts
{
    public class PercentageDiscount : Discount
    {
        public PercentageDiscount(double value) => Value = value;

        public override double Calculate(Product product) => product.BasePrice * Value / 100;
    }
}
