namespace DesignPatterns.Creational.FactoryMethod.Discounts
{
    public interface IDiscountFactory
    {
        Discount GetDiscount(Promotion promotion);
    }
}