using ParentsAndKids.Services.Dialog;
using ParentsAndKids.Services.Navigation;
using System.Threading.Tasks;

namespace ParentsAndKids.ViewModels.Base {
    public abstract class ViewModelBase : ExtendedBindableObject {
        protected readonly IDialogService DialogService;
        protected readonly INavigationService NavigationService;

        bool _isBusy;
        public bool IsBusy {
            get { return _isBusy; }
            set {
                _isBusy = value;
                RaisePropertyChanged(() => IsBusy);
            }
        }

        /// <summary>
        ///     ctor().
        /// </summary>
        public ViewModelBase() {
            DialogService = ViewModelLocator.Resolve<IDialogService>();
            NavigationService = ViewModelLocator.Resolve<INavigationService>();
            //GlobalSetting.Instance.BaseEndpoint = Settings.UrlBase;
        }

        public virtual Task InitializeAsync(object navigationData) {
            return Task.FromResult(false);
        }
    }
}
