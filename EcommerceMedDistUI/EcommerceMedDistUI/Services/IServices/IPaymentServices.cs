using EcommerceMedDistUI.ViewModels.Payment;

namespace EcommerceMedDistUI.Services.IServices
{
    public interface IPaymentServices
    {
        Task<PaymentVM> CreateNewPayment(PaymentVM paymentVM);
        Task<PaymentVM> GetPayment(string paymentId);
    }
}
