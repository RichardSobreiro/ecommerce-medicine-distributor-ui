namespace EcommerceMedDistUI.ViewModels
{
    public class ShoppingCartVM
    {
        public string ShoppingCartId { get; set; } = "";
        public List<ProductInCartVM> ProductsInCart { get; set; } = new List<ProductInCartVM>();
    }
}
