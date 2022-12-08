namespace EcommerceMedDistUI.ViewModels
{
    public class ProductInCartVM
    {
        public string? Id { get; set; } = "";
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public string? MeasurementUnitId { get; set; }
        public List<ConcentrationInCartVM> Concentrations { get; set; } = new();
    }
}
