using ParentsAndKids.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ParentsAndKids.ViewModels {
    public sealed class WelcomeViewModel : ViewModelBase {

        public ICommand NavigateToLoginViewCommand => new Command(async () => await NavigateToLoginViewAsync());

        public ICommand NavigateToSignUpViewCommand => new Command(async () => await NavigateToSignUpViewAsync());

        public ICommand NavigateToMainViewCommand => new Command(async () => await NavigateToMainViewAsync());

        public ICommand FaceBookLoginCommand => new Command(async () => await FaceBookLoginAsync());

        /// <summary>
        ///     ctor().
        /// </summary>
        public WelcomeViewModel() {

        }

        private Task FaceBookLoginAsync() {
            throw new NotImplementedException();
        }

        private async Task NavigateToLoginViewAsync() {
            await NavigationService.NavigateToAsync<LoginViewModel>();
        }

        private async Task NavigateToSignUpViewAsync() {
            await NavigationService.NavigateToAsync<SignUpViewModel>();
        }

        private async Task NavigateToMainViewAsync() {
            await NavigationService.NavigateToAsync<MainViewModel>();
            await NavigationService.RemoveBackStackAsync();
        }
    }
}
