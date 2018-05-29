using System;
using System.Collections.Generic;
using SampleCustomNavigation.CustomRenderers;
using Xamarin.Forms;

namespace SampleCustomNavigation
{
    public partial class MyPage : ContentPage
    {
        public MyPage()
        {
            InitializeComponent();

            ((CustomNavigationPage)Application.Current.MainPage).IsSearchEnabled = true;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();


        }
    }
}
