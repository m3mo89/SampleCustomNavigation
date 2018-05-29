using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleCustomNavigation.CustomRenderers;
using Xamarin.Forms;

namespace SampleCustomNavigation
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            ((CustomNavigationPage)Application.Current.MainPage).IsSearchEnabled = false;
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            Application.Current.MainPage.Navigation.PushAsync(new MyPage());
        }
    }
}
