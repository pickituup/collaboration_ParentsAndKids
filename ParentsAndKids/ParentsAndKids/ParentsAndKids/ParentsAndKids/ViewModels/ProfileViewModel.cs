using ParentsAndKids.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParentsAndKids.ViewModels {
    public sealed class ProfileViewModel : ViewModelBase {

        string _profile="profile";
        public string Profile {
            get { return _profile; }
            set { _profile = value;
                RaisePropertyChanged(() => Profile);
            }
        }

        /// <summary>
        ///     ctor().
        /// </summary>
        public ProfileViewModel() {
                
        }

        public override Task InitializeAsync(object navigationData) {


            return base.InitializeAsync(navigationData);
        }
    }
}
