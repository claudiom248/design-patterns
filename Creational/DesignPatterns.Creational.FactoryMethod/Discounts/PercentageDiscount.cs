namespace DesignPatterns.Creational.FactoryMethod.Discounts
{
    public class PercentageDiscount : Discount
    {
        public PercentageDiscount(double value) => DiscountValue = value;

        public override double GetDiscountValue(Product product) => (product.BasePrice * DiscountValue) / 100;
    }
}
