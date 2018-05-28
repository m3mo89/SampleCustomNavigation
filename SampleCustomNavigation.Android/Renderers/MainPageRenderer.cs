using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Android.Content;
using Android.Runtime;
using Android.Support.V7.Widget;
using SampleCustomNavigation;
using SampleCustomNavigation.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(MainPage), typeof(MainPageRenderer))]
namespace SampleCustomNavigation.Droid.Renderers
{
    public class MainPageRenderer: PageRenderer
    {
        private SearchView _searchView;

        public MainPageRenderer(Context context):base(context)
        {
        }


        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            base.OnElementChanged(e);

            if (e?.NewElement == null || e.OldElement != null)
            {
                return;
            }

            AddSearchToToolBar();

            Element.Appearing += OnAppearing;
        }


        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == nameof(NavigationPage.CurrentPage))
            {
            //    AddSearchToToolBar();
                Element.Appearing += OnAppearing;
            }
        }

        public void OnAppearing(object sender, EventArgs e)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                await Task.Delay(TimeSpan.FromMilliseconds(600));

                AddSearchToToolBar();
            });
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
            if (Element != null)
            {
                Element.Disappearing -= OnAppearing;
            }

            MainActivity.ToolBar?.Menu?.RemoveItem(Resource.Menu.mainmenu);
            base.Dispose(disposing);
        }

    }
}
