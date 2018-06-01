﻿using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace SampleCustomNavigation.ViewModel
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        private Color _searchExpandedBackground;
        private string _searchPlaceHolder;

        protected BaseViewModel()
        {

        }

        public Color SearchExpandedBackground
        {
            get
            {
                return _searchExpandedBackground;
            }
            set
            {
                if (_searchExpandedBackground != value)
                {
                    _searchExpandedBackground = value;
                    OnPropertyChanged(nameof(SearchExpandedBackground));
                }
            }
        }

        public string SearchPlaceHolder
        {
            get
            {
                return _searchPlaceHolder;
            }
            set
            {
                if (_searchPlaceHolder != value)
                {
                    _searchPlaceHolder = value;
                    OnPropertyChanged(nameof(SearchPlaceHolder));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
