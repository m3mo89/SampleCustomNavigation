using System;
using SampleCustomNavigation.CustomRenderers;
using SampleCustomNavigation.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace SampleCustomNavigation
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //For Simple Content Page
            //var navigationPage = new CustomNavigationPage(new MainPage())
            //{
            //    BarBackgroundColor = Color.Red
            //};
            //Application.Current.MainPage = navigationPage;

            //For Master Detail Page
            //Application.Current.MainPage = new MasterMainPage();

            //For Tabbed Page
            Application.Current.MainPage = new CustomNavigationPage(new TabbedMainPage())
            {
                BarBackgroundColor = Color.Red
            };
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
