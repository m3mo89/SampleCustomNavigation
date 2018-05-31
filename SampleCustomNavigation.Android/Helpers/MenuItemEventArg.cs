using System;
using Android.Views;

namespace SampleCustomNavigation.Droid.Helpers
{
    public class MenuItemEventArg : EventArgs
    {
        public IMenuItem MenuItem { get; set; }
        public bool Handled { get; set; }

        public MenuItemEventArg()
        {
            Handled = false;
        }
    }
}
