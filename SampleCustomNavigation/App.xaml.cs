using System;
using SampleCustomNavigation.CustomRenderers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace SampleCustomNavigation
{
    public partial class App : Application
    {
        public static INavigation AppNavigation { get; internal set; }

        public App()
        {
            InitializeComponent();

            var navigationPage = new CustomNavigationPage(new MainPage())
            {
                BarBackgroundColor = Color.Red,
                IsSearchEnabled = true
            };

            AppNavigation = navigationPage.Navigation;

            Application.Current.MainPage = navigationPage;
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
