using System;
using System.Collections.Generic;
using SampleCustomNavigation.CustomRenderers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleCustomNavigation
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyPage : ContentPage
    {
        public MyPage()
        {
            InitializeComponent();

            //((CustomNavigationPage)Application.Current.MainPage).IsSearchEnabled = true;
        }
    }
}
