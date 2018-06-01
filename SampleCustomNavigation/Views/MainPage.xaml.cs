using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleCustomNavigation.CustomRenderers;
using SampleCustomNavigation.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleCustomNavigation.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : BasePage
    {
        private MainPageViewModel _viewModel { get; set; }

        public MainPage()
        {
            InitializeComponent();

            _viewModel = new MainPageViewModel();
            BindingContext = _viewModel;

            RequestItems();
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new MyPage());
        }

        private void RequestItems()
        {
            Task.Run(async delegate
            {
                await _viewModel.FillListViewtemsAsync();
            });
        }
    }
}
