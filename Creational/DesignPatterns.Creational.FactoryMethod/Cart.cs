using DesignPatterns.Creational.FactoryMethod.Discount;
using System.Collections.Generic;
using System.Linq;

namespace DesignPatterns.Creational.FactoryMethod
{
    public class Cart
    {
        private Promotion _appliedPromotion;
        private ICollection<Product> _products;

        public Cart()
            : this(null) { }

        public Cart(ICollection<Product> products = null) =>
            _products = products ?? new List<Product>();


        public double Total => _products.Sum(p => p.Price);

        public void AddProduct(Product product, IDiscountFactory discountFactory)
        {
            _products.Add(product);

            if (_appliedPromotion != null)
            {
                ApplyDiscountOnProduct(product, GetDiscount(discountFactory));
            }
        }

        public void ApplyPromotion(Promotion promotion, IDiscountFactory discountFactory)
        {
            _appliedPromotion = promotion;
            ApplyDiscountOnProducts(GetDiscount(discountFactory));
        }

        public void UnapplyPromotion()
        {
            _appliedPromotion = null;
            UnapplyDiscountOnProducts();
        }

        private void ApplyDiscountOnProducts(Discount.Discount discount)
        {
            foreach (var product in _products)
            {
                ApplyDiscountOnProduct(product, discount);
            }
        }

        private void ApplyDiscountOnProduct(Product product, Discount.Discount discount)
        {
            product.AppliedDiscount = discount.GetDiscountValue(product);
        }

        private void UnapplyDiscountOnProducts()
        {
            foreach (var product in _products)
            {
                product.AppliedDiscount = 0;
            }
        }

        private Discount.Discount GetDiscount(IDiscountFactory discountFactory)
        {
            return discountFactory.GetDiscount(_appliedPromotion);
        }
    }
}
