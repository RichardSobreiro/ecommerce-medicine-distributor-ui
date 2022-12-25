using EcommerceMedDistUI.Services.IServices;
using EcommerceMedDistUI.ViewModels.Payment;
using Newtonsoft.Json;
using System.Text;

namespace EcommerceMedDistUI.Services
{
    public class PaymentServices : IPaymentServices
    {
        private readonly HttpClient _httpClient;

        public PaymentServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<PaymentVM> CreateNewPayment(PaymentVM paymentVM)
        {
            var content = JsonConvert.SerializeObject(paymentVM);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("api/payments", bodyContent);
            if (response != null)
            {
                string responseResult = response.Content.ReadAsStringAsync().Result;
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(responseResult);
                }
                else
                {
                    var result = JsonConvert.DeserializeObject<PaymentVM>(responseResult);
                    return result;
                }
            }
            else
            {
                throw new Exception("Pagamento não existe!");
            }
        }

        public async Task<PaymentVM> GetPayment(string paymentId)
        {
            var response = await _httpClient.GetAsync($"api/payments/{paymentId}");
            if (response != null)
            {
                string responseResult = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(responseResult);
                }
                else
                {
                    var result = JsonConvert.DeserializeObject<PaymentVM>(responseResult);
                    return result;
                }
            }
            else
            {
                throw new Exception("Pagamento não existe!");
            }
        }
    }
}
