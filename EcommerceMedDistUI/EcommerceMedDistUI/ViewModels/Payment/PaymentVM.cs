namespace EcommerceMedDistUI.ViewModels.Payment
{
    public class PaymentVM
    {
        public string CpfCnpj { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool BillingEqualShippingAddress { get; set; } = true;
        public ShoppingCartVM ShoppingCartVM { get; set; } = new();
        public AddressVM BillingAddressVM  { get;set; } = new();
        public AddressVM ShippimentAddressVM { get; set; } = new();
        public bool Boleto { get; set; } = true;
        public bool Pix { get; set; } = false;
        public bool CreditCard { get; set; } = false;
    }
}
