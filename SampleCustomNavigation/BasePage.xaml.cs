using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleCustomNavigation
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BasePage : ContentPage
    {
        public static readonly BindableProperty IsSearchEnabledProperty = BindableProperty.Create(nameof(IsSearchEnabled), typeof(bool), typeof(BasePage), false);
        public static readonly BindableProperty SearchPlaceHolderTextProperty = BindableProperty.Create(nameof(SearchPlaceHolderText), typeof(string), typeof(BasePage), string.Empty);
        public static readonly BindableProperty SearchTextProperty = BindableProperty.Create(nameof(SearchText), typeof(string), typeof(BasePage), string.Empty);
        public static readonly BindableProperty SearchCommandProperty = BindableProperty.Create(nameof(SearchCommand), typeof(ICommand), typeof(BasePage));
        public static readonly BindableProperty SearchExpandedBackgroundColorProperty = BindableProperty.Create(nameof(SearchExpandedBackgroundColor), typeof(Color), typeof(BasePage), Color.Default, BindingMode.TwoWay);

        public BasePage()
        {
            InitializeComponent();
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

        public Color SearchExpandedBackgroundColor
        {
            get
            {
                return (Color)GetValue(SearchExpandedBackgroundColorProperty);
            }
            set
            {
                SetValue(SearchExpandedBackgroundColorProperty, value);
            }
        }
    }
}
