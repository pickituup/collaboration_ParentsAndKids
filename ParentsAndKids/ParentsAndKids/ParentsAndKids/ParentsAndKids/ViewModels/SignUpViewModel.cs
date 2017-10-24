using ParentsAndKids.Services.OpenUrl;
using ParentsAndKids.ViewModels.Base;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ParentsAndKids.ViewModels {
    public sealed class SignUpViewModel : BaseCommonPageViewModel {

        private static readonly string _SIGN_UP_HEADER = "Create an account";

        private IOpenUrlService _openUrlService;

        public ICommand SignUpCommand => new Command(async () => await SignUpAsync());

        public ICommand CreateAccountCommand => new Command(async () => await CreateAccountAsync());

        /// <summary>
        ///     ctor().
        /// </summary>
        public SignUpViewModel(IOpenUrlService openUrlService) {
            _openUrlService = openUrlService;

            ActionBarHeader = _SIGN_UP_HEADER;

            BackCommand = new Command(async () => {
                await NavigationService.GoBackAsync();
            });
        }

        private async Task CreateAccountAsync() {
            
        }

        private async Task SignUpAsync() {
            IsBusy = true;
            await NavigationService.NavigateToAsync<MainViewModel>();
            await NavigationService.RemoveBackStackAsync();
            IsBusy = false;
        }
    }
}
