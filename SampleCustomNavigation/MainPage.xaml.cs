using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleCustomNavigation.CustomRenderers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleCustomNavigation
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : BasePage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        //protected override void OnAppearing()
        //{
        //    base.OnAppearing();

        //    //((CustomNavigationPage)Application.Current.MainPage).IsSearchEnabled = true;
        //}

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new MyPage());
        }
    }
}
