using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Drops.Models;
using Drops.ViewModels;
using Xamarin.Forms;

namespace Drops.Views
{
    public partial class LoginPage : ContentPage
    {
        // FIELDS
        LoginPageViewModel vm;

        // CONSTRUCTORS
        public LoginPage()
        {
            InitializeComponent();

            System.Diagnostics.Debug.WriteLine("People list code behind constructed");

            vm = new LoginPageViewModel();

            BindingContext = vm;
        }

        // EVENT HANDLERS
        async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            vm.LoginCommand.Execute(null); 

            // we'll handle the actual navigation here
            if (true) //(vm.IsValid)
            {
                Navigation.InsertPageBefore(new MapPage(), this); // MapPage decomissioned indefinitely
                // Navigation.InsertPageBefore(new MapControlPage(), this);
                // Navigation.InsertPageBefore(new StaticAssetsPage(), this);
                await Navigation.PopAsync();
            }
            else
            {
                // Login failed
                System.Diagnostics.Debug.WriteLine("login failed");
            }
        }

        // LIFECYCLE METHODS
        protected override void OnAppearing()
        {
            base.OnAppearing();

            vm.PopulateUsersCommand.Execute(null);
        }
    }
}
