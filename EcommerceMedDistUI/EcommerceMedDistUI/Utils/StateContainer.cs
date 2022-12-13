using EcommerceMedDistUI.ViewModels.Payment;

namespace EcommerceMedDistUI.Utils
{
    public class StateContainer
    {
        private PaymentVM PaymentVM { get; set; } = null;

        public PaymentVM Property
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
