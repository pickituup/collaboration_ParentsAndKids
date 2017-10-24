using ParentsAndKids.ViewModels;
using ParentsAndKids.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ParentsAndKids.Views {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainView : TabbedPage {

        /// <summary>
        ///     ctor().
        /// </summary>
        public MainView() {
            InitializeComponent();
        }

        protected override async void OnAppearing() {
            base.OnAppearing();

            MessagingCenter.Subscribe<MainViewModel, int>(this, MessageKeys.CHANGE_TAB, (sender, arg) => {
                switch (arg) {
                    case 0:
                        CurrentPage = TopView;
                        break;
                    case 1:
                        CurrentPage = ExploreView;
                        break;
                    case 2:
                        CurrentPage = InboxView;
                        break;
                    case 3:
                        CurrentPage = ProfileView;
                        break;
                }
            });

            await ((TopViewModel)TopView.BindingContext).InitializeAsync(null);
            await ((ExploreViewModel)ExploreView.BindingContext).InitializeAsync(null);
            await ((InboxViewModel)InboxView.BindingContext).InitializeAsync(null);
            await ((ProfileViewModel)ProfileView.BindingContext).InitializeAsync(null);
        }

        protected override async void OnCurrentPageChanged() {
            base.OnCurrentPageChanged();

            if (CurrentPage is ExploreView) {
                // Force explore view refresh every time we access it
                await (ExploreView.BindingContext as ViewModelBase).InitializeAsync(null);
            } else if (CurrentPage is InboxView) {
                // Force inbox view refresh every time we access it
                await (InboxView.BindingContext as ViewModelBase).InitializeAsync(null);
            } else if (CurrentPage is ProfileView) {
                // Force profile view refresh every time we access it
                await (ProfileView.BindingContext as ViewModelBase).InitializeAsync(null);
            }
        }

        protected override void OnDisappearing() {
            base.OnDisappearing();
        }
    }
}