using ParentsAndKids.Services.Navigation;
using ParentsAndKids.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ParentsAndKids.ViewModels {
    public sealed class LoginViewModel : BaseCommonPageViewModel {

        private static readonly string _LOGIN_HEADER = "Login";

        public ICommand ForgotPasswordCommand => new Command(async () => await ForgotPasswordAsync());

        public ICommand LoginCommand => new Command(async () => await LoginAsync());

        /// <summary>
        ///     ctor().
        /// </summary>
        public LoginViewModel() {
            ActionBarHeader = _LOGIN_HEADER;

            BackCommand = new Command(async () => {
                await NavigationService.GoBackAsync();
            });
        }

        private async Task LoginAsync() {
            IsBusy = true;
            await NavigationService.NavigateToAsync<MainViewModel>();
            await NavigationService.RemoveBackStackAsync();
            IsBusy = false;
        }

        private async Task ForgotPasswordAsync() {
            await DialogService.ShowAlertAsync("Your E-mail / UserName", "Forgot Password", "SEND PASSWORD RESSET E-MAIL");
        }
    }
}
