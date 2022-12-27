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

        public async Task<PaymentResponseVM> CreateNewPayment(PaymentRequestVM paymentVM)
        {
            var content = JsonConvert.SerializeObject(paymentVM);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("api/payments", bodyContent);
            if (response != null)
            {
                string responseResult = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(responseResult);
                }
                else
                {
                    var result = JsonConvert.DeserializeObject<PaymentResponseVM>(responseResult);
                    return result;
                }
            }
            else
            {
                throw new Exception("Pagamento não existe!");
            }
        }

        public async Task<PaymentResponseVM> GetPayment(string paymentId)
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
                    var result = JsonConvert.DeserializeObject<PaymentResponseVM>(responseResult);
                    return result;
                }
            }
            else
            {
                throw new Exception("Pagamento não existe!");
            }
        }

        public async Task<List<PaymentResponseVM>> GetPaymentByUserEmail(string userEmail)
        {
            var response = await _httpClient.GetAsync($"api/payments/boleto/{userEmail}");
            if (response != null)
            {
                string responseResult = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(responseResult);
                }
                else
                {
                    var result = JsonConvert.DeserializeObject<List<PaymentResponseVM>>(responseResult);
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
