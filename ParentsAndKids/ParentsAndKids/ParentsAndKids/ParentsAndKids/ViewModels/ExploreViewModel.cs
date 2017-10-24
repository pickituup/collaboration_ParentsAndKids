using ParentsAndKids.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParentsAndKids.ViewModels {
    public sealed class ExploreViewModel : ViewModelBase {

        string _name = "explore";
        public string Name {
            get { return _name; }
            set { _name = value;
                RaisePropertyChanged(() => Name);
            }
        }


        /// <summary>
        ///     ctor().
        /// </summary>
        public ExploreViewModel() {

        }
    }
}
