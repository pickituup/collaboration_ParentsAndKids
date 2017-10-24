using ParentsAndKids.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ParentsAndKids.ViewModels {
    public abstract class BaseCommonPageViewModel : ViewModelBase {

        private string _actionBarHeader;

        /// <summary>
        /// 
        /// </summary>
        public ICommand BackCommand { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        public string ActionBarHeader {
            get => _actionBarHeader;
            protected set {
                _actionBarHeader = value;
                RaisePropertyChanged(() => ActionBarHeader);
            }
        }
    }
}
