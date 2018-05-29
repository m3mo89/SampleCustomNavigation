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
        private SearchView _searchView;
        private bool _disposed;
        private static readonly FieldInfo _toolbarFieldInfo;
        private CustomNavigationPage _customNavigationPage;

        public CustomNavigationPageRenderer(Context context):base(context)
        {

        }

        static CustomNavigationPageRenderer()
        {
            _toolbarFieldInfo = typeof(NavigationPageRenderer).GetField("_toolbar", BindingFlags.NonPublic | BindingFlags.Instance);
        }

        protected override void OnElementChanged(ElementChangedEventArgs<NavigationPage> e)
        {
            base.OnElementChanged(e);

            if (e?.NewElement == null || e.OldElement != null)
            {
                return;
            }

            _customNavigationPage = (CustomNavigationPage) e.NewElement;

            SetSearch();

            //Element.Appearing += OnAppearing;
            //Element.Disappearing += OnDisappearing;
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if(e.PropertyName == CustomNavigationPage.CurrentPageProperty.PropertyName)
            {
                SetSearch();
            }
        }

        public override void OnViewAdded(Android.Views.View child)
        {
            base.OnViewAdded(child);

            if (child.GetType() == typeof(Toolbar))
            {
                _toolbar = (Toolbar)child;
                if (MainActivity.ToolBar == null)
                {
                    MainActivity.ToolBar = _toolbar;
                    MainActivity.ToolBar.SetBackgroundColor(Element.BarBackgroundColor.ToAndroid());
                }
            }
        }

        public void SetSearch()
        {
            if (_customNavigationPage.IsSearchEnabled)
            {
                //if (MainActivity.ToolBar.Menu?.FindItem(Resource.Id.action_search) != null) // if we are coming from the background, don't add another search view
                //{
                //    return;
                //}

                Device.BeginInvokeOnMainThread(async () =>
                {
                    await Task.Delay(TimeSpan.FromMilliseconds(400));

                    AddSearchToToolBar();
                });
            }
        }

        private void AddSearchToToolBar()
        {

            if (MainActivity.ToolBar == null || Element == null)
            {
                return;
            }

            MainActivity.ToolBar.Title = Element.Title;
            MainActivity.ToolBar.InflateMenu(Resource.Menu.mainmenu);

            _searchView = MainActivity.ToolBar.Menu?.FindItem(Resource.Id.action_search)?.ActionView?.JavaCast<SearchView>();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && !_disposed)
            {
                _disposed = true;
            }

            //if (Element != null)
            //{
            //    Element.Appearing -= OnAppearing;
            //    //Element.Disappearing -= OnDisappearing;
            //}

            base.Dispose(disposing);
        }
    }
}
