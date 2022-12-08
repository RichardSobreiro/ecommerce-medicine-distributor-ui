using Blazored.LocalStorage;
using EcommerceMedDistUI.Services.IServices;
using EcommerceMedDistUI.Utils;
using EcommerceMedDistUI.ViewModels;

namespace EcommerceMedDistUI.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly ILocalStorageService _localStorage;
        public event Action OnChange;

        public ShoppingCartService(ILocalStorageService localStorageService)
        {
            _localStorage = localStorageService;
        }

        public async Task<ShoppingCartVM> GetItemInShoppingCart(string productId)
        {
            var cart = await _localStorage.GetItemAsync<List<ShoppingCartVM>>(Constants.ShoppingCart);
            if (cart == null)
            {
                cart = new List<ShoppingCartVM>();
            }
            var productAlreadyInCart = cart.FirstOrDefault(sci => sci.ProductInCart.Id == productId);
            if (productAlreadyInCart != null)
            {
                return productAlreadyInCart;
            }
            return null;
        }

        public async Task IncrementCart(ShoppingCartVM cartToAdd)
        {
            var cart = await _localStorage.GetItemAsync<List<ShoppingCartVM>>(Constants.ShoppingCart);
            if (cart == null)
            {
                cart = new List<ShoppingCartVM>();
            }
            var productAlreadyInCart = cart.FirstOrDefault(sci => sci.ProductInCart.Id == cartToAdd.ProductInCart.Id);
            if(productAlreadyInCart != null)
            {
                foreach(var concentrationToAddInCart in cartToAdd.ProductInCart.Concentrations)
                {
                    var concentrationInCart = productAlreadyInCart.ProductInCart.Concentrations.FirstOrDefault(cic => 
                        cic.ConcentrationValue.CompareTo(concentrationToAddInCart.ConcentrationValue) == 0);
                    if(concentrationInCart != null)
                    {
                        concentrationInCart.Quantity = concentrationToAddInCart.Quantity;
                    }
                    else
                    {
                        productAlreadyInCart.ProductInCart.Concentrations.Add(concentrationToAddInCart);
                    }
                }
            }
            else
            {
                cart.Add(cartToAdd);
            }
            await _localStorage.SetItemAsync(Constants.ShoppingCart, cart);
            OnChange.Invoke();
        }

        public async Task DecrementCart(ShoppingCartVM cartToDecrement)
        {
            var cart = await _localStorage.GetItemAsync<List<ShoppingCartVM>>(Constants.ShoppingCart);
            var productAlreadyInCart = cart.FirstOrDefault(sci => sci.ProductInCart.Id == cartToDecrement.ProductInCart.Id);
            if (productAlreadyInCart != null)
            {
                var concentrationInCart = productAlreadyInCart.ProductInCart.Concentrations.FirstOrDefault(cic =>
                    cic.ConcentrationValue == cartToDecrement.ProductInCart.Concentrations[0].ConcentrationValue);
                if (concentrationInCart != null)
                {
                    concentrationInCart.Quantity -= cartToDecrement.ProductInCart.Concentrations[0].Quantity;
                }
            }
            await _localStorage.SetItemAsync(Constants.ShoppingCart, cart);
            OnChange.Invoke();
        }

        public async Task UpdateShoppingCart(List<ShoppingCartVM> shoppingCart)
        {
            await _localStorage.SetItemAsync(Constants.ShoppingCart, shoppingCart);
            OnChange.Invoke();
        }
    }
}
