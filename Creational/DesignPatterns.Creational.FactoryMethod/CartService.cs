using DesignPatterns.Creational.FactoryMethod.Discount;

namespace DesignPatterns.Creational.FactoryMethod
{
    public class CartService
    {
        private Cart _cart;
        private DiscountFactory _discountFactory;

        public CartService(Cart cart, DiscountFactory discountFactory)
        {
            _cart = cart;
            _discountFactory = discountFactory;
        }

        public void AddProduct(Product product)
        {
            _cart.AddProduct(product, _discountFactory);
        }

        public void ApplyPromotion(Promotion promotion)
        {
            _cart.ApplyPromotion(promotion, _discountFactory);
        }

        public void UnapplyPromotion()
        {
            _cart.UnapplyPromotion();
        }
    }
}
