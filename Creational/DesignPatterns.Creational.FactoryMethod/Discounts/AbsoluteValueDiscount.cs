namespace DesignPatterns.Creational.FactoryMethod.Discounts
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