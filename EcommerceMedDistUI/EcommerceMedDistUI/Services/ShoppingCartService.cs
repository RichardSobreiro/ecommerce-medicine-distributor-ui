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

        public void InvokeOnchange()
        {
            OnChange.Invoke();
        }

        public async Task<ProductInCartVM> GetItemInShoppingCart(string productId)
        {
            var cart = await _localStorage.GetItemAsync<ShoppingCartVM>(Constants.ShoppingCart);
            if (cart == null)
            {
                cart = new ShoppingCartVM();
            }
            var productAlreadyInCart = cart.ProductsInCart.FirstOrDefault(p => p.Id == productId);
            if (productAlreadyInCart != null)
            {
                return productAlreadyInCart;
            }
            return null;
        }

        public async Task IncrementCart(ProductInCartVM productToBeAddedInCartVM)
        {
            var cart = await _localStorage.GetItemAsync<ShoppingCartVM>(Constants.ShoppingCart);
            if (cart == null)
            {
                cart = new ShoppingCartVM();
            }
            var productAlreadyInCart = cart.ProductsInCart.FirstOrDefault(p => p.Id == productToBeAddedInCartVM.Id);
            if(productAlreadyInCart != null)
            {
                foreach(var concentrationToAddInCart in productToBeAddedInCartVM.Concentrations)
                {
                    var concentrationInCart = productAlreadyInCart.Concentrations.FirstOrDefault(cic => 
                        cic.ConcentrationValue.CompareTo(concentrationToAddInCart.ConcentrationValue) == 0);
                    if(concentrationInCart != null)
                    {
                        concentrationInCart.Quantity = concentrationToAddInCart.Quantity;
                    }
                    else
                    {
                        productAlreadyInCart.Concentrations.Add(concentrationToAddInCart);
                    }
                }
            }
            else
            {
                cart.ProductsInCart.Add(productToBeAddedInCartVM);
            }
            await _localStorage.SetItemAsync(Constants.ShoppingCart, cart);
            OnChange.Invoke();
        }

        public async Task DecrementProductInCart(ProductInCartVM productInCart)
        {
            var cart = await _localStorage.GetItemAsync<ShoppingCartVM>(Constants.ShoppingCart);
            var productAlreadyInCart = cart.ProductsInCart.FirstOrDefault(p => p.Id == productInCart.Id);
            if (productAlreadyInCart != null)
            {
                var concentrationInCart = productAlreadyInCart.Concentrations.FirstOrDefault(cic =>
                    cic.ConcentrationValue == productInCart.Concentrations[0].ConcentrationValue);
                if (concentrationInCart != null)
                {
                    concentrationInCart.Quantity -= productInCart.Concentrations[0].Quantity;
                }
            }
            await _localStorage.SetItemAsync(Constants.ShoppingCart, cart);
            OnChange.Invoke();
        }

        public async Task UpdateShoppingCart(ShoppingCartVM shoppingCart)
        {
            await _localStorage.SetItemAsync(Constants.ShoppingCart, shoppingCart);
            OnChange.Invoke();
        }
    }
}
