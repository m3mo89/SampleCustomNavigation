using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SampleCustomNavigation.CustomRenderers;
using SampleCustomNavigation.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleCustomNavigation.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyPage : BasePage
    {
        private MyPageViewModel _viewModel { get; set; }

        public MyPage()
        {
            InitializeComponent();

            _viewModel = new MyPageViewModel();
            BindingContext = _viewModel;

            RequestItems();
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
