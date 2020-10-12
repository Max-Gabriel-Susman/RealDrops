using System;
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
        public ValidationViewModel() // we need to remove the unnecesary functionality, it's the gorilla holding the banana issue
        {
            UsernamePlaceholder = "Enter your username here:";

            PasswordPlaceholder = "Enter your password here:";

            UsernameEntry = "";

            PasswordEntry = "";

            AllUsers.ActiveUser = null;

            AllUsers.IsSafeToPopulateMapWithPins = false;

            // IsValid = false;

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

// Deprecated selective PopulateAreas logic

// Iterates over all the areas from the DB

// It's used right here without any sort of issue wtf?
// Instead of this logic that selects a single area lets just populate w/ all areas, I think the selective logic may be what's creating our latency issues
//foreach (DropsArea area in await CosmosDBService.GetAreas())
//{
//    // System.Diagnostics.Debug.WriteLine($"{area.Area} under observation");
//    // Iterates over all the k-v pairs in an area's subscriber object
//    foreach (var pair in area.Subscribers)
//    {
//        // Checks if the key from the current iteration is equivalent to the User's username
//        if (pair.Key == AllUsers.ActiveUser.Username)
//        {
//            // If the key and username are equivalent then the area from the top level iteration is made accessible to the user
//            AllAreas.SubscribedAreas.Add(area);

//            foreach (DropsArea place in AllAreas.SubscribedAreas)
//            {
//                // System.Diagnostics.Debug.WriteLine($"{place.Area} is in static subscribed areas");
//            }

//            // System.Diagnostics.Debug.WriteLine($"{area.Area} appended to subscribed areas");
//        }
//    }
//}

// something about these custom accessors preented the app from launchingx

//public string UsernamePlaceholder
//{
//    set
//    {
//        if (usernamePlaceholder != value)
//        {
//            usernamePlaceholder = value;
//        }

//        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("UsernamePlaceholder"));
//    }

//    get => UsernamePlaceholder;
//}

//public string PasswordPlaceholder
//{
//    set
//    {
//        if (passwordPlaceholder != value)
//        {
//            passwordPlaceholder = value;
//        }

//        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("PasswordPlaceholder"));
//    }

//    get => passwordPlaceholder;
//}

//public string UsernamePlaceholderColor
//{
//    set
//    {
//        if (usernamePlaceholderColor != value)
//        {
//            usernamePlaceholderColor = value;
//        }

//        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("UsernamePlaceholderColor"));
//    }

//    get => usernamePlaceholderColor;
//}

//public string PasswordPlaceholderColor
//{
//    set
//    {
//        if (passwordPlaceholderColor != value)
//        {
//            passwordPlaceholderColor = value;
//        }

//        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("PasswordPlaceholderColor"));
//    }

//    get => passwordPlaceholderColor;
//}

//public string UsernameEntry
//{
//    set
//    {
//        if (usernameEntry != value)
//        {
//            usernameEntry = value;
//        }

//        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("UsernameEntry"));
//    }

//    get => usernameEntry;
//}

//public string PasswordEntry
//{
//    set
//    {
//        if (passwordEntry != value)
//        {
//            passwordEntry = value;
//        }

//        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("PasswordEntry"));
//    }

//    get => passwordEntry;
//}