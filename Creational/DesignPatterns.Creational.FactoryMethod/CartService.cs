using DesignPatterns.Creational.FactoryMethod.Discounts;

namespace DesignPatterns.Creational.FactoryMethod
{
    public class CartService
    {
        private readonly Cart _cart;
        private readonly IDiscountFactory _discountFactory;

        public CartService(Cart cart, IDiscountFactory discountFactory)
        {
            _cart = cart;
            _discountFactory = discountFactory;
        }

        public void AddProduct(Product product) => _cart.AddProduct(product, _discountFactory);

        public void ApplyPromotion(Promotion promotion) => _cart.ApplyPromotion(promotion, _discountFactory);

        public void UnapplyPromotion() => _cart.UnapplyPromotion();
    }
}
