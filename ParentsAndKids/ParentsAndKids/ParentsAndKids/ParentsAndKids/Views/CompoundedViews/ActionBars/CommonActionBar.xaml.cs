using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ParentsAndKids.Views.CompoundedViews.ActionBars {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CommonActionBar : ActionBarBase {
        public CommonActionBar() {
            InitializeComponent();
        }
    }
}