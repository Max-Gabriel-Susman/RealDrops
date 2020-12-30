using System;
using System.Collections.Generic;
using Drops.ViewModels;
using Drops.SharedResources;
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

            BindingContext = vm;
        }

        // EVENT HANDLERS
        async void OnRegistrationButtonClicked(object sender, EventArgs e)
        {
            string registrationSuccess = vm.RegistrationValidation(vm.UsernameEntry, vm.PasswordEntry);

            System.Diagnostics.Debug.WriteLine(registrationSuccess);

            if(registrationSuccess == "REGISTER")
            {
                // UsersMeta.PopulateUsers();

                //Navigation.InsertPageBefore(new MapControlPage(), this);

                //await Navigation.PopAsync();

                // we need to navigate to login here

                //await Application.Current.MainPage.Navigation.PushAsync(new LoginPage(){


                //});

                //Navigation.InsertPageBefore(new MapControlPage(), this);

                UsersMeta.PopulateUsers();

                await Navigation.PopAsync();
            }
            else
            {
                vm.UsernameEntry = string.Empty;

                vm.PasswordEntry = string.Empty;

                System.Diagnostics.Debug.WriteLine("registration failed");
            }
        }
    }
}
