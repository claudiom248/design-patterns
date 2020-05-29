namespace DesignPatterns.Creational.FactoryMethod.Discount
{
    public class AbsoluteValueDiscount : Discount
    {
        public AbsoluteValueDiscount(double value)
        {
            DiscountValue = value;
        }

        public override double GetDiscountValue(Product product)
        {
            return DiscountValue;
        }
    }
}