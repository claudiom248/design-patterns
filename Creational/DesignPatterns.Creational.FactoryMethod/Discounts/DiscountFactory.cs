using System;

namespace DesignPatterns.Creational.FactoryMethod.Discounts
{
    public class DiscountFactory : IDiscountFactory
    {
        public Discount GetDiscount(Promotion promotion) =>
            promotion.DiscountType switch
            {
                DiscountType.AbsoluteValue => new AbsoluteValueDiscount(promotion.DiscountValue),
                DiscountType.Percentage => new PercentageDiscount(promotion.DiscountValue),
                _ => throw new NotSupportedException($"Invalid discount type {promotion.DiscountType}")
            };
    }
}
