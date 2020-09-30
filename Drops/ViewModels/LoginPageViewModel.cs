using System;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Windows.Input;
using System.Threading.Tasks;
using Drops.Models;
using Drops.Views;
using Drops.Services;
using Xamarin.Forms;


namespace Drops.ViewModels
{
    public class LoginPageViewModel : BaseViewModel
    {
        // CONSTRUCTORS
        public LoginPageViewModel()
        {
            UsernamePlaceholder = "Enter your username here:";

            PasswordPlaceholder = "Enter your password here:";

            AllUsers.ActiveUser = null;

            AllUsers.IsSafeToPopulateMapWithPins = false;

            // EVENT HANDLERS
            LoginCommand = new Command(() =>
            {
                Application.Current.MainPage.Navigation.PushAsync(new MapPage());

                //if (Userbase.Authentication(UsernameEntry, PasswordEntry))
                //{
                //    UsernameEntry = "";

                //    PasswordEntry = "";

                //    Application.Current.MainPage.Navigation.PushAsync(new MapPage());
                //}
                //else
                //{
                //    UsernameEntry = "";

                //    PasswordEntry = "";

                //    UsernamePlaceHolderColor = "Red";

                //    PasswordPlaceholderColor = "Red";

                //    UsernamePlaceHolder = "Incorrect Username-Password Combination";

                //    PasswordPlaceholder = "Incorrect Username-Password Combination";
                //}
            });

            RegisterAccountCommand = new Command(() =>
            {
                Application.Current.MainPage.Navigation.PushAsync(new RegistrationPage());
            });

            ForgotCommand = new Command(() =>
            {
                Application.Current.MainPage.Navigation.PushAsync(new LostCredentialsPage());
            });

            RefreshCommand = new Command(async () =>
            {
                foreach(DropsArea area in await CosmosDBService.GetAreas())
                    AllAreas.Areas.Add(area);

                foreach (DropsUser user in await CosmosDBService.GetUsers())
                    AllUsers.Users.Add(user);
            });

            // just a dev tool, remove for deployment version
            //GetCommand = new Command(() =>
            //{
            //    System.Diagnostics.Debug.WriteLine("Listing area properties ... NOW");
            //    System.Diagnostics.Debug.WriteLine("");
            //    foreach (DropsArea area in Areas)
            //    {
            //        System.Diagnostics.Debug.WriteLine(area.ID);
            //        System.Diagnostics.Debug.WriteLine(area.Owner);
            //        System.Diagnostics.Debug.WriteLine(area.Area);
            //        System.Diagnostics.Debug.WriteLine(area.Latitude);
            //        System.Diagnostics.Debug.WriteLine(area.Longitude);
            //        System.Diagnostics.Debug.WriteLine(area.Pins);
            //        // we need to iterate over each key in the outer dictionary and foreach inner key log  the key and it's value
            //        foreach (var pair in area.Pins)
            //        {
            //            Dictionary<string, string> pin = pair.Value;

            //            string name = pair.Key;

            //            foreach (var innerPair in pair.Value)
            //            {
            //                string key = innerPair.Key;

            //                string value = innerPair.Value;

            //                System.Diagnostics.Debug.WriteLine($"Pin {name}'s {key} is set at {value}.");
            //            }
            //        }
            //        //for(int i = 0; i < area.Pins.Count; i++)
            //        //{
            //        //    area.Pins[i]
            //        //}

            //            System.Diagnostics.Debug.WriteLine("");
            //    }

            //    System.Diagnostics.Debug.WriteLine("Listing user properties ... NOW");
            //    System.Diagnostics.Debug.WriteLine("");
            //    foreach (DropsUser user in Users)
            //    {
            //        System.Diagnostics.Debug.WriteLine(user.ID);
            //        System.Diagnostics.Debug.WriteLine(user.Username);
            //        System.Diagnostics.Debug.WriteLine(user.Password);
            //        System.Diagnostics.Debug.WriteLine(user.ActiveArea);
            //        System.Diagnostics.Debug.WriteLine(user.Areas);
            //        foreach(string area in user.Areas)
            //            System.Diagnostics.Debug.WriteLine(area);
                    
            //        System.Diagnostics.Debug.WriteLine("");
            //    }
            //});
        }

        // PROPERTIES
        public string UsernameEntry { get; set; }

        public string PasswordEntry { get; set; }

        public string UsernamePlaceholder { get; set; }

        public string PasswordPlaceholder { get; set; }

        public string UsernamePlaceholderColor { get; set; }

        public string PasswordPlaceholderColor { get; set; }

        public ICommand RegisterAccountCommand { get; }

        public ICommand ForgotCommand { get; }

        public ICommand LoginCommand { get; }

        //public ICommand GetCommand { get; }

        public ICommand RefreshCommand { get; }

        public ObservableCollection<DropsArea> Areas
        {
            get => AllAreas.Areas;
        }

        public ObservableCollection<DropsUser> Users
        {
            get => AllUsers.Users;
        }

        // METHODS
        //async Task ExecuteRefreshCommand()
        //{
        //    if (IsBusy)
        //        return;

        //    IsBusy = true;

        //    try
        //    {
        //        Areas = await CosmosDBService.GetAreas();

        //        Users = await CosmosDBService.GetUsers();
        //    }
        //    finally
        //    {
        //        IsBusy = false;
        //    }
        //}
    }
}