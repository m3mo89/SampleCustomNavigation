using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using SampleCustomNavigation.Data;
using SampleCustomNavigation.Views;
using Xamarin.Forms;

namespace SampleCustomNavigation.ViewModel
{
    public class MainPageViewModel:BaseViewModel
    {
        private Command _searchCommand;
        private Item _selectedItem;
        private ObservableCollection<Item> _ItemList;
        private ObservableCollection<Item> _itemListSource;
        private string _searchText; 

        public MainPageViewModel()
        {
            IsSearchEnabled = true;
            SearchPlaceHolder = "Search";
            SearchExpandedBackground = Color.Violet;
        }

        public string SearchText
        {
            get
            {
                return _searchText;
            }
            set
            {
                if (_searchText != value)
                {
                    _searchText = value;
                    OnPropertyChanged(nameof(SearchText));
                    ExecuteSearchCommand();
                }
            }
        }

        public ObservableCollection<Item> ItemList
        {
            get
            {
                return _ItemList;
            }
            set
            {
                if (_ItemList != value)
                {
                    _ItemList = value;
                    OnPropertyChanged();
                }
            }
        }

        public Item SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                if (_selectedItem != value)
                {
                    _selectedItem = value;
                    OnPropertyChanged();
                }

                if (_selectedItem == null)
                {
                    return;
                }

                SendToDetails(_selectedItem);
            }
        }

        public async Task<bool> FillListViewtemsAsync()
        {
            bool resp = false;

            if (ItemList == null)
            {
                ItemList = new ObservableCollection<Item>();
                _itemListSource = new ObservableCollection<Item>();
            }

            List<Item> listItems = new List<Item>();

            listItems.Add(new Item() { Title = "Main Page 1", Description = "Main Page 1" });
            listItems.Add(new Item() { Title = "Main Page 2", Description = "Main Page 2" });
            listItems.Add(new Item() { Title = "Main Page 3", Description = "Main Page 3" });
            listItems.Add(new Item() { Title = "Main Page 4", Description = "Main Page 4" });
            listItems.Add(new Item() { Title = "Main Page 5", Description = "Main Page 5" });
            listItems.Add(new Item() { Title = "Main Page 6", Description = "Main Page 6" });
            listItems.Add(new Item() { Title = "Main Page 7", Description = "Main Page 7" });
            listItems.Add(new Item() { Title = "Main Page 8", Description = "Main Page 8" });
            listItems.Add(new Item() { Title = "Main Page 9", Description = "Main Page 9" });
            listItems.Add(new Item() { Title = "Main Page 10", Description = "Main Page 10" });
            listItems.Add(new Item() { Title = "Main Page 11", Description = "Main Page 11" });
            listItems.Add(new Item() { Title = "Main Page 12", Description = "Main Page 12" });


            if (listItems != null)
            {
                if (listItems.Count > 0)
                {
                    ItemList.Clear();
                    _itemListSource.Clear();

                    resp = true;

                    foreach (Item item in listItems)
                    {
                        ItemList.Add(item);
                        _itemListSource.Add(item);
                    }
                }
            }

            return resp;
        }

        public Command OnSearchCommand
        {
            get
            {
                return _searchCommand ?? (_searchCommand = new Command(async () => await ExecuteSearchCommand()));
            }
        }

        private async Task ExecuteSearchCommand()
        {
            if (SearchText?.Length <= 0)
            {
                await FillListViewtemsAsync();
                return;
            }

            if (SearchText?.Length < 3)
            {
                return;
            }

            var lst = _itemListSource.Where(c => c.Description.ToLower().Contains(SearchText.ToLower()));

            ItemList.Clear();

            if (lst?.ToList().Count > 0)
            {
                foreach (Item item in lst)
                {
                    ItemList.Add(item);
                }
            }
        }

        public void SendToDetails(Item item)
        {
            Application.Current.MainPage.Navigation.PushAsync(new ItemDetailPage(item));
        }
    }
}
