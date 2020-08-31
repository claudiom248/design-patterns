using DesignPatterns.Creational.FactoryMethod;
using DesignPatterns.Creational.FactoryMethod.Discounts;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace DesignPatterns.Tests.Creational.FactoryMethod
{
    [TestFixture]
    public class DiscountFactoryTest
    {
        private readonly IDiscountFactory _discountFactory;

        public DiscountFactoryTest() => _discountFactory = new DiscountFactory();

        public static IEnumerable<TestCaseData> PromotionDiscountTypeTestCaseSource
        {
            get
            {
                yield return new TestCaseData(
                    new Promotion(DiscountType.AbsoluteValue, 5.0),
                    typeof(AbsoluteValueDiscount));

                yield return new TestCaseData(
                    new Promotion(DiscountType.Percentage, 5.0),
                    typeof(PercentageDiscount));
            }
        }

        [TestCaseSource("PromotionDiscountTypeTestCaseSource")]
        public void GetDiscount_ReturnsCorrectDiscountType(Promotion promotion, Type expectedDiscountType)
        {
            var discountType = _discountFactory.GetDiscount(promotion).GetType();

            Assert.AreEqual(expectedDiscountType, discountType);
        }

        [Test]
        public void GetDiscount_InvalidPromotion_Throws()
        {
            var invalidPromotion = new Promotion((DiscountType)10000, 5.0);

            Assert.Throws(typeof(NotSupportedException), () => _discountFactory.GetDiscount(invalidPromotion));
        }
    }
}
