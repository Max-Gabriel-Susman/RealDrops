using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Drops.Models;
using Drops.ViewModels;
using Xamarin.Forms;

namespace Drops.Views
{
    public partial class PeopleListViewPage : ContentPage
    {
        public PeopleListViewPage()
        {
            InitializeComponent();

            OtherUsers = Userbase.OtherUsers;
            //Users = Userbase.Users;

            ShareCommand = new Command(OnShareTapped);

            BindingContext = this;
        }

        // wot does icommand need?
        public ICommand ShareCommand { get; }

        public ObservableCollection<User> OtherUsers { get; set; }
        //public ObservableCollection<User> Users { get; set; }

        async void OnShareTapped(object obj)
        {
            

            User user = obj as User;

            System.Diagnostics.Debug.WriteLine(user.Username);

            await Navigation.PushAsync(new AreaShareViewPage
            {
                // Passes Active User to the New ContentPage
               Recipient = user

            });

            
        }
    }
}
