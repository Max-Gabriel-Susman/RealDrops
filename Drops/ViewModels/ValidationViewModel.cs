using System.ComponentModel;
using System.Windows.Input;
using Drops.Models;
using Drops.Services;
using Drops.Static;
using Drops.Views;
using Xamarin.Forms;


namespace Drops.ViewModels
{
    public class ValidationViewModel : INotifyPropertyChanged
    {
        // FIELDS
        public event PropertyChangedEventHandler PropertyChanged;

        // CONSTRUCTORS
        public ValidationViewModel() 
        {
            PopulateUsersCommand = new Command(async () =>
            {
                // Populates the static user collection with all the users from the DB
                foreach (DropsUser user in await CosmosDBService.GetUsers())
                {
                    UsersMeta.Users.Add(user);
                }
            });

            PopulateAreasCommand = new Command(async () =>
            {
                
                foreach (DropsArea area in await CosmosDBService.GetAreas())
                {
                    AreasMeta.Areas.Add(area);
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

        public ICommand PopulateAreasCommand { get; }

        public ICommand PopulateUsersCommand { get; }

        // METHODS
        public void ConfigureValidationEntries(string usernamePlaceholder, string passwordPlaceholder)
        {
            UsernamePlaceholder = usernamePlaceholder;

            PasswordPlaceholder = passwordPlaceholder;

            UsernameEntry = "";

            PasswordEntry = "";

            UsersMeta.ActiveUser = null;
        }

        public bool ExistenceCheck(string username)
        {
            foreach (DropsUser user in UsersMeta.Users)
            {
                if (user.Username == username)
                {
                    UsersMeta.ActiveUser = user; 

                    return true;
                }
            }

            return false;
        }
    }
}

