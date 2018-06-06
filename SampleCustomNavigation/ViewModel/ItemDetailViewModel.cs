using System;
using SampleCustomNavigation.Data;

namespace SampleCustomNavigation.ViewModel
{
    public class ItemDetailViewModel: BaseViewModel
    {
        private string _title = string.Empty;
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                if (_title != value)
                {
                    _title = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _description = string.Empty;
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                if (_description != value)
                {
                    _description = value;
                    OnPropertyChanged();
                }
            }
        }

        public ItemDetailViewModel(Item item)
        {
            Description = item.Description;
            Title = item.Title;
        }
    }
}
