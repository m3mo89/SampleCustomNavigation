using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Android.Content;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Text;
using Android.Views;
using Android.Views.InputMethods;
using Android.Widget;
using SampleCustomNavigation.Views;
using SampleCustomNavigation.Droid.Helpers;
using SampleCustomNavigation.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using SearchView = Android.Support.V7.Widget.SearchView;

[assembly: ExportRenderer(typeof(BasePage), typeof(BasePageRenderer))]
namespace SampleCustomNavigation.Droid.Renderers
{
    public class BasePageRenderer: PageRenderer
    {
        private SearchView _searchView;
        private AutoCompleteTextView _textView;
        private MenuActionExpandListener _menuActionExpandListener;
        private bool _isKeyboardOpen = false;
        private Android.Graphics.Color _originalToolbarBackground;
        private BasePage _basePage;


        public BasePageRenderer(Context context):base(context)
        {
        }


        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            base.OnElementChanged(e);

            if (e?.NewElement == null || e.OldElement != null)
            {
                return;
            }

            _basePage = (BasePage)e.NewElement;

            if (_basePage.IsSearchEnabled)
            {
                AddSearchToToolBar();

                Element.Appearing += OnAppearing;
                Element.Disappearing += OnDisappearing;
            }
        }

        public override void OnViewAdded(Android.Views.View child)
        {
            base.OnViewAdded(child);


            MainActivity.ToolBar.MenuItemClick += OnMenuItemClick;

            _originalToolbarBackground = ((Android.Graphics.Drawables.ColorDrawable)MainActivity.ToolBar.Background).Color;
        }

        protected override void Dispose(bool disposing)
        {
            if (_searchView != null)
            {
                _searchView.QueryTextChange -= OnQueryTextChange;
                _searchView.QueryTextSubmit -= OnQueryTextSubmit;
            }

            if (_textView != null)
            {
                _textView.FocusChange -= OnFocusChangeHandler;
                _textView.Click -= OnClickHandler;
            }

            if (_menuActionExpandListener != null)
            {
                _menuActionExpandListener.MenuItemCollaspe -= OnMenuItemCollaspe;
                _menuActionExpandListener.MenuItemActionExpand -= OnMenuItemActionExpand;
            }

            if (Element != null)
            {
                Element.Appearing -= OnAppearing;
                Element.Disappearing -= OnDisappearing;
            }

            RemoveSearchFromToolbar();
            base.Dispose(disposing);
        }

        public void OnAppearing(object sender, EventArgs e)
        {
            MainActivity.ToolBar.BringToFront();

            if (MainActivity.ToolBar.Menu?.FindItem(Resource.Id.action_search) != null) // if we are coming from the background, don't add another search view
            {
                return;
            }

            Device.BeginInvokeOnMainThread(async () =>
            {
                await Task.Delay(TimeSpan.FromMilliseconds(300));

                AddSearchToToolBar();
            });
        }

        public void OnDisappearing(object sender, EventArgs e)
        {
            RemoveSearchFromToolbar();
        }

        private void RemoveSearchFromToolbar()
        {
            if (MainActivity.ToolBar?.Handle != IntPtr.Zero)
            {
                MainActivity.ToolBar?.Menu?.RemoveItem(Resource.Id.action_search);
                MainActivity.ToolBar?.Menu?.RemoveItem(Resource.Menu.mainmenu);
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

            if (_searchView == null)
            {
                return;
            }

            _searchView.QueryTextChange += OnQueryTextChange;
            _searchView.QueryTextSubmit += OnQueryTextSubmit;
            _searchView.QueryHint = (Element as BasePage)?.SearchPlaceHolderText;
            _searchView.ImeOptions = (int)ImeAction.Search;
            _searchView.InputType = (int)InputTypes.TextVariationNormal;
            _searchView.MaxWidth = int.MaxValue;

            int textViewId = _searchView.Context.Resources.GetIdentifier("android:id/search_src_text", null, null);
            _textView = (_searchView.FindViewById(textViewId) as AutoCompleteTextView);

            if (_textView == null)
            {
                _textView = (_searchView.FindViewById(Resource.Id.search_src_text) as AutoCompleteTextView);
            }

            if (_textView != null)
            {
                SetCursorColor(_textView);
                _textView.Hint = (Element as BasePage)?.SearchPlaceHolderText;

                _textView.FocusChange += OnFocusChangeHandler;
                _textView.Click += OnClickHandler;
            }

            MainActivity.Instance.Window.SetSoftInputMode(SoftInput.AdjustNothing);
        }

        private void OnClickHandler(object sender, EventArgs e)
        {
            SampleCustomNavigation.Droid.Helpers.Helpers.ShowKeyboard(_textView, MainActivity.Instance);
            _isKeyboardOpen = true;
        }

        private void OnFocusChangeHandler(object sender, FocusChangeEventArgs e)
        {
            if (e.HasFocus)
            {
                SampleCustomNavigation.Droid.Helpers.Helpers.ShowKeyboard((sender as Android.Views.View).FindFocus() as EditText, MainActivity.Instance);
                _isKeyboardOpen = true;
            }
        }

        private void OnQueryTextSubmit(object sender, SearchView.QueryTextSubmitEventArgs e)
        {
            if (e == null)
            {
                return;
            }

            var searchPage = Element as BasePage;

            if (searchPage == null)
            {
                return;
            }

            searchPage.SearchText = e.Query;
            searchPage.SearchCommand?.Execute(e.Query);
            e.Handled = true;
        }

        private void OnQueryTextChange(object sender, SearchView.QueryTextChangeEventArgs e)
        {
            var searchPage = Element as BasePage;

            if (searchPage == null)
            {
                return;
            }

            searchPage.SearchText = e?.NewText;
        }

        private void SetCursorColor(AutoCompleteTextView autoCompleteTextView)
        {
            IntPtr textViewClass = JNIEnv.FindClass(typeof(AutoCompleteTextView));
            IntPtr cursorDrawableResProperty = JNIEnv.GetFieldID(textViewClass, "mCursorDrawableRes", "I");

            int cursorColorResource = Resource.Drawable.lightcursor;

            JNIEnv.SetField(autoCompleteTextView.Handle, cursorDrawableResProperty, cursorColorResource);
        }

        private void OnMenuItemClick(object sender, Android.Support.V7.Widget.Toolbar.MenuItemClickEventArgs e)
        {
            if (e == null || e.Item == null)
            {
                return;
            }

            switch (e.Item.ItemId)
            {
                case Resource.Id.action_search:

                    if (_menuActionExpandListener == null)
                    {
                        _menuActionExpandListener = new MenuActionExpandListener();
                    }

                    _menuActionExpandListener.MenuItemCollaspe += OnMenuItemCollaspe;
                    _menuActionExpandListener.MenuItemActionExpand += OnMenuItemActionExpand;

                    Android.Support.V4.View.MenuItemCompat.SetOnActionExpandListener(e.Item, _menuActionExpandListener);
                    break;
            }

            e.Handled = true;
        }

        private void OnMenuItemCollaspe(object sender, MenuItemEventArg e)
        {
            SetSearchbarBackgroundColor(_originalToolbarBackground);
        }

        private void OnMenuItemActionExpand(object sender, MenuItemEventArg e)
        {
            Android.Graphics.Color customColor = _originalToolbarBackground;
            BasePage searchPage = Element as BasePage;

            if (searchPage == null)
            {
                return;
            }

            if (searchPage.SearchExpandedBackgroundColor != Color.Default)
            {
                customColor = searchPage.SearchExpandedBackgroundColor.ToAndroid();
            }

            SetSearchbarBackgroundColor(customColor);
        }

        private void SetSearchbarBackgroundColor(Android.Graphics.Color color)
        {
            if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.Lollipop)
            {
                MainActivity.ToolBar.BackgroundTintMode = Android.Graphics.PorterDuff.Mode.Src;
                MainActivity.ToolBar.BackgroundTintList = Android.Content.Res.ColorStateList.ValueOf(color);
            }
            else
            {
                MainActivity.ToolBar.SetBackgroundColor(color);
            }
        }


    }
}
