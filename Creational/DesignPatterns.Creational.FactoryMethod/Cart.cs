using DesignPatterns.Creational.FactoryMethod.Discounts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DesignPatterns.Creational.FactoryMethod
{
    public class Cart
    {
        private readonly ICollection<Product> _products;

        public bool IsPromotionApplied => AppliedPromotion != null;

        public Promotion AppliedPromotion { get; private set; }

        public IEnumerable<Product> Products => _products.ToList();

        public double SubTotal => _products.Sum(p => p.BasePrice);

        public double GrandTotal => _products.Sum(p => p.Price);

        public Cart()
            : this(null) { }

        public Cart(ICollection<Product> products = null) => _products = products ?? new List<Product>();

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

            AppliedPromotion = promotion;
            ApplyDiscountOnProducts(GetDiscount(discountFactory));
        }

        public void UnapplyPromotion()
        {
            if (!IsPromotionApplied)
            {
                throw new InvalidOperationException("No promotion applied to the cart.");
            }

            AppliedPromotion = null;
            UnapplyDiscountOnProducts();
        }

        private void ApplyDiscountOnProducts(Discount discount)
        {
            foreach (var product in _products)
            {
                ApplyDiscountOnProduct(product, discount);
            }
        }

        private void ApplyDiscountOnProduct(Product product, Discount discount) => product.AppliedDiscount = discount.Calculate(product);

        private void UnapplyDiscountOnProducts()
        {
            foreach (var product in _products)
            {
                product.AppliedDiscount = 0;
            }
        }

        private Discount GetDiscount(IDiscountFactory discountFactory) => discountFactory.GetDiscount(AppliedPromotion);
    }
}
