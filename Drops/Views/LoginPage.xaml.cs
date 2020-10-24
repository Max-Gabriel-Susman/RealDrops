using System;
using Drops.ViewModels;
using Drops.Static;
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
        // Is there a way to reference this page object from the viewmodel? if so I  can migrate this functionality to the view model
        {
            //vm.LoginCommand.Execute(null);

            bool loginSuccess = vm.LoginValidation(vm.UsernameEntry, vm.PasswordEntry);


            if (loginSuccess) // why is active user not getting assigned?
            {
                Navigation.InsertPageBefore(new MapControlPage(), this);

                await Navigation.PopAsync();
            }
            else
            {
                vm.UsernameEntry = string.Empty;

                vm.PasswordEntry = string.Empty;

                System.Diagnostics.Debug.WriteLine("login failed");
            }
        }

        // LIFECYCLE METHODS - I should move these to app.xaml.cs
        protected override void OnAppearing()
        {
            base.OnAppearing(); 

            // I should turn these into regular methods put them in theiir respective metadata classes and invoke them from app.xaml.cs
            vm.PopulateUsersCommand.Execute(null); 
            vm.PopulateAreasCommand.Execute(null); 
        }
    }
}
