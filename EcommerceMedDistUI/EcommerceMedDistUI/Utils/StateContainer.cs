using EcommerceMedDistUI.ViewModels.Payment;

namespace EcommerceMedDistUI.Utils
{
    public class StateContainer
    {
        private PaymentRequestVM PaymentVM { get; set; } = null;

        public PaymentRequestVM Property
        {
            get => PaymentVM;
            set
            {
                PaymentVM = value;
                NotifyStateChanged();
            }
        }

        public event Action? OnChange;

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
