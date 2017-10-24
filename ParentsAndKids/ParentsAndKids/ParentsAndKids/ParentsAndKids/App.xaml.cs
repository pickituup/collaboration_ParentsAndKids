using ParentsAndKids.Helpers;
using ParentsAndKids.Services.Navigation;
using ParentsAndKids.ViewModels.Base;
using ParentsAndKids.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ParentsAndKids {
    public partial class App : Application {

        public bool UseMockServices { get; set; }

        /// <summary>
        ///     ctor().
        /// </summary>
        public App() {
            InitializeComponent();

            InitApp();
        }

        private void InitApp() {
            UseMockServices = Settings.UseMocks;
            ViewModelLocator.RegisterDependencies(UseMockServices);
        }

        private Task InitNavigation() {
            var navigationService = ViewModelLocator.Resolve<INavigationService>();
            return navigationService.InitializeAsync();
        }

        protected override async void OnStart() {
            base.OnStart();

            await InitNavigation();

            //if (Settings.AllowGpsLocation && !Settings.UseFakeLocation) {
            //    await GetGpsLocation();
            //}

            //if (!Settings.UseMocks && !string.IsNullOrEmpty(Settings.AuthAccessToken)) {
            //    await SendCurrentLocation();
            //}

            base.OnResume();
        }

        protected override void OnSleep() {
            // Handle when your app sleeps
        }
    }
}
