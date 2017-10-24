using ParentsAndKids.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParentsAndKids.ViewModels {
    public sealed class TopViewModel : ViewModelBase {

        string _top = "top";
        public string Top {
            get { return _top; }
            set { _top = value;
                RaisePropertyChanged(() => Top);
            }
        }

        /// <summary>
        ///     ctor().
        /// </summary>
        public TopViewModel() {

        }
    }
}
