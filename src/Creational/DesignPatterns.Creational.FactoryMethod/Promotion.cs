using DesignPatterns.Creational.FactoryMethod.Discounts;
using System;

namespace DesignPatterns.Creational.FactoryMethod
{
    public class Promotion
    {
        public Promotion(DiscountType discountType, double value)
        {
            if (value <= default(double))
            {
                throw new ArgumentException($"{nameof(value)} cannot be less than or equal to {default(double)}");
            }

            Type = discountType;
            Value = value;
        }

        public DiscountType Type { get; set; }

        public double Value { get; set; }
    }
}