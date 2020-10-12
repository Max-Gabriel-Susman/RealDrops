using System;
using System.Collections.Generic;
using Drops.ViewModels;
using Drops.Static;
using Xamarin.Forms;

namespace Drops.Views
{
    public partial class RegistrationPage : ContentPage
    {
        // FIELDS
        RegistrationPageViewModel vm;

        // CONSTRUCTORS
        public RegistrationPage()
        {
            InitializeComponent();

            vm = new RegistrationPageViewModel();

            vm.UsernamePlaceholder = "Create a username";

            vm.PasswordPlaceholder = "Create a Password";

            BindingContext = vm;
        }

        // EVENT HANDLERS
        async void OnRegistrationButtonClicked(object sender, EventArgs e)
        {
            vm.SaveCommand.Execute(null);

            if (AllUsers.ActiveUser != null)
            {
                Application.Current.MainPage.Navigation.InsertPageBefore(new MapControlPage(), this);
                await Application.Current.MainPage.Navigation.PopAsync();
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("registration failed, ACTIVE USER WAS NUll");

                // Logic to alert the user that their login has failed
            }
        }
    }
}
