using ParentsAndKids.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParentsAndKids.ViewModels {
    public sealed class InboxViewModel : ViewModelBase {

        string _inbox = "Inbox";
        public string Inbox {
            get { return _inbox; }
            set { _inbox = value;
                RaisePropertyChanged(() => Inbox);
            }
        }

        /// <summary>
        ///     ctor()
        /// </summary>
        public InboxViewModel() {

        }
    }
}
