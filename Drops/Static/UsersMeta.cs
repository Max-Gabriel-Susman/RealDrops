using System.Collections.ObjectModel;
using System.Collections.Generic;
using Drops.Services;
using Drops.Models;


namespace Drops.Static
{
    public static class UsersMeta
    {
        // PROPERTIES
        public static ObservableCollection<DropsUser> Users = new ObservableCollection<DropsUser>(); 

        public static ObservableCollection<DropsUser> OtherUsers
        {
            get
            {
                ObservableCollection<DropsUser> otherUsers = new ObservableCollection<DropsUser>();

                // Appends all users with the exception of the active ser to the otherUsers collection
                foreach(DropsUser user in Users)

                    // Excludes the Active usr from the new collection
                    if(user.Username != ActiveUser.Username)
                    {
                        otherUsers.Add(user);
                    }

                return otherUsers;

            }
        }

        public static DropsUser ActiveUser { get; set; } 

        public static DropsUser TargetUser { get; set; }

        // METHODS
        public static async void PopulateUsers()
        {
            Users.Clear();

            foreach(DropsUser user in await CosmosDBService.GetUsers())
            {
                Users.Add(user);
            }
        }

        public static void ClearUserMetaData()
        {
            ActiveUser = null;

            TargetUser = null;

            Users = new ObservableCollection<DropsUser>();
        }


        public static async void GetOtherUsers(ObservableCollection<DropsUser> users)
        {
            // Iterates over the DropsUsers collection returned from database
            foreach (DropsUser user in await CosmosDBService.GetUsers())
            {
                // Uses a conditional to exclude the active user from being appended to the argument collection
                if(user.Username != ActiveUser.Username)
                {
                    users.Add(user);
                }
            }
        }

        // let's deprecate this motherfucker
        public static bool Authentication(string username, string password)
        {
            // Iterates over the local 'Users' collection
            foreach (DropsUser user in Users)
            {
                // checks the iterated users username and password properties against the corresponding arguments
                if (user.Username == username && user.Password == password)
                {
                    ActiveUser = user;

                    return true;
                }
            }
            return false;
        }

        public static async void Registration(string username, string password)
        {
            DropsUser newUser = new DropsUser
            {
                Username = username,

                Password = password,

                ActiveAreaName = "default",

                Areas = new Dictionary<string, string>()
            };

            ActiveUser = newUser;

            Users.Add(newUser);

            await CosmosDBService.InsertUser(newUser);
        }

        public static async void UpdateActiveUser()
        {
            // Updates the Active user
            await CosmosDBService.UpdateUser(ActiveUser); // is the issue that ActiveUser is null?
        }
    }
}
