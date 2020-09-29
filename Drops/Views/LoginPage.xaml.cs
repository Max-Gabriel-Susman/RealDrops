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

        // LIFECYCLE METHODS
        // we need to move this functionality to the login page
        protected override void OnAppearing()
        {
            base.OnAppearing();

            vm.RefreshCommand.Execute(null);
        }
    }
}
