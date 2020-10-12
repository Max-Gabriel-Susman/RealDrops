using System.ComponentModel;
using System.Windows.Input;
using Drops.Models;
using Drops.Services;
using Drops.Static;
using Xamarin.Forms;


namespace Drops.ViewModels
{
    public class ValidationViewModel : INotifyPropertyChanged
    {
        // FIELDS
        public event PropertyChangedEventHandler PropertyChanged;

        public string usernamePlaceholder;

        public string passwordPlaceholder;

        public string usernamePlaceholderColor;

        public string passwordPlaceholderColor;

        public string usernameEntry;

        public string passwordEntry;

        // CONSTRUCTORS
        public ValidationViewModel() 
        {
            // COMMANDS
            PopulateUsersCommand = new Command(async () =>
            {
                // Populates the static user collection with all the users from the DB
                foreach (DropsUser user in await CosmosDBService.GetUsers())
                {
                    AllUsers.Users.Add(user);
                }
            });

            PopulateAreasCommand = new Command(async () =>
            {
                
                foreach (DropsArea area in await CosmosDBService.GetAreas())
                {
                    AllAreas.Areas.Add(area);
                }
            });
        }

        // PROPERTIES
        public string UsernamePlaceholder { get; set; }

        public string PasswordPlaceholder { get; set; }

        public string UsernamePlaceholderColor { get; set; }

        public string PasswordPlaceholderColor { get; set; }

        public string UsernameEntry { get; set; }

        public string PasswordEntry { get; set; }

        public bool IsValid { get; set; }

        public ICommand PopulateAreasCommand { get; }

        public ICommand PopulateUsersCommand { get; }
    }
}

