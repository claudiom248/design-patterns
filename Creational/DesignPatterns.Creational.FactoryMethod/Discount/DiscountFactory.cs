using System;

namespace DesignPatterns.Creational.FactoryMethod.Discount
{
    public static class DiscountFactory
    {
        public static Discount GetDiscount(Promotion promotion) =>
            promotion.DiscountType switch
            {
                DiscountType.AbsoluteValue => new AbsoluteValueDiscount(promotion.DiscountValue),
                DiscountType.Percentage => new PercentageDiscount(promotion.DiscountValue),
                _ => throw new NotSupportedException($"Invalid discount type {promotion.DiscountType}")
            };
    }
}
