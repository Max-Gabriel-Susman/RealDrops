using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Drops.Services;
using Drops.Models;


namespace Drops.Static
{
    public static class AllUsers
    {
        // PROPERTIES
        public static ObservableCollection<DropsUser> Users = new ObservableCollection<DropsUser>(); // we need to assign this to the users gotten from the db

        // Readonly Property that Returns a collection of all users excluding the ActiveUser
        public static ObservableCollection<DropsUser> OtherUsers
        {
            get
            {
                ObservableCollection<DropsUser> otherUsers = new ObservableCollection<DropsUser>();

                foreach(DropsUser user in Users)

                    if(user.Username != ActiveUser.Username)
                    {
                        otherUsers.Add(user);
                    }

                return otherUsers;

            }
        }

        public static DropsUser ActiveUser { get; set; } // is it set upon login?

        public static DropsUser TargetUser { get; set; }

        public static bool IsSafeToPopulateMapWithPins { get; set; } // might not need?

        // METHODS
        public static async void GetOtherUsers(ObservableCollection<DropsUser> users)
        {
            foreach (DropsUser user in await CosmosDBService.GetUsers())
            {
                if(user.Username != ActiveUser.Username)
                {
                    users.Add(user);
                }
            }
        }

        // I think that we should migrate some of the logic from loginviewmodel logincommand to this method bcause it would be more performant
        public static bool Authentication(string username, string password)
        // Determines the validity of credential entry
        {

            foreach (DropsUser user in Users)
            {
                System.Diagnostics.Debug.WriteLine($"Authentictation checking {user.Username} against input");

                System.Diagnostics.Debug.WriteLine(Equals(user.Username, username) && Equals(user.Password, password));

                System.Diagnostics.Debug.WriteLine($"Username entry is {username}");

                System.Diagnostics.Debug.WriteLine($"Username entry is {password}");

                if (user.Username == username && user.Password == password)
                {
                    ActiveUser = user;

                    return true;
                }
            }

            return false;
        }

        public static async void UpdateActiveUser()
        {
            await CosmosDBService.UpdateUser(ActiveUser); // why did this get activated and why did it throw a null exception when area was selected?
        }
    }
}
