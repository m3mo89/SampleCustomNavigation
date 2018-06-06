using System;
using System.Collections.Generic;
using SampleCustomNavigation.Data;
using SampleCustomNavigation.ViewModel;
using Xamarin.Forms;

namespace SampleCustomNavigation.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage(Item item)
        {
            InitializeComponent();

            BindingContext = new ItemDetailViewModel(item);
        }
    }
}
