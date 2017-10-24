using ParentsAndKids.Views.CompoundedViews.ActionBars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ParentsAndKids.Views {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public abstract partial class BaseCommonPage : ContentPage {

        public static readonly BindableProperty ActionBarProperty =
            BindableProperty.Create("ActionBar",
                typeof(ActionBarBase),
                typeof(BaseCommonPage),
                propertyChanged: OnActionBarPropertyChanged);

        public static readonly BindableProperty MainContentProperty =
            BindableProperty.Create("MainContent",
                typeof(View),
                typeof(BaseCommonPage),
                propertyChanged: OnMainContentPropertyChanged);

        /// <summary>
        /// Public ctor
        /// </summary>
		public BaseCommonPage() {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        public ActionBarBase ActionBar {
            get => (ActionBarBase)GetValue(ActionBarProperty);
            set => SetValue(ActionBarProperty, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public View MainContent {
            get => (View)GetValue(MainContentProperty);
            set => SetValue(MainContentProperty, value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bindable"></param>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        private static void OnActionBarPropertyChanged(BindableObject bindable, object oldValue, object newValue) {
            BaseCommonPage basePage = bindable as BaseCommonPage;

            if (basePage != null) {
                basePage.AttachActionBar();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bindable"></param>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        private static void OnMainContentPropertyChanged(BindableObject bindable, object oldValue, object newValue) {
            BaseCommonPage basePage = bindable as BaseCommonPage;

            if (basePage != null) {
                basePage.AttachMainContent();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void AttachActionBar() =>
            _actionBarSpot_ContentView.Content = ActionBar;

        /// <summary>
        /// 
        /// </summary>
        private void AttachMainContent() =>
            _mainContentSpot_ContentView.Content = MainContent;
    }
}