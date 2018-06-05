using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using SampleCustomNavigation.Data;
using Xamarin.Forms;

namespace SampleCustomNavigation.ViewModel
{
    public class MyPageViewModel : BaseViewModel
    {
        private Command _searchCommand;
        private Item _selectedItem;
        private ObservableCollection<Item> _ItemList;
        private ObservableCollection<Item> _itemListSource;
        private string _searchText;

        public MyPageViewModel()
        {
            IsSearchEnabled = true;
            SearchPlaceHolder = "Search My Page";
            SearchExpandedBackground = Color.Green;
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

        public async Task<bool> FillListViewtemsAsync()
        {
            bool resp = false;

            if (ItemList == null)
            {
                ItemList = new ObservableCollection<Item>();
                _itemListSource = new ObservableCollection<Item>();
            }

            List<Item> listItems = new List<Item>();

            listItems.Add(new Item() { Title = "My Page 1", Description = "My Page 1" });
            listItems.Add(new Item() { Title = "My Page 2", Description = "My Page 2" });
            listItems.Add(new Item() { Title = "My Page 3", Description = "My Page 3" });
            listItems.Add(new Item() { Title = "My Page 4", Description = "My Page 4" });
            listItems.Add(new Item() { Title = "My Page 5", Description = "My Page 5" });
            listItems.Add(new Item() { Title = "My Page 6", Description = "My Page 6" });
            listItems.Add(new Item() { Title = "My Page 7", Description = "My Page 7" });
            listItems.Add(new Item() { Title = "My Page 8", Description = "My Page 8" });
            listItems.Add(new Item() { Title = "My Page 9", Description = "My Page 9" });
            listItems.Add(new Item() { Title = "My Page 10", Description = "My Page 10" });
            listItems.Add(new Item() { Title = "My Page 11", Description = "My Page 11" });
            listItems.Add(new Item() { Title = "My Page 12", Description = "My Page 12" });


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
    }
}
