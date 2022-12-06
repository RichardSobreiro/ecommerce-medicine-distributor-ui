using EcommerceMedDistUI.Services.IServices;
using EcommerceMedDistUI.ViewModels;
using Newtonsoft.Json;

namespace EcommerceMedDistUI.Services
{
    public class ProducsServices : IProducsServices
    {
        private readonly HttpClient _httpClient;

        public ProducsServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ProductVM>> SearchProductByName(string partialName)
        {
            var response = await _httpClient.GetAsync($"api/products?partialName={partialName}");
            if (response != null)
            {
                string responseResult = response.Content.ReadAsStringAsync().Result;
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(responseResult);
                }
                else
                {
                    var result = JsonConvert.DeserializeObject<List<ProductVM>>(responseResult);
                    return result;
                }
            }
            return new List<ProductVM>();
        }

        public async Task<ProductVM> GetProductById(string productId)
        {
            var response = await _httpClient.GetAsync($"api/products/{productId}");
            if (response != null)
            {
                string responseResult = response.Content.ReadAsStringAsync().Result;
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(responseResult);
                }
                else
                {
                    var result = JsonConvert.DeserializeObject<ProductVM>(responseResult);
                    return result;
                }
            }
            return new ProductVM();
        }
    }
}
