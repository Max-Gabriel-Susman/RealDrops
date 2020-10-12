using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Drops.Models;
using Drops.ViewModels;
using Drops.Static;
using Xamarin.Forms;

namespace Drops.Views
{
    public partial class LoginPage : ContentPage
    {
        // alright good I got it working, now I need to understand what the fuck is going on
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
            // where are we populating user(s)?

            // we need to assign active user
            
            // we'll handle the actual navigation here
            if (AllUsers.ActiveUser != null) //(vm.IsValid)
            {
                // Navigation.InsertPageBefore(new MapPage(), this); // MapPage decomissioned indefinitely
                //System.Diagnostics.Debug.WriteLine($"activeusername is {AllUsers.ActiveUser.Username}");
                // System.Diagnostics.Debug.WriteLine($"the active area name is {AllAreas.ActiveArea.AreaName}");

                Navigation.InsertPageBefore(new MapControlPage(), this);
                // Navigation.InsertPageBefore(new StaticAssetsPage(), this);
                await Navigation.PopAsync();
            }
            else
            {
                // Login failed

                // upon failure we need the entries text properties to be set to empty and red placeholder text feedback

                // maybe implementing a vm instance like i did here in droplistviewpage.xaml.cs will let me successfully pass the value of the key to the detailpage

                vm.UsernameEntry = string.Empty;

                vm.PasswordEntry = string.Empty;

                System.Diagnostics.Debug.WriteLine("login failed");
            }
        }

        // LIFECYCLE METHODS
        protected override void OnAppearing()
        {
            base.OnAppearing();

            vm.PopulateUsersCommand.Execute(null); // this is where the users are populated
            vm.PopulateAreasCommand.Execute(null); // let's try and populate all users right here and see if that resolves the latency issues I've been dealing with
        }
    }
}
