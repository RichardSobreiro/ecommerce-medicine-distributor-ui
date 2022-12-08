using EcommerceMedDistUI.ViewModels;

namespace EcommerceMedDistUI.Services.IServices
{
    public interface IShoppingCartService
    {
        public event Action OnChange;
        Task DecrementCart(ShoppingCartVM shoppingCart);
        Task IncrementCart(ShoppingCartVM shoppingCart);
        Task<ShoppingCartVM> GetItemInShoppingCart(string productId);
    }
}
