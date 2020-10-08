using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using System.Collections.Generic;


namespace Drops.ViewModels
{
    // when I start migrating logic to the mapcontrolviewmodel I will probably want to derive from this class
    public class BaseViewModel : INotifyPropertyChanged
    {
        // At a later point I need to evaluate the necessity of all the content in this class
        // Also I think there's a lot of content I can abstract to here at a later point in time, but let's get things running first

        // I don't thik I need this anymore
        string _title = "";
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        // and I don't think I need this either
        bool _isBusy = false;
        public bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value);
        }

        // I think these guys are the special sauce that was making arealistview work it's magic
        protected void SetProperty<T>(ref T backingStore, T value, Action onChanged = null, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return;

            backingStore = value;

            onChanged?.Invoke();

            HandlePropertyChanged(propertyName);
        }

        // not actually sure what's going on here, I need to grok this because my codebase currently relies on it
        protected void HandlePropertyChanged(string propertyName = "") =>
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
