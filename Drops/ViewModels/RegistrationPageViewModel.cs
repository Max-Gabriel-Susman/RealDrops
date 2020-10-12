using System;
using System.Collections.Generic;
using System.Windows.Input;
using Drops.Models;
using Drops.Static;
using Drops.Services;
using Xamarin.Forms;


namespace Drops.ViewModels
{
    public class RegistrationPageViewModel : ValidationViewModel
    {
        // CONSTRUCTORS
        public RegistrationPageViewModel()
        {
            User = new DropsUser();

            SaveCommand = new Command(async () =>
            {
                // Enforcces Unique usernames
                foreach (DropsUser user in await CosmosDBService.GetUsers())
                {
                    if (user.Username == UsernameEntry)
                    {
                        return;
                    }
                }

                // Enforces a minimum password length of 8 characters
                if (PasswordEntry.Length >= 8)
                {
                    User.Username = UsernameEntry;

                    User.Password = PasswordEntry;

                    User.ActiveAreaName = "default"; 

                    User.Areas = new Dictionary<string, string>();

                    await CosmosDBService.InsertUser(User);

                    AllUsers.Users.Add(User);

                    //SaveComplete?.Invoke(this, new EventArgs());

                    AllUsers.ActiveUser = User;

                    System.Diagnostics.Debug.WriteLine($"IsValid is currently {IsValid}");
                }

                
            });
        }

        // PROPERTIES 
        public DropsUser User { get; set; }

        public ICommand SaveCommand { get; }

        public event EventHandler SaveComplete;
    }
}
