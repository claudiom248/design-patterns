using DesignPatterns.Creational.FactoryMethod;
using DesignPatterns.Creational.FactoryMethod.Discounts;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace DesignPatterns.Tests.Creational.FactoryMethod
{
    [TestFixture]
    public class CartTest
    {
        private const double UndiscountedProductsTotalValue = 97;

        private readonly Cart _cart;
        private readonly IDiscountFactory _discountFactory;

        public CartTest()
        {
            _cart = new Cart();
            _discountFactory = new DiscountFactory();

            FillCartWithProducts();
        }

        [TearDown]
        public void TearDown()
        {
            if (_cart.IsPromotionApplied)
            {
                _cart.UnapplyPromotion();
            }
        }

        public static IEnumerable<TestCaseData> PromotionExpectedDiscountsTestCaseSource1()
        {
            yield return new TestCaseData(
                new Promotion(DiscountType.AbsoluteValue, 10.00),
                67.00);

            yield return new TestCaseData(
                new Promotion(DiscountType.Percentage, 5.00),
                92.15);
        }

        public static IEnumerable<TestCaseData> PromotionExpectedDiscountsTestCaseSource2()
        {
            yield return new TestCaseData(
                new Promotion(DiscountType.AbsoluteValue, 10.00),
                UndiscountedProductsTotalValue);

            yield return new TestCaseData(
                new Promotion(DiscountType.Percentage, 5.00),
                UndiscountedProductsTotalValue);
        }

        public void Cart_Total_Should_Be_Sum_Of_Products_Price_Without_Discount()
        {
            Assert.AreEqual(UndiscountedProductsTotalValue, _cart.GrandTotal);
        }

        [TestCaseSource("PromotionExpectedDiscountsTestCaseSource1")]
        public void Cart_Total_Should_Be_Sum_Of_Products_Prices_Discounted_By_Applied_Promotion_Discount_Value(Promotion promotion, double expectedGrandTotal)
        {
            _cart.ApplyPromotion(promotion, _discountFactory);

            Assert.AreNotEqual(UndiscountedProductsTotalValue, _cart.GrandTotal);
            Assert.AreEqual(expectedGrandTotal, _cart.GrandTotal);
        }

        [TestCaseSource("PromotionExpectedDiscountsTestCaseSource2")]
        public void Cart_Total_Should_Be_Sum_Of_Products_Prices_When_Promotion_Is_Unapplied(Promotion promotion, double expectedGrandTotal)
        {
            _cart.ApplyPromotion(promotion, _discountFactory);
            _cart.UnapplyPromotion();

            Assert.AreEqual(UndiscountedProductsTotalValue, _cart.GrandTotal);
            Assert.AreEqual(expectedGrandTotal, _cart.GrandTotal);
        }

        [Test]
        public void Should_Throw_When_Trying_To_Apply_Promotion_More_Than_Once()
        {
            var promotion = new Promotion(DiscountType.Percentage, 10.00);

            Assert.Throws(typeof(InvalidOperationException), () =>
            {
                _cart.ApplyPromotion(promotion, _discountFactory);
                _cart.ApplyPromotion(promotion, _discountFactory);
            });
        }

        [Test]
        public void Should_Throw_When_Trying_To_Unapply_Promotion_And_No_Promotion_Is_Applied()
        {
            Assert.Throws(typeof(InvalidOperationException), () => _cart.UnapplyPromotion());
        }

        private void FillCartWithProducts()
        {
            _cart.AddProduct(
                new Product()
                {
                    BasePrice = 30.00
                },
                _discountFactory);

            _cart.AddProduct(
                new Product()
                {
                    BasePrice = 42.00
                },
                _discountFactory);

            _cart.AddProduct(
                new Product()
                {
                    BasePrice = 25.00
                },
                _discountFactory);
        }

        public class PromotionExpectedTotalDiscount
        {
            public Promotion Promotion;
            public double ExpectedTotalDiscount;
        }
    }
}
