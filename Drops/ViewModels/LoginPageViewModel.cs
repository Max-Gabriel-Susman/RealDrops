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
        // FIELDS
        List<DropsUser> users;

        List<DropsArea> areas;

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

            GetCommand = new Command(() =>
            {
                System.Diagnostics.Debug.WriteLine("Listing user properties ... NOW");
                System.Diagnostics.Debug.WriteLine("");
                foreach (DropsArea area in Areas)
                {
                    System.Diagnostics.Debug.WriteLine(area.ID);
                    System.Diagnostics.Debug.WriteLine(area.Owner);
                    System.Diagnostics.Debug.WriteLine(area.Area);
                    System.Diagnostics.Debug.WriteLine(area.Latitude);
                    System.Diagnostics.Debug.WriteLine(area.Longitude);
                    System.Diagnostics.Debug.WriteLine("");
                }

                System.Diagnostics.Debug.WriteLine("Listing user properties ... NOW");
                System.Diagnostics.Debug.WriteLine("");
                foreach (DropsArea area in Areas)
                {
                    System.Diagnostics.Debug.WriteLine(area.ID);
                    System.Diagnostics.Debug.WriteLine(area.Owner);
                    System.Diagnostics.Debug.WriteLine(area.Area);
                    System.Diagnostics.Debug.WriteLine(area.Latitude);
                    System.Diagnostics.Debug.WriteLine(area.Longitude);
                    System.Diagnostics.Debug.WriteLine("");
                }
            });
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

        public ICommand GetCommand { get; }

        public List<DropsArea> Areas { get => areas; set => SetProperty(ref areas, value); }

        public List<DropsUser> Users { get => users; set => SetProperty(ref users, value); }

        // EVENT HANDLERS
        async Task ExecuteRefreshCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Areas = await CosmosDBService.GetAreas();
                Users = await CosmosDBService.GetUsers();
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}