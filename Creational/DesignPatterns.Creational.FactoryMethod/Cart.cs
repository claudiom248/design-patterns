using DesignPatterns.Creational.FactoryMethod.Discounts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DesignPatterns.Creational.FactoryMethod
{
    public class Cart
    {
        private Promotion _appliedPromotion;
        private readonly ICollection<Product> _products;

        public bool IsPromotionApplied => _appliedPromotion != null;

        public Promotion AppliedPromotion => _appliedPromotion;

        public IEnumerable<Product> Products => _products.ToList();

        public double SubTotal => _products.Sum(p => p.BasePrice);

        public double GrandTotal => _products.Sum(p => p.Price);

        public Cart()
            : this(null) { }

        public Cart(ICollection<Product> products = null)
        {
            _products = products ?? new List<Product>();
        }

        public void AddProduct(Product product, IDiscountFactory discountFactory)
        {
            _products.Add(product);

            if (IsPromotionApplied)
            {
                ApplyDiscountOnProduct(product, GetDiscount(discountFactory));
            }
        }

        public void ApplyPromotion(Promotion promotion, IDiscountFactory discountFactory)
        {
            if (IsPromotionApplied)
            {
                throw new InvalidOperationException("A promotion has already been applied to the cart.");
            }

            _appliedPromotion = promotion;
            ApplyDiscountOnProducts(GetDiscount(discountFactory));
        }

        public void UnapplyPromotion()
        {
            if (!IsPromotionApplied)
            {
                throw new InvalidOperationException("No promotion applied to the cart.");
            }

            _appliedPromotion = null;
            UnapplyDiscountOnProducts();
        }

        private void ApplyDiscountOnProducts(Discount discount)
        {
            foreach (Product product in _products)
            {
                ApplyDiscountOnProduct(product, discount);
            }
        }

        private void ApplyDiscountOnProduct(Product product, Discount discount)
        {
            product.AppliedDiscount = discount.GetDiscountValue(product);
        }

        private void UnapplyDiscountOnProducts()
        {
            foreach (Product product in _products)
            {
                product.AppliedDiscount = 0;
            }
        }

        private Discount GetDiscount(IDiscountFactory discountFactory)
        {
            return discountFactory.GetDiscount(_appliedPromotion);
        }
    }
}
