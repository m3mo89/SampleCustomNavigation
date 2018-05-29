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

//[assembly: ExportRenderer(typeof(MainPage), typeof(MainPageRenderer))]
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
            Element.Disappearing += OnDisappearing;
        }

        public void OnAppearing(object sender, EventArgs e)
        {
            if (MainActivity.ToolBar.Menu?.FindItem(Resource.Id.action_search) != null) // if we are coming from the background, don't add another search view
            {
                return;
            }

            Device.BeginInvokeOnMainThread(async () =>
            {
                await Task.Delay(TimeSpan.FromMilliseconds(600));

                AddSearchToToolBar();
            });
        }

        public void OnDisappearing(object sender, EventArgs e)
        {
            RemoveSearchFromToolbar();
        }

        private void RemoveSearchFromToolbar()
        {
            MainActivity.ToolBar?.Menu?.RemoveItem(Resource.Menu.mainmenu);
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
                Element.Appearing -= OnAppearing;
                Element.Disappearing -= OnDisappearing;
            }

            RemoveSearchFromToolbar();
            base.Dispose(disposing);
        }

    }
}
