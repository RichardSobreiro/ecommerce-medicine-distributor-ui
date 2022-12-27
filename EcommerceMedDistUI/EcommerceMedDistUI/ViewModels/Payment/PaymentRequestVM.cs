namespace EcommerceMedDistUI.ViewModels.Payment
{
    public class PaymentRequestVM
    {
        public string? Id { get; set; } = string.Empty;
        public string UserEmail { get; set; } = string.Empty;
        public string CpfCnpj { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool BillingEqualShippingAddress { get; set; } = true;
        public ShoppingCartVM ShoppingCart { get; set; } = new();
        public AddressVM BillingAddress { get;set; } = new();
        public AddressVM ShippimentAddress { get; set; } = new();
        public bool Boleto { get; set; } = true;
        public bool Pix { get; set; } = false;
        public bool CreditCard { get; set; } = false;
        public DateTime DueDate { get; set; }
    }
}
