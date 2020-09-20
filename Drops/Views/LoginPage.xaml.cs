using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Drops.Models;
using Drops.ViewModels;
using Xamarin.Forms;

namespace Drops.Views
{
    public partial class LoginPage : ContentPage
    {
        // Constructor
        public LoginPage()
        {
            InitializeComponent();



            Userbase.ActiveUser = null;

            System.Diagnostics.Debug.WriteLine(UsernameEntry);
            System.Diagnostics.Debug.WriteLine(PasswordEntry);
            System.Diagnostics.Debug.WriteLine("Login page constructor");
            
            BindingContext = new LoginPageViewModel();
        }

        // Properties
        public string UsernameEntry { get; set; }

        private string PasswordEntry { get; set; }


        // Event Handlers
        void OnUsernameEntryTextChanged(object sender, TextChangedEventArgs e)
        {
            //string oldText = e.OldTextValue;
            UsernameEntry = e.NewTextValue;

            System.Diagnostics.Debug.WriteLine(UsernameEntry);
        }

        void OnPasswordEntryTextChanged(object sender, TextChangedEventArgs e)
        {
            //string oldText = e.OldTextValue;
            PasswordEntry = e.NewTextValue;

            System.Diagnostics.Debug.WriteLine(PasswordEntry);
        }


        async void OnLoginButtonClicked(object sender, EventArgs e)
        {

            // Authenticate Credentials
            System.Diagnostics.Debug.WriteLine($" this is the username entry : {UsernameEntry}");
            System.Diagnostics.Debug.WriteLine($" this is the password entry : {PasswordEntry}");

            //System.Diagnostics.Debug.WriteLine(Userbase.Authentication(UsernameEntry, PasswordEntry));

            if (Userbase.Authentication(UsernameEntry, PasswordEntry))

                // Navigate to the Applications Content
                await Navigation.PushAsync(new MapPage
                {
                    


                });

           // else

                
        }

        async void OnRegistrationButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SearchResultsListViewPage
            {

            });
        }

        async void OnLostCredentialsButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SearchResultsListViewPage
            {

            });
        }
    }
}
