﻿using EcommerceMedDistUI.ViewModels;

namespace EcommerceMedDistUI.Services.IServices
{
    public interface IShoppingCartService
    {
        public event Action OnChange;
        void InvokeOnchange();
        Task<ProductInCartVM> GetItemInShoppingCart(string productId);
        Task IncrementCart(ProductInCartVM productToBeAddedInCartVM);
        Task DecrementProductInCart(ProductInCartVM productToBeRemovedInCartVM);
        Task UpdateShoppingCart(ShoppingCartVM shoppingCart);
    }
}
