using DesignPatterns.Creational.FactoryMethod;
using DesignPatterns.Creational.FactoryMethod.Discounts;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace DesignPatterns.Tests.Creational.FactoryMethod
{
    [TestFixture]
    public class IDiscountFactoryTests
    {
        private IDiscountFactory _discountFactory;

        [OneTimeSetUp]
        public void Setup()
        {
            _discountFactory = new DiscountFactory();
        }

        public static IEnumerable<TestCaseData> TestCaseSource
        {
            get
            {
                yield return new TestCaseData(
                    new Promotion()
                    {
                        DiscountType = DiscountType.AbsoluteValue,
                        DiscountValue = 10.00
                    },
                    typeof(AbsoluteValueDiscount));

                yield return new TestCaseData(
                    new Promotion()
                    {
                        DiscountType = DiscountType.Percentage,
                        DiscountValue = 5
                    }, 
                    typeof(PercentageDiscount));
            }
        }

        [TestCaseSource("TestCaseSource")]
        public void Should_Create_Discount_Of_Correct_Type_Given_Promotion_Discount_Type(Promotion promotion, Type expectedDiscountType)
        {
            var discountType = _discountFactory.GetDiscount(promotion).GetType();

            Assert.AreEqual(expectedDiscountType, discountType);
        }

        [Test]
        public void Should_Throw_When_Promotion_Has_Invalid_Discount_Type()
        {
            var invalidPromotion = new Promotion()
            {
                DiscountType = (DiscountType)10000
            };

            Assert.Throws(typeof(NotSupportedException), () => _discountFactory.GetDiscount(invalidPromotion));
        }
    }
}
