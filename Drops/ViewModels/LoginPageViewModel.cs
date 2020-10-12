using System;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Windows.Input;
using System.Threading.Tasks;
using Drops.Models;
using Drops.Views;
using Drops.Static;
using Drops.Services;
using Xamarin.Forms;



namespace Drops.ViewModels
{
    public class LoginPageViewModel : ValidationViewModel
    {
        

        // CONSTRUCTORS
        public LoginPageViewModel()
        {
            UsernamePlaceholder = "See Github README for Username";// "Enter your username here:";

            PasswordPlaceholder = "See Github README for Password";// "Enter your password here:";

            UsernameEntry = "";

            PasswordEntry = "";

            AllUsers.ActiveUser = null;

            AllUsers.IsSafeToPopulateMapWithPins = false;

            // 

            BackgroundColor = Color.FromHex("423f3b");

            NavigationBackgroundColor = Color.FromHex("58a0ca");
            // we need to grok request units and then use that knowledge to implement a cheaper set of transactions that enable the current set of functionality
            LoginCommand = new Command(() =>
            {
                if (AllUsers.Authentication(UsernameEntry, PasswordEntry))
                {
                    // Assigns AllUsers.ActiveUser to the user whose credentials were used for authentication
                    foreach (DropsUser user in AllUsers.Users) // it lookes like active user should be assined here
                    {
                        System.Diagnostics.Debug.WriteLine($"The user under inspection is {user.Username} and the username entry is {UsernameEntry}");

                        if (user.Username == UsernameEntry) // assignment logic is functioning correctly
                        {
                            System.Diagnostics.Debug.WriteLine("We got a match!");
                            AllUsers.ActiveUser = user;
                        }
                    }

                    // Enforces a non null Active User as a requisite to Login
                    if (AllUsers.ActiveUser == null) { return; }

                    //PopulateAreasCommand.Execute(null); // breakpoint here

                    //GetActiveArea(AllUsers.ActiveUser); // breakpoint here

                    AllAreas.GetActiveArea(AllAreas.ActiveArea); // wot

                    //System.Diagnostics.Debug.WriteLine($"hey suga the active area name is {AllAreas.ActiveArea.AreaName}"); // still null // we need a default activearea
                    // System.Diagnostics.Debug.WriteLine(AllAreas.ActiveArea.AreaName); // still null // we need a default activearea
                }
            });

            CredentialRecoveryCommand = new Command(() =>
            {
                Application.Current.MainPage.Navigation.PushAsync(new LostCredentialsViewPage());
            });

            NavToRegistrationCommand = new Command(() =>
            {
                Application.Current.MainPage.Navigation.PushAsync(new RegistrationPage());
            });
        }

        // PROPERTIES
        public ICommand NavToRegistrationCommand { get; }

        public ICommand LoginCommand { get; }

        public ICommand CredentialRecoveryCommand { get; }

        public Color BackgroundColor { get; set; }

        public Color NavigationBackgroundColor { get; set; }
        
    // METHODS
    public async void GetActiveArea(DropsUser user) // what if we did something like this for the getsubscribed areas method?
        {
            // foreach (DropsArea area in CosmosDBService.GetAreas().Result) // why the fuck is there a .Result?
            foreach (DropsArea area in await CosmosDBService.GetAreas()) // foreach cannot operate on variables of type Task<List<DropsArea>>
            {
                if (area.AreaName == user.ActiveAreaName)
                {
                    AllAreas.ActiveArea = area;

                    return;
                }
            }
        }
    }
}