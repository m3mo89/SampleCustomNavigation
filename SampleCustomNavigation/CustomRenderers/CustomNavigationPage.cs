using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace SampleCustomNavigation.CustomRenderers
{
	public class CustomNavigationPage : NavigationPage
    {
        public static readonly BindableProperty IsSearchEnabledProperty = BindableProperty.Create(nameof(IsSearchEnabled), typeof(bool), typeof(CustomNavigationPage), false);
        public static readonly BindableProperty SearchPlaceHolderTextProperty = BindableProperty.Create(nameof(SearchPlaceHolderText), typeof(string), typeof(CustomNavigationPage), string.Empty);
        public static readonly BindableProperty SearchTextProperty = BindableProperty.Create(nameof(SearchText), typeof(string), typeof(CustomNavigationPage), string.Empty);
        public static readonly BindableProperty SearchCommandProperty = BindableProperty.Create(nameof(SearchCommand), typeof(ICommand), typeof(CustomNavigationPage));
        public static readonly BindableProperty SearchBackgroundColorProperty = BindableProperty.Create(nameof(SearchBackgroundColor), typeof(Color), typeof(CustomNavigationPage), Color.Default);

        public CustomNavigationPage(Page page) : base(page)
        {
        }

        public bool IsSearchEnabled
        {
            get
            {
                return (bool)GetValue(IsSearchEnabledProperty);
            }
            set
            {
                SetValue(IsSearchEnabledProperty, value);
            }
        }

        public string SearchPlaceHolderText
        {
            get
            {
                return (string)GetValue(SearchPlaceHolderTextProperty);
            }
            set
            {
                SetValue(SearchPlaceHolderTextProperty, value);
            }
        }

        public string SearchText
        {
            get
            {
                return (string)GetValue(SearchTextProperty);
            }
            set
            {
                SetValue(SearchTextProperty, value);
            }
        }

        public ICommand SearchCommand
        {
            get
            {
                return (ICommand)GetValue(SearchCommandProperty);
            }
            set
            {
                SetValue(SearchCommandProperty, value);
            }
        }

        public Color SearchBackgroundColor
        {
            get
            {
                return (Color)GetValue(SearchBackgroundColorProperty);
            }
            set
            {
                SetValue(SearchBackgroundColorProperty, value);
            }
        }
    }
}
