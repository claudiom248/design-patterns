using System;

namespace DesignPatterns.Creational.FactoryMethod.Discounts
{
    public class DiscountFactory : IDiscountFactory
    {
        public Discount GetDiscount(Promotion promotion) 
            => promotion.Type switch
            {
                DiscountType.AbsoluteValue => new AbsoluteValueDiscount(promotion.Value),
                DiscountType.Percentage => new PercentageDiscount(promotion.Value),
                _ => throw new NotSupportedException($"Invalid discount type {promotion.Type}")
            };
    }
}
