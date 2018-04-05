using AuditPlus.Helpers;

namespace AuditPlus.ViewModels
{
    class LoginViewModel
    {
        public bool IsEnvironmentPickerAvailable { get; set; }

        public LoginViewModel()
        {
            IsEnvironmentPickerAvailable = Constants.ENVIRONMENT_SELECTOR;
        }
    }
}
