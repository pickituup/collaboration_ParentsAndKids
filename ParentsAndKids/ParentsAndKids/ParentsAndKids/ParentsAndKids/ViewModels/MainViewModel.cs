using ParentsAndKids.Models.Navigation;
using ParentsAndKids.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ParentsAndKids.ViewModels {
    public sealed class MainViewModel : ViewModelBase {

        /// <summary>
        ///     ctor().
        /// </summary>
        public MainViewModel() {

        }

        public override Task InitializeAsync(object navigationData) {
            IsBusy = true;

            if (navigationData is TabParameter) {
                // Change selected application tab
                var tabIndex = ((TabParameter)navigationData).TabIndex;
                MessagingCenter.Send(this, MessageKeys.CHANGE_TAB, tabIndex);
            }

            return base.InitializeAsync(navigationData);
        }
    }
}
