using System;
using System.Collections.Generic;
using SampleCustomNavigation.CustomRenderers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleCustomNavigation.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyPage : BasePage
    {
        public MyPage()
        {
            InitializeComponent();
        }
    }
}
