using System;
using Android.Views;

namespace SampleCustomNavigation.Droid.Helpers
{
    public class MenuActionExpandListener : Java.Lang.Object, Android.Support.V4.View.MenuItemCompat.IOnActionExpandListener
    {
        public delegate void MenuItemEventHandler(object sender, MenuItemEventArg e);

        public event MenuItemEventHandler MenuItemCollaspe;
        public event MenuItemEventHandler MenuItemActionExpand;

        public bool OnMenuItemActionCollapse(IMenuItem item)
        {
            if (MenuItemCollaspe != null)
            {
                MenuItemEventArg e = new MenuItemEventArg();
                e.MenuItem = item;
                e.Handled = true;
                MenuItemCollaspe(this, e);
                return e.Handled;
            }
            return true;
        }

        public bool OnMenuItemActionExpand(IMenuItem item)
        {
            if (MenuItemActionExpand != null)
            {
                MenuItemEventArg e = new MenuItemEventArg();
                e.MenuItem = item;
                e.Handled = true;
                MenuItemActionExpand(this, e);
                return e.Handled;
            }
            return true;
        }
    }
}
