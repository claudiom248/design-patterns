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
            : this (null) { }

        public Cart(ICollection<Product> products = null) => 
            _products = products ?? new List<Product>();


        public double Total => _products.Sum(p => p.Price);

        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        public void ApplyPromotion(Promotion promotion)
        {
            _appliedPromotion = promotion;
            ApplyDiscount();
        }

        public void UnapplyPromotion()
        {
            _appliedPromotion = null;
            UnapplyDiscount();
        }

        private void ApplyDiscount()
        {
            var discount = DiscountFactory.GetDiscount(_appliedPromotion);

            foreach (var product in _products)
            {
                product.AppliedDiscount = discount.GetDiscountValue(product);
            }
        }

        private void UnapplyDiscount()
        {
            foreach (var product in _products)
            {
                product.AppliedDiscount = 0;
            }
        }
    }
}
