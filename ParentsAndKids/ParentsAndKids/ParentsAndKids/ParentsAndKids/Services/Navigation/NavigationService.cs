using ParentsAndKids.Helpers;
using ParentsAndKids.ViewModels;
using ParentsAndKids.ViewModels.Base;
using ParentsAndKids.Views;
using System;
using System.Globalization;
using System.Reflection;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ParentsAndKids.Services.Navigation {
    public class NavigationService : INavigationService {

        /// <summary>
        ///     Returns the view model type associated with the previous page in the navigation stack.
        /// </summary>
        public ViewModelBase PreviousPageViewModel {
            get {
                var mainPage = Application.Current.MainPage as CustomNavigationView;
                var viewModel = mainPage.Navigation.NavigationStack[mainPage.Navigation.NavigationStack.Count - 2].BindingContext;
                return viewModel as ViewModelBase;
            }
        }

        /// <summary>
        ///     Performs navigation to one of two pages when the app is launched.
        /// </summary>
        /// <returns></returns>
        public Task InitializeAsync() {
            if (string.IsNullOrEmpty(Settings.AuthAccessToken))
                return NavigateToAsync<WelcomeViewModel>();
            else
                return NavigateToAsync<MainViewModel>();
        }

        /// <summary>
        ///     Performs hierarchical navigation to a specified page.
        /// </summary>
        /// <typeparam name="TViewModel"></typeparam>
        /// <returns></returns>
        public Task NavigateToAsync<TViewModel>() where TViewModel : ViewModelBase {
            return InternalNavigateToAsync(typeof(TViewModel), null);
        }

        /// <summary>
        ///     Performs hierarchical navigation to a specified page, passing a parameter.
        /// </summary>
        /// <typeparam name="TViewModel"></typeparam>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : ViewModelBase {
            return InternalNavigateToAsync(typeof(TViewModel), parameter);
        }

        /// <summary>
        ///     Removes the previous page from the navigation stack.
        /// </summary>
        /// <returns></returns>
        public Task RemoveLastFromBackStackAsync() {
            var mainPage = Application.Current.MainPage as CustomNavigationView;

            if (mainPage != null) {
                mainPage.Navigation.RemovePage(
                    mainPage.Navigation.NavigationStack[mainPage.Navigation.NavigationStack.Count - 2]);
            }

            return Task.FromResult(true);
        }

        /// <summary>
        ///     Removes all the previous pages from the navigation stack.
        /// </summary>
        /// <returns></returns>
        public Task RemoveBackStackAsync() {
            var mainPage = Application.Current.MainPage as CustomNavigationView;

            if (mainPage != null) {
                int navigationStackCount = mainPage.Navigation.NavigationStack.Count;
                for (int i = 0; i < navigationStackCount - 1; i++) {
                    var page = mainPage.Navigation.NavigationStack[0];
                    mainPage.Navigation.RemovePage(page);
                }
            }

            return Task.FromResult(true);
        }

        /// <summary>
        ///     Navigate back.
        /// </summary>
        /// <returns></returns>
        public async Task GoBackAsync() {
            var mainPage = Application.Current.MainPage as CustomNavigationView;
            await mainPage.PopAsync();
        }

        private async Task InternalNavigateToAsync(Type viewModelType, object parameter) {
            Page page = CreatePage(viewModelType, parameter);

            if (page is WelcomeView) {
                Application.Current.MainPage = new CustomNavigationView(page);
            } else {
                var navigationPage = Application.Current.MainPage as CustomNavigationView;
                if (navigationPage != null) {
                    await navigationPage.PushAsync(page);
                } else {
                    Application.Current.MainPage = new CustomNavigationView(page);
                }
            }

            await (page.BindingContext as ViewModelBase).InitializeAsync(parameter);
        }

        private Type GetPageTypeForViewModel(Type viewModelType) {
            var viewName = viewModelType.FullName.Replace("Model", string.Empty);
            var viewModelAssemblyName = viewModelType.GetTypeInfo().Assembly.FullName;
            var viewAssemblyName = string.Format(CultureInfo.InvariantCulture, "{0}, {1}", viewName, viewModelAssemblyName);
            var viewType = Type.GetType(viewAssemblyName);
            return viewType;
        }

        private Page CreatePage(Type viewModelType, object parameter) {
            Type pageType = GetPageTypeForViewModel(viewModelType);
            if (pageType == null) {
                throw new Exception($"Cannot locate page type for {viewModelType}");
            }

            Page page = Activator.CreateInstance(pageType) as Page;
            return page;
        }
    }
}
