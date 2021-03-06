﻿using System.Windows.Input;
using Drops.Models;
using Drops.Views;
using Drops.SharedResources;
using Drops.Services;
using Xamarin.Forms;



namespace Drops.ViewModels
{
    public class LoginPageViewModel : ValidationViewModel
    {
        // CONSTRUCTORS
        public LoginPageViewModel()
        {
            ConfigureValidationEntries("Enter your Username: ", "Enter your password: ");

            CredentialRecoveryCommand = new Command(() =>
            {
                System.Diagnostics.Debug.WriteLine("Nav to cred recovery invoked");

                Application.Current.MainPage.Navigation.PushAsync(new LostCredentialsViewPage());
            });

            NavToRegistrationCommand = new Command(() =>
            {
                System.Diagnostics.Debug.WriteLine("Nav to reg invoked");

                Application.Current.MainPage.Navigation.PushAsync(new RegistrationPage());


            });
        }

        // PROPERTIES
        public ICommand NavToRegistrationCommand { get; }

        public ICommand CredentialRecoveryCommand { get; }

        // METHODS
        // Handles Validation against The Users Collection
        public bool LoginValidation(string username, string password)
        {
            System.Diagnostics.Debug.WriteLine(username);
            // checks if username entry is currently in use
            bool usernameTaken = ExistenceCheck(username);

            if (usernameTaken && UsersMeta.ActiveUser.Password == password)
            {
                return true;
            }

            return false;
        }
    }
}