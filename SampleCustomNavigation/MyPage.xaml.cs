using System;
using System.Collections.Generic;
using SampleCustomNavigation.CustomRenderers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleCustomNavigation
{
    public partial class MyPage : ContentPage
    [XamlCompilation(XamlCompilationOptions.Compile)]
    {
        public MyPage()
        {
            InitializeComponent();

            //((CustomNavigationPage)Application.Current.MainPage).IsSearchEnabled = true;
        }
    }
}
