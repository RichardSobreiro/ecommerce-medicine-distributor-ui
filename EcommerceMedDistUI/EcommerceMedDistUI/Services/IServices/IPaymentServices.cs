using EcommerceMedDistUI.ViewModels.Payment;

namespace EcommerceMedDistUI.Services.IServices
{
    public interface IPaymentServices
    {
        Task<PaymentResponseVM> CreateNewPayment(PaymentRequestVM paymentVM);
        Task<PaymentResponseVM> GetPayment(string paymentId);
        Task<List<PaymentResponseVM>> GetPaymentByUserEmail(string userEmail);
    }
}
