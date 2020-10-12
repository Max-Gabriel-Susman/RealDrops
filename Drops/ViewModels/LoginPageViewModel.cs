using System.Windows.Input;
using Drops.Models;
using Drops.Views;
using Drops.Static;
using Drops.Services;
using Xamarin.Forms;



namespace Drops.ViewModels
{
    public class LoginPageViewModel : ValidationViewModel
    {
        // CONSTRUCTORS
        public LoginPageViewModel()
        {
            UsernamePlaceholder = "See Github README for Username";// "Enter your username here:";

            PasswordPlaceholder = "See Github README for Password";// "Enter your password here:";

            UsernameEntry = "";

            PasswordEntry = "";

            AllUsers.ActiveUser = null;
            
            LoginCommand = new Command(() =>
            {
                if (AllUsers.Authentication(UsernameEntry, PasswordEntry))
                {
                    // Assigns AllUsers.ActiveUser to the User Object whose credentials were used for authentication
                    foreach (DropsUser user in AllUsers.Users) 
                    {
                        if (user.Username == UsernameEntry) 
                        {
                            
                            AllUsers.ActiveUser = user;
                        }
                    }

                    
                    if (AllUsers.ActiveUser == null) { return; }

                    AllAreas.GetActiveArea(AllAreas.ActiveArea); 
                }
            });

            CredentialRecoveryCommand = new Command(() =>
            {
                Application.Current.MainPage.Navigation.PushAsync(new LostCredentialsViewPage());
            });

            NavToRegistrationCommand = new Command(() =>
            {
                Application.Current.MainPage.Navigation.PushAsync(new RegistrationPage());
            });
        }

        // PROPERTIES
        public ICommand NavToRegistrationCommand { get; }

        public ICommand LoginCommand { get; }

        public ICommand CredentialRecoveryCommand { get; }
        
    // METHODS
    public async void GetActiveArea(DropsUser user) 
        {
            
            foreach (DropsArea area in await CosmosDBService.GetAreas()) 
            {
                if (area.AreaName == user.ActiveAreaName)
                {
                    AllAreas.ActiveArea = area;

                    return;
                }
            }
        }
    }
}