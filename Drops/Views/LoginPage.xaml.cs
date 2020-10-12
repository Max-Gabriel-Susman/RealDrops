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
        {
            vm.LoginCommand.Execute(null); 
            
            if (AllUsers.ActiveUser != null) 
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

        // LIFECYCLE METHODS
        protected override void OnAppearing()
        {
            base.OnAppearing(); 

            vm.PopulateUsersCommand.Execute(null); 
            vm.PopulateAreasCommand.Execute(null); 
        }
    }
}
