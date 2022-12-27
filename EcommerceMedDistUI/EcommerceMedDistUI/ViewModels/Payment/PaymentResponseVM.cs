namespace EcommerceMedDistUI.ViewModels.Payment
{
    public class PaymentResponseVM
    {
        public string? Id { get; set; } = string.Empty;
        public string UserEmail { get; set; } = string.Empty;
        public string CpfCnpj { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool BillingEqualShippingAddress { get; set; } = true;
        public ShoppingCartVM ShoppingCart { get; set; } = new();
        public AddressVM BillingAddress { get; set; } = new();
        public AddressVM ShippimentAddress { get; set; } = new();
        public bool Boleto { get; set; } = true;
        public bool Pix { get; set; } = false;
        public bool CreditCard { get; set; } = false;
        public DateTime DueDate { get; set; }
        public string Status { get; set; } = string.Empty;
        public BoletoResponseVM BoletoResponse { get; set; } = new();

        public class BoletoResponseVM
        {
            public string id { get; set; } = string.Empty;
            public string reference_id { get; set; } = string.Empty;
            public string status { get; set; } = string.Empty;
            public string created_at { get; set; } = string.Empty;
            public string paid_at { get; set; } = string.Empty;
            public string description { get; set; } = string.Empty;
            public BoletoVM Boleto { get; set; } = new();

            public class BoletoVM
            {
                public string id { get; set; } = string.Empty;
                public string barcode { get; set; } = string.Empty;
                public string formatted_barcode { get; set; } = string.Empty;
                public string link { get; set; } = string.Empty;
            }
        }
        public class AddressVM
        {
            public string Cep { get; set; } = string.Empty;
            public string Street { get; set; } = string.Empty;
            public string Complement { get; set; } = string.Empty;
            public string District { get; set; } = string.Empty;
            public string City { get; set; } = string.Empty;
            public string State { get; set; } = string.Empty;
            public string Number { get; set; } = string.Empty;
        }
        public class ShoppingCartVM
        {
            public string ShoppingCartId { get; set; } = "";
            public List<ProductInCartVM> ProductsInCart { get; set; } = new();
        }
        public class ProductInCartVM
        {
            public string? Id { get; set; } = "";
            public string Name { get; set; } = "";
            public string Description { get; set; } = "";
            public string? MeasurementUnitId { get; set; }
            public List<ConcentrationInCartVM> Concentrations { get; set; } = new();
            public decimal SellingPrice { get; set; }
            public int Quantity { get; set; }
        }
        public class ConcentrationInCartVM
        {
            public double ConcentrationValue { get; set; }
            public string ConcentrationDescription { get; set; } = "";
            public decimal SellingPrice { get; set; }
            public int Quantity { get; set; }
        }
    }
}
