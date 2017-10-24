﻿using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ParentsAndKids.Views {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomNavigationView : NavigationPage {
        public CustomNavigationView() {
            InitializeComponent();
        }

        public CustomNavigationView(Page root):base(root) {
            InitializeComponent();
        }
    }
}