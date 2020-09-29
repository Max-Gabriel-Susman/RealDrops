using System;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Windows.Input;
using Drops.Models;
using Drops.Views;
using Xamarin.Forms;


namespace Drops.ViewModels
{
    public class RegistrationPageViewModel //: INotifyPropertyChanged
    {
        // CONSTRUCTORS
        public RegistrationPageViewModel()
        {
            // EVENT HANDLERS
            CreateCommand = new Command(() =>
            {
                AllUsers.CreateUser(UsernameEntry, PasswordEntry);

                UsernameEntry = "";

                PasswordEntry = "";
            });
        }

        // PROPERTIES
        // public event PropertyChangedEventHandler PropertyChanged;

        public string UsernameEntry { get; set; }

        public string PasswordEntry { get; set; }

        public ICommand CreateCommand { get;  }
    }
}
