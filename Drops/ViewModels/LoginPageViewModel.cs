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
    public class LoginPageViewModel : ValidationViewModel
    {
        // CONSTRUCTORS
        public LoginPageViewModel()
        {
            LoginCommand = new Command(() =>
            {
                if (AllUsers.Authentication(UsernameEntry, PasswordEntry))
                {
                    // Assigns AllUsers.ActiveUser to the user whose credentials were used for authentication
                    foreach (DropsUser user in AllUsers.Users)
                    {
                        if (user.Username == UsernameEntry)
                        {
                            AllUsers.ActiveUser = user;
                        }
                    }

                    // Enforces a non null Active User as a requisite to Login
                    if (AllUsers.ActiveUser == null) { return; }

                    //PopulateAreasCommand.Execute(null); // breakpoint here

                    //GetActiveArea(AllUsers.ActiveUser); // breakpoint here

                    AllAreas.GetActiveArea(AllAreas.ActiveArea); // wot

                    System.Diagnostics.Debug.WriteLine(AllAreas.ActiveArea.AreaName == null); // still null // we need a default activearea
                }
            });

            NavToRegistrationCommand = new Command(() =>
            {
                Application.Current.MainPage.Navigation.PushAsync(new RegistrationPage());
            });
        }

        // PROPERTIES
        public ICommand NavToRegistrationCommand { get; }

        public ICommand LoginCommand { get; }

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