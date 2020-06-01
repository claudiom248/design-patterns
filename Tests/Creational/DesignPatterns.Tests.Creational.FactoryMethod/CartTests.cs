using DesignPatterns.Creational.FactoryMethod;
using DesignPatterns.Creational.FactoryMethod.Discount;
using NUnit.Framework;
using System;

namespace DesignPatterns.Tests.Creational.FactoryMethod
{
    [TestFixture]
    public class CartTests
    {
        private Cart _cart;
        private IDiscountFactory _discountFactory;
        private Promotion _promotionWithAbsoluteValueDiscount;
        private Promotion _promotionWithPercentageDiscount;

        private double CartTotalWithoutDiscounts => _cart.TotalWithoutDiscounts;

        private double CartTotal => _cart.Total;

        [OneTimeSetUp]
        public void Setup()
        {
            _cart = new Cart();
            _discountFactory = new DiscountFactory();

            CreatePromotions();
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

        [Test]
        public void Cart_Total_Should_Be_Sum_Of_Products_Price_Without_Discount()
        {
            Assert.AreEqual(CartTotalWithoutDiscounts, CartTotal);
        }

        [Test]
        public void Cart_Total_Should_Be_Sum_Of_Products_Prices_Discounted_By_Percentage_Value()
        {
            _cart.ApplyPromotion(_promotionWithPercentageDiscount, _discountFactory);

            Assert.AreNotEqual(CartTotalWithoutDiscounts, CartTotal);
            Assert.AreEqual(92.15, CartTotal);
        }

        [Test]
        public void Cart_Total_Should_Be_Sum_Of_Products_Price_Discounted_By_Absolute_Value()
        {
            _cart.ApplyPromotion(_promotionWithAbsoluteValueDiscount, _discountFactory);

            Assert.AreNotEqual(CartTotalWithoutDiscounts, CartTotal);
            Assert.AreEqual(67, CartTotal);
        }

        [Test]
        public void Should_Throw_When_Trying_To_Apply_Promotion_More_Than_Once()
        {
            _cart.ApplyPromotion(_promotionWithAbsoluteValueDiscount, _discountFactory);

            Assert.Throws(typeof(InvalidOperationException), () => _cart.ApplyPromotion(_promotionWithPercentageDiscount, _discountFactory));
        }
        [Test]
        public void Should_Throw_When_Trying_To_Unapply_Promotion_When_No_Promotion_Is_Applied()
        {
            Assert.Throws(typeof(InvalidOperationException), () => _cart.UnapplyPromotion());
        }

        private void FillCartWithProducts()
        {
            _cart.AddProduct(
                new Product()
                {
                    BasePrice = 30
                },
                _discountFactory);

            _cart.AddProduct(
                new Product()
                {
                    BasePrice = 42
                },
                _discountFactory);

            _cart.AddProduct(
                new Product()
                {
                    BasePrice = 25
                },
                _discountFactory);
        }

        private void CreatePromotions()
        {
            _promotionWithAbsoluteValueDiscount = new Promotion()
            {
                DiscountType = DiscountType.AbsoluteValue,
                DiscountValue = 10.00
            };

            _promotionWithPercentageDiscount = new Promotion()
            {
                DiscountType = DiscountType.Percentage,
                DiscountValue = 5
            };
        }
    }
}
