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
                // we need visual feedback so the user knows their credential combination was invalid
                vm.UsernameEntry = string.Empty;

                vm.PasswordEntry = string.Empty;

                //vm.UsernamePlaceholder = "Incorrect credential combination";

                //vm.PasswordPlaceholder = "Incorrect credential combination";

                //// let's change the text color to red and maybe the background color to pinkish
                //vm.UsernamePlaceholderColor = string.Empty;

                //vm.PasswordPlaceholderColor = string.Empty;

                System.Diagnostics.Debug.WriteLine("login failed");
            }
        }

        // EVENT HANDLERS
        async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            Login(vm.UsernameEntry, vm.PasswordEntry);   
        }

        // LIFECYCLE METHODS
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
