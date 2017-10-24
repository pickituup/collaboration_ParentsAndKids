using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using ParentsAndKids.iOS.Renderers;

[assembly: ExportRenderer(typeof(TabbedPage), typeof(CustomTabbedPageRenderer))]
namespace ParentsAndKids.iOS.Renderers {
    public class CustomTabbedPageRenderer : TabbedRenderer {

        protected override void OnElementChanged(VisualElementChangedEventArgs e) {
            base.OnElementChanged(e);
            TabBar.TintColor = UIColor.FromRGB(46, 200, 190);
            TabBar.BarTintColor = UIColor.White;
            TabBar.BackgroundColor = UIColor.FromRGB(186,186,186);
        }
    }
}