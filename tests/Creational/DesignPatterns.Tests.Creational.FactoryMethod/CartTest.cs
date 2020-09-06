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
        private const double CartGrandTotalWithoutDiscounts = 97;

        private Cart _cart;
        private readonly IDiscountFactory _discountFactory;

        public CartTest() => _discountFactory = new DiscountFactory();

        [SetUp]
        public void Setup()
        {
            _cart = new Cart();

            FillCartWithProducts();
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
                CartGrandTotalWithoutDiscounts);

            yield return new TestCaseData(
                new Promotion(DiscountType.Percentage, 5.00),
                CartGrandTotalWithoutDiscounts);
        }


        [TestCaseSource("PromotionExpectedDiscountsTestCaseSource1")]
        public void ApplyPromotion_SetDiscounts(Promotion promotion, double expectedGrandTotal)
        {
            _cart.ApplyPromotion(promotion, _discountFactory);

            Assert.AreEqual(expectedGrandTotal, _cart.GrandTotal);
        }

        [TestCaseSource("PromotionExpectedDiscountsTestCaseSource2")]
        public void ApplyPromotion_ThenUnapply_RemoveDisccounts(Promotion promotion, double expectedGrandTotal)
        {
            _cart.ApplyPromotion(promotion, _discountFactory);
            Assert.AreNotEqual(CartGrandTotalWithoutDiscounts, _cart.GrandTotal);

            _cart.UnapplyPromotion();
            Assert.AreEqual(expectedGrandTotal, _cart.GrandTotal);
        }

        [Test]
        public void ApplyPromotion_CallTwice_Throws()
        {
            var promotion = new Promotion(DiscountType.Percentage, 10.00);

            Assert.Throws(typeof(InvalidOperationException), () =>
            {
                _cart.ApplyPromotion(promotion, _discountFactory);
                _cart.ApplyPromotion(promotion, _discountFactory);
            });
        }

        [Test]
        public void UnapplyPromotion_CartWithoutPromotion_Throws() 
            => Assert.Throws(typeof(InvalidOperationException), () => _cart.UnapplyPromotion());

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
    }
}
