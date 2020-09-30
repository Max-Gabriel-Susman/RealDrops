using System;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Windows.Input;
using Drops.Models;
using Drops.Views;
using Drops.Services;
using Xamarin.Forms;


namespace Drops.ViewModels
{
    public class RegistrationPageViewModel : INotifyPropertyChanged
    {
        // CONSTRUCTORS
        public RegistrationPageViewModel()
        {
            // EVENT HANDLERS
            CreateCommand = new Command(async () =>
            {
                // jeez I'm tired rn

                await CosmosDBService.InsertUser(new DropsUser("id", // let's take a look at how todoitems handled ids
                                                               UsernameEntry,
                                                               PasswordEntry,
                                                               "default",
                                                               new Dictionary<string, string>()));


                //public DropsUser(string id,
                //         string username,
                //         string password,
                //         string activeArea,
                //         Dictionary<string, string> areas)
                //{
                //    ID = id;

                //    Username = username;

                //    Password = password;

                //    ActiveArea = activeArea;

                //    Areas = areas;
                //}

                //
            });
        }

        // PROPERTIES
        public event PropertyChangedEventHandler PropertyChanged;

        public string UsernameEntry { get; set; }

        public string PasswordEntry { get; set; }

        public ICommand CreateCommand { get;  }

        public ObservableCollection<DropsArea> Areas
        {
            get => AllAreas.Areas;

            //set; // i don't think we actually need to set this value in this class
        }

        public ObservableCollection<DropsUser> Users
        {
            get => AllUsers.Users;

            //set; we need to append valid new users here
            // username and pasword will be checked for validity and a new and unique id will be generated
        }

    }
}
