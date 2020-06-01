namespace DesignPatterns.Creational.FactoryMethod.Discount
{
    public interface IDiscountFactory
    {
        Discount GetDiscount(Promotion promotion);
    }
}