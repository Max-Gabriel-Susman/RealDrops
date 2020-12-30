using System;
using Drops.ViewModels;
using Drops.SharedResources;
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

            vm = new LoginPageViewModel();

            BindingContext = vm;
        }

        // METHODS
        async void Login(string username, string password)
        {
            bool loginSuccess = vm.LoginValidation(username, password);

            if (loginSuccess)
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

        // EVENT HANDLERS
        async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            Login(vm.UsernameEntry, vm.PasswordEntry);   
        }

        // LIFECYCLE METHODS
        // sumthin like onappearing right?
        //public void OnApp
        async protected override void OnAppearing()
        {
            base.OnAppearing();

            if (UsersMeta.ActiveUser != null)
            {
                Login(UsersMeta.ActiveUser.Username, UsersMeta.ActiveUser.Password);
            }
        }
    }
}
