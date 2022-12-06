namespace EcommerceMedDistUI.ViewModels
{
    public class ConcentrationVM
    {
        public double ConcentrationValue { get; set; }
        public string ConcentrationDescription { get; set; } = "";
        public decimal PurchasePrice { get; set; }
        public decimal SellingPrice { get; set; }
        public int TotalStockQuantity { get; set; }
    }
}
