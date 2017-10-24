using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace ParentsAndKids.Views.CompoundedViews.ActionBars
{
    public abstract class ActionBarBase : ContentView {

        /// <summary>
        /// 
        /// </summary>
        public ActionBarBase() {
            if (Device.RuntimePlatform == Device.iOS) {
                Padding = new Thickness(0, 20, 0, 0);
            }
        }
    }
}