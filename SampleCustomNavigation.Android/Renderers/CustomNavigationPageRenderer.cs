using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Support.V7.Widget;
using Android.Views;
using SampleCustomNavigation.CustomRenderers;
using SampleCustomNavigation.Droid.CustomRenderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.Platform.Android.AppCompat;

[assembly: ExportRenderer(typeof(CustomNavigationPage), typeof(CustomNavigationPageRenderer))]
namespace SampleCustomNavigation.Droid.CustomRenderers
{
	public class CustomNavigationPageRenderer : NavigationPageRenderer 
    {
        private Toolbar _toolbar;
        private bool _disposed;
        private static readonly FieldInfo _toolbarFieldInfo;

        public CustomNavigationPageRenderer(Context context):base(context)
        {

        }

        static CustomNavigationPageRenderer()
        {
            _toolbarFieldInfo = typeof(NavigationPageRenderer).GetField("_toolbar", BindingFlags.NonPublic | BindingFlags.Instance);
        }

        public override void OnViewAdded(Android.Views.View child)
        {
            base.OnViewAdded(child);

            if (child.GetType() == typeof(Toolbar))
            {
                _toolbar = (Toolbar)child;

                //if the toolbar is not null and the handle is zero then update the toolbar
                if (MainActivity.ToolBar == null || MainActivity.ToolBar?.Handle == IntPtr.Zero)
                {
                    MainActivity.ToolBar = _toolbar;
                    MainActivity.ToolBar.SetBackgroundColor(Element.BarBackgroundColor.ToAndroid());
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && !_disposed)
            {
                _disposed = true;
            }

            base.Dispose(disposing);
        }
    }
}
