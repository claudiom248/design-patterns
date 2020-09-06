namespace DesignPatterns.Creational.FactoryMethod.Discounts
{
    public class AbsoluteValueDiscount : Discount
    {
        public AbsoluteValueDiscount(double value) => Value = value;

        public override double Calculate(Product product) => Value;
    }
}
