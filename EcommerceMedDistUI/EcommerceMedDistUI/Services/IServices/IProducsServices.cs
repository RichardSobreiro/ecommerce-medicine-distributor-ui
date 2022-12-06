using EcommerceMedDistUI.ViewModels;

namespace EcommerceMedDistUI.Services.IServices
{
    public interface IProducsServices
    {
        Task<List<ProductVM>> SearchProductByName(string partialName);
        Task<ProductVM> GetProductById(string productId);
    }
}
