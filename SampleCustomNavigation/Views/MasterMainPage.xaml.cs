using System;
using System.Collections.Generic;
using SampleCustomNavigation.CustomRenderers;
using SampleCustomNavigation.Data;
using Xamarin.Forms;

namespace SampleCustomNavigation.Views
{
    public partial class MasterMainPage : MasterDetailPage
    {
        public MasterMainPage()
        {
            InitializeComponent();

            masterPage.ListView.ItemSelected += OnItemSelected;
        }

        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MasterPageItem;
            if (item != null)
            {
                Detail = new CustomNavigationPage((Page)Activator.CreateInstance(item.TargetType))
                {
                    BarBackgroundColor = Color.Red
                };
                masterPage.ListView.SelectedItem = null;
                IsPresented = false;
            }
        }
    }
}
